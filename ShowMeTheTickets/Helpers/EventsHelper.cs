using GogoKit.Models.Response;
using HalKit.Models.Response;
using ShowMeTheTickets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IEnumerable<Event> GetNext10Events(int page)
        {

            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetPrev10Events(int page)
        {
            throw new NotImplementedException();
        }
    }
}