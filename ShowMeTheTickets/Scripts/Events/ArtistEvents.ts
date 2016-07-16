/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/jquery.blockui/jquery.blockui.d.ts" />

module ArtistEvents {
    export function GetTickets(eventId: number) {
        var $ticketsContainer = $('#EventsAndTicketsContainer');
        $ticketsContainer.block({ message: null });
        
        $.ajax({
            url: '/Tickets/GetEventTickets/',
            type: 'GET',
            data: { eventId: eventId },
            dataType: 'html',
            success: DisplayEventTickets,
            error: ShowAjaxError,
            complete: () => $ticketsContainer.unblock()
        });
    }

    export function GetNextPage() {
        var currentPage = SearchForArtists.searchBindings.Page();

        if (currentPage == 0)
            currentPage = 1;

        var pageIncrement: number = currentPage + 1;
        SearchForArtists.searchBindings.Page(pageIncrement)
        GetPageOfResults(pageIncrement);
    }

    export function GetPrevPage() {
        var pageIncrement: number = SearchForArtists.searchBindings.Page() - 1;
        if (pageIncrement < 1) {
            SearchForArtists.searchBindings.Page(1);
            pageIncrement = 1;
        }
        SearchForArtists.searchBindings.Page(pageIncrement)
        GetPageOfResults(pageIncrement);
    }

    export function GetPageOfResults(pageNumber: number) {
        $('.ticketRow').hide();
        $('.countryRow').hide();
        var $displayRows = $('.ticketRow[data-page="' + pageNumber + '"]');
        $displayRows.show();

        $displayRows.each(function () {
            var countryDisplayCode = $(this).data('country');
            $('.countryRow[data-country="' + countryDisplayCode + '"]').show();
        });

        $('#NextEventsPage').toggle($('.ticketRow[data-page="' + (pageNumber + 1) + '"]').length > 0);
        $('#PrevEventsPage').toggle(pageNumber > 1);

        $('#TicketsContainer').html('');
    }

    function DisplayEventTickets(data) {
        $('#TicketsContainer').html(data)
    }

    function ShowAjaxError(jqXHR: any, textStatus: any, errorThrown: any) {
        alert(jqXHR + ' ' + textStatus + ' ' + errorThrown);
    }
}