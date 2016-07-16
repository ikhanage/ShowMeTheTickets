using GogoKit.Models.Response;
using HalKit.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShowMeTheTickets.Interfaces
{
    public interface IEventsHelper
    {
        Task<IEnumerable<Event>> GetEvents(Link categoryLink);
        IEnumerable<Event> EventsGroupByCountrySortByPrice(IReadOnlyList<Event> events);
    }
}
