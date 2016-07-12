/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/knockout/knockout.d.ts" />
var SearchForArtists;
(function (SearchForArtists) {
    function SetBindings() {
        ko.applyBindings(new Bindings());
    }
    SearchForArtists.SetBindings = SetBindings;
    function Bindings() {
        this.Artist = ko.observable();
    }
})(SearchForArtists || (SearchForArtists = {}));
//# sourceMappingURL=SearchForArtists.js.map