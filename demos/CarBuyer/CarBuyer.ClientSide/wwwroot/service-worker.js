const cacheName = 'offline-cache-16';

self.addEventListener('install', async event => {
    console.log('Installing service worker...');
    await Promise.all((await caches.keys()).map(key => caches.delete(key)));
    self.skipWaiting();
});

self.addEventListener('fetch', event => {
    event.respondWith(getPossiblyCachedResponse(event.request));
});

async function getPossiblyCachedResponse(request) {
    const isInitialPageLoad = request.mode === 'navigate'
        || request.method === 'GET' && request.headers.get('accept').indexOf('text/html') > -1;
    if (isInitialPageLoad) {
        console.log('Overridding URL');
    }

    const cachedResponse = await caches.match(isInitialPageLoad ? '/' : request);
    if (cachedResponse) {
        console.log('Found ', request.url, ' in cache');
        return cachedResponse;
    } else {
        console.log('Network request for ', request.url);
        const response = await fetch(request);

        const cache = await caches.open(cacheName);
        cache.put(request.url, response.clone());

        return response;
    }
}
