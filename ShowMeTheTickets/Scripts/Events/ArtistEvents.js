/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/jquery.blockui/jquery.blockui.d.ts" />
var ArtistEvents;
(function (ArtistEvents) {
    function GetTickets(eventId) {
        var $ticketsContainer = $('#EventsAndTicketsContainer');
        $ticketsContainer.block({ message: null });
        $.ajax({
            url: '/Search/GetEventTickets/',
            type: 'GET',
            data: { eventId: eventId },
            dataType: 'html',
            success: DisplayEventTickets,
            error: ShowAjaxError,
            complete: function () { return $ticketsContainer.unblock(); }
        });
    }
    ArtistEvents.GetTickets = GetTickets;
    function DisplayEventTickets(data) {
        $('#TicketsContainer').html(data);
    }
    function ShowAjaxError(jqXHR, textStatus, errorThrown) {
        alert(jqXHR + ' ' + textStatus + ' ' + errorThrown);
    }
})(ArtistEvents || (ArtistEvents = {}));
//# sourceMappingURL=ArtistEvents.js.map