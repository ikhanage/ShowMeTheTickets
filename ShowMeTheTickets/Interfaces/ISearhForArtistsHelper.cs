using GogoKit.Models.Response;
using HalKit.Models.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowMeTheTickets.Interfaces
{
    public interface ISearchForArtistsHelper
    {
        Task<IEnumerable<SearchResult>> GetSearchResults(string query);
        Task<IEnumerable<Event>> GetEvents(Link categoryLink);
        IEnumerable<Event> EventsGroupByCountrySortByPrice(IReadOnlyList<Event> events);
        Task<IReadOnlyList<Listing>> GetEventTickets(int eventId);
    }
}
