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

        $.blockUI();
        $.ajax({
            url: '/Search/ArtistSearchResults/',
            type: 'GET',
            data: { artistName: searchBindings.Artist() },
            dataType: 'html',
            success: DisplayArtistSearchResults,
            error: function ShowAjaxError(jqXHR: any, textStatus: any, errorThrown: any) {
                alert(jqXHR + ' ' + textStatus + ' ' + errorThrown);
            },
            complete: () => $.unblockUI()
        });
    }

    export function SelectArtist(artist: string) {
        $.ajax({
            url: '/Search/GetArtist/',
            type: 'GET',
            data: { artistTitle: artist },
            dataType: 'json',
            success: () => alert('happy'),
            error: () => alert()
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