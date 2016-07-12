/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/knockout/knockout.d.ts" />

module SearchForArtists {
    export function SetBindings() {
        ko.applyBindings(new Bindings());
    }

    function Bindings() {
        this.Artist = ko.observable();
    }
}