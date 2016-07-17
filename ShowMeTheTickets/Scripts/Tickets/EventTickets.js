/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/knockout/knockout.d.ts" />
var EventTickets;
(function (EventTickets) {
    function GetNextPage() {
        var currentPage = SearchForArtists.searchBindings.TicketPage();
        if (currentPage == 0)
            currentPage = 1;
        var pageIncrement = currentPage + 1;
        SearchForArtists.searchBindings.TicketPage(pageIncrement);
        GetPageOfResults(pageIncrement);
    }
    EventTickets.GetNextPage = GetNextPage;
    function GetPrevPage() {
        var pageIncrement = SearchForArtists.searchBindings.TicketPage() - 1;
        if (pageIncrement < 1) {
            SearchForArtists.searchBindings.TicketPage(1);
            pageIncrement = 1;
        }
        SearchForArtists.searchBindings.TicketPage(pageIncrement);
        GetPageOfResults(pageIncrement);
    }
    EventTickets.GetPrevPage = GetPrevPage;
    function GetPageOfResults(pageNumber) {
        $('.ticketRow').hide();
        var $displayRows = $('.ticketRow[data-ticketpage="' + pageNumber + '"]');
        $displayRows.show();
        $('#NextTicketsPage').toggle($('.ticketRow[data-ticketpage="' + (pageNumber + 1) + '"]').length > 0);
        $('#PrevTicketsPage').toggle(pageNumber > 1);
    }
    EventTickets.GetPageOfResults = GetPageOfResults;
})(EventTickets || (EventTickets = {}));
