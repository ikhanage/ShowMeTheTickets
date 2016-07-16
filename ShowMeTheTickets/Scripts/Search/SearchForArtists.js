/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/jquery.blockui/jquery.blockui.d.ts" />
/// <reference path="../typings/knockout/knockout.d.ts" />
var SearchForArtists;
(function (SearchForArtists) {
    function SetBindings() {
        SearchForArtists.searchBindings = new Bindings();
        ko.applyBindings(SearchForArtists.searchBindings);
    }
    SearchForArtists.SetBindings = SetBindings;
    function Search() {
        if (!SearchForArtists.searchBindings.Artist() || SearchForArtists.searchBindings.Artist() == '')
            return alert('Please enter a search term.');
        $('#ResultsContainer').remove();
        var $searchContainer = $('#ArtistSearchContainer');
        SearchForArtists.searchBindings.Page(0);
        $searchContainer.block({ message: 'Searching for artists. Please wait.' });
        $.ajax({
            url: '/Search/ArtistSearchResults/',
            type: 'GET',
            data: { artistName: SearchForArtists.searchBindings.Artist() },
            dataType: 'html',
            success: DisplayArtistSearchResults,
            error: function () { return alert('An error has occurred when looking for the artists "' + SearchForArtists.searchBindings.Artists() + '".'); },
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
            url: '/Events/GetArtistEvents/',
            type: 'GET',
            data: { artistTitle: artist },
            dataType: 'html',
            success: SelectedArtistEvents,
            error: ShowAjaxError,
            complete: function () {
                $searchContainer.unblock();
                $artistsResultsContainer.unblock();
            }
        });
    }
    SearchForArtists.SelectArtist = SelectArtist;
    function SelectedArtistEvents(data) {
        $('#ResultsContainer').remove();
        $('#ArtistSearchContainer').append(data);
    }
    function ShowAjaxError(jqXHR, textStatus, errorThrown) {
        alert(jqXHR + ' ' + textStatus + ' ' + errorThrown);
    }
    function DisplayArtistSearchResults(data) {
        $('#EventsAndTicketsContainer').remove();
        $('#ArtistSearchContainer').append(data);
    }
    function Bindings() {
        this.Artist = ko.observable();
        this.Page = ko.observable(1);
        this.ShowPrev = ko.observable(false);
    }
})(SearchForArtists || (SearchForArtists = {}));
