class PinMap {
    static createOrUpdate(el, center) {
        if (!el.hasMap) {
            el.hasMap = true;

            mapboxgl.accessToken = 'pk.eyJ1IjoibW9rYXNpZGoiLCJhIjoiY2p3bHlzbzVoMTdyZDN5cWszbGc3bGdtciJ9.kOD1TNfTB09ekr1bBYeL3w';

            // Insert mapboxgl.Map into an immediate child element
            const mapContainer = document.createElement('div');
            mapContainer.style.width = '100%';
            mapContainer.style.height = '100%';
            el.appendChild(mapContainer);
            const map = new mapboxgl.Map({
                style: 'mapbox://styles/mapbox/light-v10',
                center: center,
                zoom: 16.5,
                pitch: 45,
                bearing: 0,
                container: mapContainer
            });
            map.pinPointFeatures = [];

            //map.on('click', evt => {
            //    console.log(`new Agent { Longitude = ${evt.lngLat.lng.toFixed(4)}, Latitude = ${evt.lngLat.lat.toFixed(4)}, Name = "", Mission = "" },`);
            //});

            // Once it's loaded, configure it
            map.on('load', () => {
                map.addImage('pulsing-dot', PinMap.pulsingDot(map, el), { pixelRatio: 2 });

                map.addSource("pinPointSource", {
                    "type": "geojson",
                    "data": {
                        "type": "FeatureCollection",
                        "features": []
                    }
                });

                map.addLayer({
                    "id": "points",
                    "type": "symbol",
                    "source": "pinPointSource",
                    "layout": {
                        "icon-image": "pulsing-dot",
                        "text-allow-overlap": true,
                        "icon-allow-overlap": true,
                    }
                });

                map.addLayer({
                    'id': '3d-buildings',
                    'source': 'composite',
                    'source-layer': 'building',
                    'filter': ['==', 'extrude', 'true'],
                    'type': 'fill-extrusion',
                    'minzoom': 15,
                    'paint': {
                        'fill-extrusion-color': '#aaa',
                        'fill-extrusion-opacity': .8,
                        // use an 'interpolate' expression to add a smooth transition effect to the
                        // buildings as the user zooms in
                        'fill-extrusion-height': [
                            "interpolate", ["linear"], ["zoom"],
                            15, 0,
                            15.05, ["get", "height"]
                        ],
                        'fill-extrusion-base': [
                            "interpolate", ["linear"], ["zoom"],
                            15, 0,
                            15.05, ["get", "min_height"]
                        ]
                    }
                });

                el.querySelectorAll('map-pin').forEach(markerElem => {
                    PinMap.addOrUpdatePoint(map, markerElem);
                });

                new MutationObserver(mutations => {
                    mutations.forEach(mutation => {
                        mutation.addedNodes.forEach(node => {
                            if (node.tagName === 'MAP-PIN') {
                                PinMap.addOrUpdatePoint(map, node);
                            }
                        });
                        mutation.removedNodes.forEach(node => {
                            if (node.tagName === 'MAP-PIN') {
                                PinMap.removePoint(map, node);
                            }
                        });
                    });
                }).observe(el, { childList: true });
            });
        }
    }

    static addOrUpdatePoint(map, displayElement) {
        const coordinates = [parseFloat(displayElement.dataset.longitude), parseFloat(displayElement.dataset.latitude)];
        if (!displayElement.mapFeature) {
            // Add invisible (but clickable) marker
            const markerElement = document.createElement('div');
            markerElement.style.width = '20px';
            markerElement.style.height = '20px';
            displayElement.mapMarker = new mapboxgl.Marker({ offset: [0, 5], element: markerElement })
                .setLngLat(coordinates)
                .addTo(map);

            // Add animated dot feature
            displayElement.mapFeature = { type: "Feature" };
            map.pinPointFeatures.push(displayElement.mapFeature);
        }
        displayElement.mapFeature.geometry = { type: "Point", coordinates: coordinates };
        displayElement.mapMarker
            .setLngLat(coordinates)
            .setPopup(new mapboxgl.Popup({ offset: [0, -5] }).setHTML(displayElement.innerHTML))
        PinMap._refreshPoints(map);
    }

    static removePoint(map, displayElement) {
        if (displayElement.mapFeature) {
            displayElement.mapMarker.remove();
            const indexToRemove = map.pinPointFeatures.indexOf(displayElement.mapFeature);
            map.pinPointFeatures.splice(indexToRemove, 1);
            delete displayElement.mapFeature;
            delete displayElement.mapMarker;
            PinMap._refreshPoints(map);
        }
    }

    static _refreshPoints(map) {
        map.getSource('pinPointSource').setData({
            "type": "FeatureCollection",
            "features": map.pinPointFeatures
        });
    }

    static pulsingDot(map, el) {
        const size = 100;
        return {
            width: size,
            height: size,
            data: new Uint8Array(size * size * 4),

            onAdd() {
                var canvas = document.createElement('canvas');
                canvas.width = this.width;
                canvas.height = this.height;
                this.context = canvas.getContext('2d');
            },

            render() {
                var duration = 1000;
                var t = (performance.now() % duration) / duration;

                var radius = size / 2 * 0.3;
                var outerRadius = size / 2 * 0.7 * t + radius;
                var context = this.context;

                // draw outer circle
                context.clearRect(0, 0, this.width, this.height);
                context.beginPath();
                context.arc(this.width / 2, this.height / 2, outerRadius, 0, Math.PI * 2);
                context.fillStyle = 'rgba(255, 200, 200,' + (1 - t) + ')';
                context.fill();

                // draw inner circle
                context.beginPath();
                context.arc(this.width / 2, this.height / 2, radius, 0, Math.PI * 2);
                context.fillStyle = 'rgba(255, 100, 100, 1)';
                context.strokeStyle = 'white';
                context.lineWidth = 2 + 4 * (1 - t);
                context.fill();
                context.stroke();

                // update this image's data with data from the canvas
                this.data = context.getImageData(0, 0, this.width, this.height).data;

                // keep the map repainting
                if (document.body.contains(el)) {
                    map.triggerRepaint();
                }

                // return `true` to let the map know that the image was updated
                return true;
            }
        };
    }
}

window.PinMap = PinMap;
