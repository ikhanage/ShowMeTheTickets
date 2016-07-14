/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/jquery.blockui/jquery.blockui.d.ts" />
/// <reference path="../typings/knockout/knockout.d.ts" />

module SearchForArtists {
    var searchBindings;
    
    export function SetBindings() {
        searchBindings = new Bindings();
        ko.applyBindings(searchBindings);
    }

    export function Search() {
        $('#ResultsContainer').remove();
        var $searchContainer = $('#ArtistSearchContainer');

        $searchContainer.block({message: 'Searching for artists. Please wait.'});
        $.ajax({
            url: '/Search/ArtistSearchResults/',
            type: 'GET',
            data: { artistName: searchBindings.Artist() },
            dataType: 'html',
            success: DisplayArtistSearchResults,
            error: function ShowAjaxError(jqXHR: any, textStatus: any, errorThrown: any) {
                alert(jqXHR + ' ' + textStatus + ' ' + errorThrown);
            },
            complete: () => $searchContainer.unblock()
        });
    }

    export function SelectArtist(artist: string) {
        var $searchContainer = $('#ArtistSearchContainer');
        var $artistsResultsContainer = $('#ResultsContainer');

        $artistsResultsContainer.block({ message: 'Searching for events.' });
        $searchContainer.block({ message: null });

        $.ajax({
            url: '/Search/GetArtist/',
            type: 'GET',
            data: { artistTitle: artist },
            dataType: 'json',
            success: () => alert('happy'),
            error: () => alert(),
            complete: function () {
                $searchContainer.unblock();
                $artistsResultsContainer.unblock();
            }
        });
    }

    function ShowAjaxError(jqXHR: any, textStatus: any, errorThrown: any) {
        alert(jqXHR + ' ' + textStatus + ' ' + errorThrown);
    }
    function DisplayArtistSearchResults(data) {
        $('#ArtistSearchContainer').append(data);
    }

    function Bindings() {
        this.Artist = ko.observable();
    }
}