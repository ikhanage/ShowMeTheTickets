using GogoKit.Models.Response;
using HalKit.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShowMeTheTickets.Interfaces
{
    public interface IEventsHelper
    {
        Task<IEnumerable<Event>> GetEventsFromCategory(Link categoryLink, string dateFrom);
        IEnumerable<Event> EventsGroupByCountrySortByPrice(IEnumerable<Event> events);
        Task<IEnumerable<Event>> GetEventsFromEvent(Link eventLink, string dateFrom);
    }
}
