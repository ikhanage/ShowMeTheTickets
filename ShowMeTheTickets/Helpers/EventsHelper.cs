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
        public async Task<IEnumerable<Event>> GetEvents(Link categoryLink)
        {
            var category = await _viaGoGoHelper.GetCategories(categoryLink);
            var events = await _viaGoGoHelper.GetEvents(category.Id.Value);
            return EventsGroupByCountrySortByPrice(events);
        }

        public IEnumerable<Event> EventsGroupByCountrySortByPrice(IReadOnlyList<Event> events)
        {
            return events.OrderBy(x => x.Venue.Country.Code)
                .ThenBy(x => x.MinTicketPrice.Amount)
                .ToList();
        }

        public IEnumerable<Event> Get10Events(IEnumerable<Event> events, int page)
        {
            if (events == null) return new List<Event>();
            var skip = page * 10;

            if (skip >= events.Count())
                throw new IndexOutOfRangeException("Sorry but there are no more tickets to display.");

            return events.Skip(skip).Take(10);
        }
    }
}