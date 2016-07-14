/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/jquery.blockui/jquery.blockui.d.ts" />
/// <reference path="../typings/knockout/knockout.d.ts" />

module ArtistEvents {
    var eventsBindings;

    export function SetBindings() {
        eventsBindings = new Bindings();
        ko.applyBindings(eventsBindings);
    }

    function Bindings() {
        
    }
}