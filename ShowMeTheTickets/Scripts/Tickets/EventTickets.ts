/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/knockout/knockout.d.ts" />

module EventTickets{
    export function GetNextPage() {
        var currentPage = SearchForArtists.searchBindings.TicketPage();

        if (currentPage == 0)
            currentPage = 1;

        var pageIncrement: number = currentPage + 1;
        SearchForArtists.searchBindings.TicketPage(pageIncrement)
        GetPageOfResults(pageIncrement);
    }

    export function GetPrevPage() {
        var pageIncrement: number = SearchForArtists.searchBindings.TicketPage() - 1;
        if (pageIncrement < 1) {
            SearchForArtists.searchBindings.TicketPage(1);
            pageIncrement = 1;
        }
        SearchForArtists.searchBindings.TicketPage(pageIncrement)
        GetPageOfResults(pageIncrement);
    }

    export function GetPageOfResults(pageNumber: number) {
        $('.ticketRow').hide();
        var $displayRows = $('.ticketRow[data-ticketpage="' + pageNumber + '"]');
        $displayRows.show();

        $('#NextTicketsPage').toggle($('.ticketRow[data-ticketpage="' + (pageNumber + 1) + '"]').length > 0);
        $('#PrevTicketsPage').toggle(pageNumber > 1);
    }
}