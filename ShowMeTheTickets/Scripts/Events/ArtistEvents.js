/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/jquery.blockui/jquery.blockui.d.ts" />
var ArtistEvents;
(function (ArtistEvents) {
    function GetTickets(eventId) {
        var $ticketsContainer = $('#EventsAndTicketsContainer');
        $ticketsContainer.block({ message: null });
        $.ajax({
            url: '/Tickets/GetEventTickets/',
            type: 'GET',
            data: { eventId: eventId, minTickets: SearchForArtists.searchBindings.MinTickets() },
            dataType: 'html',
            success: DisplayEventTickets,
            error: ShowAjaxError,
            complete: function () { return $ticketsContainer.unblock(); }
        });
    }
    ArtistEvents.GetTickets = GetTickets;
    function GetNextPage() {
        var currentPage = SearchForArtists.searchBindings.Page();
        if (currentPage == 0)
            currentPage = 1;
        var pageIncrement = currentPage + 1;
        SearchForArtists.searchBindings.Page(pageIncrement);
        GetPageOfResults(pageIncrement);
    }
    ArtistEvents.GetNextPage = GetNextPage;
    function GetPrevPage() {
        var pageIncrement = SearchForArtists.searchBindings.Page() - 1;
        if (pageIncrement < 1) {
            SearchForArtists.searchBindings.Page(1);
            pageIncrement = 1;
        }
        SearchForArtists.searchBindings.Page(pageIncrement);
        GetPageOfResults(pageIncrement);
    }
    ArtistEvents.GetPrevPage = GetPrevPage;
    function GetPageOfResults(pageNumber) {
        $('.ticketsRow').hide();
        $('.countryRow').hide();
        var $displayRows = $('.ticketsRow[data-page="' + pageNumber + '"]');
        $displayRows.show();
        $displayRows.each(function () {
            var countryDisplayCode = $(this).data('country');
            $('.countryRow[data-country="' + countryDisplayCode + '"]').show();
        });
        $('#NextEventsPage').toggle($('.ticketsRow[data-page="' + (pageNumber + 1) + '"]').length > 0);
        $('#PrevEventsPage').toggle(pageNumber > 1);
        $('#TicketsContainer').html('');
    }
    ArtistEvents.GetPageOfResults = GetPageOfResults;
    function DisplayEventTickets(data) {
        $('#TicketsContainer').html(data);
    }
    function ShowAjaxError(jqXHR, textStatus, errorThrown) {
        alert(jqXHR + ' ' + textStatus + ' ' + errorThrown);
    }
})(ArtistEvents || (ArtistEvents = {}));
//# sourceMappingURL=ArtistEvents.js.map