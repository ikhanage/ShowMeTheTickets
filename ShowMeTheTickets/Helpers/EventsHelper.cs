using GogoKit.Models.Response;
using HalKit.Models.Response;
using ShowMeTheTickets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ShowMeTheTickets.Helpers
{
    public class EventsHelper : IEventsHelper
    {
        private readonly IViaGoGoHelper _viaGoGoHelper;
        public EventsHelper(IViaGoGoHelper viaGoGoHelper)
        {
            _viaGoGoHelper = viaGoGoHelper;
        }
        public async Task<IEnumerable<Event>> GetEvents(Link categoryLink, string dateFrom)
        {
            var category = await _viaGoGoHelper.GetCategories(categoryLink);
            var events = await _viaGoGoHelper.GetEvents(category.Id.Value);

            return EventsGroupByCountrySortByPrice(FilterEventsByDate(events, dateFrom));
        }

        public IEnumerable<Event> EventsGroupByCountrySortByPrice(IEnumerable<Event> events)
        {
            events = events.Where(x => 
                x.Venue != null && x.Venue.Country != null &&
                x.MinTicketPrice != null && x.MinTicketPrice.Amount != null
            ).ToList();

            return events.OrderBy(x => x.Venue.Country.Code)
                .ThenBy(x => x.MinTicketPrice.Amount)
                .ToList();
        }

        private IEnumerable<Event> FilterEventsByDate(IEnumerable<Event> events, string dateFrom)
        {
            if (string.IsNullOrWhiteSpace(dateFrom))
                return events;

            DateTime dateTimeFrom;
            var validDate = DateTime.TryParse(dateFrom, out dateTimeFrom);

            if (!validDate)
                return events;

            return events.Where(x =>
                x.StartDate != null && x.StartDate.HasValue &&
                x.StartDate.Value >= dateTimeFrom
            );
        }
    }
}