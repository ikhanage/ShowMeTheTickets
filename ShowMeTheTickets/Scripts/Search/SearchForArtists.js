/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/jquery.blockui/jquery.blockui.d.ts" />
/// <reference path="../typings/knockout/knockout.d.ts" />
var SearchForArtists;
(function (SearchForArtists) {
    var searchBindings;
    function SetBindings() {
        searchBindings = new Bindings();
        ko.applyBindings(searchBindings);
    }
    SearchForArtists.SetBindings = SetBindings;
    function Search() {
        $('#ResultsContainer').remove();
        var $searchContainer = $('#ArtistSearchContainer');
        $searchContainer.block({ message: 'Searching for artists. Please wait.' });
        $.ajax({
            url: '/Search/ArtistSearchResults/',
            type: 'GET',
            data: { artistName: searchBindings.Artist() },
            dataType: 'html',
            success: DisplayArtistSearchResults,
            error: function ShowAjaxError(jqXHR, textStatus, errorThrown) {
                alert(jqXHR + ' ' + textStatus + ' ' + errorThrown);
            },
            complete: function () { return $searchContainer.unblock(); }
        });
    }
    SearchForArtists.Search = Search;
    function SelectArtist(artist) {
        var $searchContainer = $('#ArtistSearchContainer');
        var $artistsResultsContainer = $('#ResultsContainer');
        $artistsResultsContainer.block({ message: 'Searching for events.' });
        $searchContainer.block({ message: null });
        $.ajax({
            url: '/Search/GetArtist/',
            type: 'GET',
            data: { artistTitle: artist },
            dataType: 'json',
            success: function () { return alert('happy'); },
            error: function () { return alert(); },
            complete: function () {
                $searchContainer.unblock();
                $artistsResultsContainer.unblock();
            }
        });
    }
    SearchForArtists.SelectArtist = SelectArtist;
    function ShowAjaxError(jqXHR, textStatus, errorThrown) {
        alert(jqXHR + ' ' + textStatus + ' ' + errorThrown);
    }
    function DisplayArtistSearchResults(data) {
        $('#ArtistSearchContainer').append(data);
    }
    function Bindings() {
        this.Artist = ko.observable();
    }
})(SearchForArtists || (SearchForArtists = {}));
//# sourceMappingURL=SearchForArtists.js.map