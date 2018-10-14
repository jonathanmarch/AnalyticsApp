(function () {

    enum EventTypes {
        Unknown,
        Pageload,
        Custom
    }

    enum PlatformTypes {
        Unknown,
        Windows,
        Mac,
        Linux,
        Android,
        iOS
    }

    enum BrowserTypes {
        Unknown,
        IE,
        Edge,
        Chrome,
        Safari,
        Opera,
        Firefox
    }

    class TrackEvent {
        Type: EventTypes;
        Platorm: PlatformTypes;
        Browser: BrowserTypes;
        URL: string = window.location.href;
        Path: string = window.location.pathname;
        UserAgent: string = window.navigator.userAgent;

        constructor(Type: EventTypes) {
            this.Type = Type;
            this.Platorm = discoverPlatform();
            this.Browser = discoverBrowser();
        }
    }

    const trackingCode = (window as any)['_ATC'];
    const apiUrl = 'https://localhost:44399/api/events/' + trackingCode;

    createEvent(EventTypes.Pageload);

    function createEvent(Type: EventTypes) {
        const trackEvent = new TrackEvent(Type);

        const xhr = new XMLHttpRequest();
        const json = JSON.stringify(trackEvent);

        xhr.open('POST', apiUrl, true);
        xhr.setRequestHeader('Content-type', 'application/json');
        xhr.send(json);
    }

    function discoverBrowser() {
        const userAgent = window.navigator.userAgent;
        let type = BrowserTypes.Unknown;

        if (userAgent.indexOf('Chrome/') > - 1 || userAgent.indexOf('Chromium/') > - 1) type = BrowserTypes.Chrome;
        else if (userAgent.indexOf('Firefox/') > - 1) type = BrowserTypes.Firefox;
        else if (userAgent.indexOf('Safari/') > - 1) type = BrowserTypes.Safari;
        else if (userAgent.indexOf('Opera/') > - 1) type = BrowserTypes.Opera;
        else if (userAgent.indexOf('Edge/') > - 1) type = BrowserTypes.Edge;
        else if (userAgent.indexOf('MSIE') > - 1) type = BrowserTypes.IE;

        return type;
    }

    function discoverPlatform() {
        const userAgent = navigator.userAgent;
        let type = PlatformTypes.Unknown;

        if (userAgent.indexOf('Windows NT') > - 1) type = PlatformTypes.Windows;
        else if (userAgent.indexOf('Macintosh') > - 1) type = PlatformTypes.Mac;
        else if (userAgent.indexOf('Android') > - 1) type = PlatformTypes.Android;
        else if (userAgent.indexOf('iPhone') > - 1 || userAgent.indexOf('iPad') > - 1) type = PlatformTypes.iOS;
        else if (userAgent.indexOf('Linux') > -1) type = PlatformTypes.iOS;

        return type;
    }

})();