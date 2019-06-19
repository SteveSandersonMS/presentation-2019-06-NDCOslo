Pre-demo setup
==============

* Car Buyer PWA
  - Have it already running, but minimised
* Windows dock
  - Auto-hide
* Powerpoint
  - Open with slides
* Git
  - This repo on "pre-demo-state" branch, clean
  - Blutter repo in clean pre-demo state
* VS
  - Check you can open & run all the 'full spectrum' demos
    - Blutter
    - CarBuyer variants
      - Electron
      - Client-side
        - CHECK SERVICE WORKER IS DELETED IN CHROME
      - Server-side
    - Close all tabs etc.
  - Check you can open & run MissionControl demo
    - CHECK YOU CAN REACH DEBUGGER IN BROWSER and all breakpoints/tabs cleared
    - CHECK LOCALSTORAGE IS CLEARED (so you're logged out)
    - Checks snippets present
    - Hide "Snippets" folder
  - Open BlazorBasics demo
    - Check it runs
    - Leave this open
  - Font size, full screen
* Timer ready to start

--------------

Target audience:
 - Has heard of Blazor before in both client-side and server-side variants, though
   is unclear about the differences
 - Has seen 'hello world' Blazor demos before
 - Wants to see things that are technically novel

--------------

[18] What is Blazor?
  - S: [3] Blazor is a rich interactive web UIs on .NET
       Can run server-side on client-side.
       This talk mostly focuses on client-side (WebAssembly)
  - D: [8] Blazor basics
       File -> New standalone (or have one already ready to go)
       See Counter and FetchData code
       Highlight concepts: components, @page, markup, event handlers with C# methods
        - Arbitrary .NET code: Add "total degrees" (@forecasts?.Sum(f => f.TemperatureC))
          Make TemperatureC into <input type="number" @bind="@forecast.TemperatureC" />
          Change TemperatureF to => TemperatureC*2 + 30
        - So now you also know @bind
  - S: [2] WASM + Mono + .NET + Blazor 
  - D: [2] Network trace
  - D: [1] WASM bytecode in "Sources" tab
  - D: [4] Debugging C# in browser
       - First on OnInitAsync in FetchData
       - Then put breakpoint in markup on @forecasts?.Sum...
         Improvement: can now inspect properties of WeatherForecast
[25] Demo new features via "mission control" app
    - [1] S: Features we'll cover
    - [2] Starting point
        - Already fetches and renders list of agents (same as WeatherForecast)
        - Uses Material Design components library (will explain how component libraries are created later)
        - ... but has no auth yet
    - [6] Demo AUTH
        - Enable auth on server; see it starts rejecting requests
        - Use <AuthorizeView> to ask use to log in
        - Add login screen that gets token from backend
    - [4] Demo VALIDATION
        - Add validation to the login form
    - [6] Demo LIBRARIES and STATIC CONTENT
        - Add library project with some map.js; see it can now be loaded via script tag
        - See @using to resolve namespaces for components
    - [5] Demo GENERIC TEMPLATED COMPONENTS and USINGS FOR COMPONENTS
        - Add your own PinMap.razor (PinMap<TPin> where TPin = TreasureSite)
        - Replace the grid with a map
        - Display pin info on click via template
[24] Full-spectrum programming model
  - S: [3] Server-side and client-side execution, inc pros/cons
  - [7] CarBuyer as server-side app
    - [2] See app
    - [2] See network (smaller app, websocket connection for events)
    - [3] Add prerendering
  - S: [1] Full spectrum
  - [3] CarBuyer as client-side WASM app
    - [1] See it running
    - [2] Add offline support
  - [2] CarBuyer as PWA
  - [2] CarBuyer in Electron shell
  - [6] Blutter
    - [3] See app and code
    - [3] Add "Delete" to todo list
[2] S: Summary

Total: 69 mins
