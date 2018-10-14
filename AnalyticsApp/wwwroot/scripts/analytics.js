(function () {
    var EventTypes;
    (function (EventTypes) {
        EventTypes[EventTypes["Unknown"] = 0] = "Unknown";
        EventTypes[EventTypes["Pageload"] = 1] = "Pageload";
        EventTypes[EventTypes["Custom"] = 2] = "Custom";
    })(EventTypes || (EventTypes = {}));
    var PlatformTypes;
    (function (PlatformTypes) {
        PlatformTypes[PlatformTypes["Unknown"] = 0] = "Unknown";
        PlatformTypes[PlatformTypes["Windows"] = 1] = "Windows";
        PlatformTypes[PlatformTypes["Mac"] = 2] = "Mac";
        PlatformTypes[PlatformTypes["Linux"] = 3] = "Linux";
        PlatformTypes[PlatformTypes["Android"] = 4] = "Android";
        PlatformTypes[PlatformTypes["iOS"] = 5] = "iOS";
    })(PlatformTypes || (PlatformTypes = {}));
    var BrowserTypes;
    (function (BrowserTypes) {
        BrowserTypes[BrowserTypes["Unknown"] = 0] = "Unknown";
        BrowserTypes[BrowserTypes["IE"] = 1] = "IE";
        BrowserTypes[BrowserTypes["Edge"] = 2] = "Edge";
        BrowserTypes[BrowserTypes["Chrome"] = 3] = "Chrome";
        BrowserTypes[BrowserTypes["Safari"] = 4] = "Safari";
        BrowserTypes[BrowserTypes["Opera"] = 5] = "Opera";
        BrowserTypes[BrowserTypes["Firefox"] = 6] = "Firefox";
    })(BrowserTypes || (BrowserTypes = {}));
    var TrackEvent = /** @class */ (function () {
        function TrackEvent(Type) {
            this.URL = window.location.href;
            this.Path = window.location.pathname;
            this.UserAgent = window.navigator.userAgent;
            this.Type = Type;
            this.Platorm = discoverPlatform();
            this.Browser = discoverBrowser();
        }
        return TrackEvent;
    }());
    var trackingCode = window['_ATC'];
    var apiUrl = 'https://localhost:44399/api/events/' + trackingCode;
    createEvent(EventTypes.Pageload);
    function createEvent(Type) {
        var trackEvent = new TrackEvent(Type);
        var xhr = new XMLHttpRequest();
        var json = JSON.stringify(trackEvent);
        xhr.open('POST', apiUrl, true);
        xhr.setRequestHeader('Content-type', 'application/json');
        xhr.send(json);
    }
    function discoverBrowser() {
        var userAgent = window.navigator.userAgent;
        var type = BrowserTypes.Unknown;
        if (userAgent.indexOf('Chrome/') > -1 || userAgent.indexOf('Chromium/') > -1)
            type = BrowserTypes.Chrome;
        else if (userAgent.indexOf('Firefox/') > -1)
            type = BrowserTypes.Firefox;
        else if (userAgent.indexOf('Safari/') > -1)
            type = BrowserTypes.Safari;
        else if (userAgent.indexOf('Opera/') > -1)
            type = BrowserTypes.Opera;
        else if (userAgent.indexOf('Edge/') > -1)
            type = BrowserTypes.Edge;
        else if (userAgent.indexOf('MSIE') > -1)
            type = BrowserTypes.IE;
        return type;
    }
    function discoverPlatform() {
        var userAgent = navigator.userAgent;
        var type = PlatformTypes.Unknown;
        if (userAgent.indexOf('Windows NT') > -1)
            type = PlatformTypes.Windows;
        else if (userAgent.indexOf('Macintosh') > -1)
            type = PlatformTypes.Mac;
        else if (userAgent.indexOf('Android') > -1)
            type = PlatformTypes.Android;
        else if (userAgent.indexOf('iPhone') > -1 || userAgent.indexOf('iPad') > -1)
            type = PlatformTypes.iOS;
        else if (userAgent.indexOf('Linux') > -1)
            type = PlatformTypes.iOS;
        return type;
    }
})();
