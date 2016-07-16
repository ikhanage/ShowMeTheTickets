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
            error: () => alert('An error has occurred when looking for the artists "' + searchBindings.Artists() + '".'),
            complete: () => $searchContainer.unblock()
        });
    }

    export function SelectArtist(artist: string) {
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

    function SelectedArtistEvents(data) {
        $('#ResultsContainer').remove();
        $('#ArtistSearchContainer').append(data);
    }

    function ShowAjaxError(jqXHR: any, textStatus: any, errorThrown: any) {
        alert(jqXHR + ' ' + textStatus + ' ' + errorThrown);
    }
    function DisplayArtistSearchResults(data) {
        $('#EventsAndTicketsContainer').remove()
        $('#ArtistSearchContainer').append(data);
    }

    function Bindings() {
        this.Artist = ko.observable();
    }
}