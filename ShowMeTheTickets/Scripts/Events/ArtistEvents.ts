/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/jquery.blockui/jquery.blockui.d.ts" />

module ArtistEvents {
    export function GetTickets(eventId: number) {
        var $ticketsContainer = $('#EventsAndTicketsContainer');
        $ticketsContainer.block({ message: null });
        
        $.ajax({
            url: '/Search/GetEventTickets/',
            type: 'GET',
            data: { eventId: eventId },
            dataType: 'html',
            success: DisplayEventTickets,
            error: ShowAjaxError,
            complete: () => $ticketsContainer.unblock()
        });
    }

    function DisplayEventTickets(data) {
        $('#TicketsContainer').html(data)
    }

    function ShowAjaxError(jqXHR: any, textStatus: any, errorThrown: any) {
        alert(jqXHR + ' ' + textStatus + ' ' + errorThrown);
    }
}