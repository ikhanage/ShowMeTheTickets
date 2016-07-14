/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/jquery.blockui/jquery.blockui.d.ts" />
/// <reference path="../typings/knockout/knockout.d.ts" />
var ArtistEvents;
(function (ArtistEvents) {
    var eventsBindings;
    function SetBindings() {
        eventsBindings = new Bindings();
        ko.applyBindings(eventsBindings);
    }
    ArtistEvents.SetBindings = SetBindings;
    function Bindings() {
    }
})(ArtistEvents || (ArtistEvents = {}));
//# sourceMappingURL=ArtistEvents.js.map