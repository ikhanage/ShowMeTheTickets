using GogoKit.Models.Response;
using HalKit.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShowMeTheTickets.Interfaces
{
    public interface IViaGoGoHelper
    {
        Task<PagedResource<SearchResult>> GetSearchResults(string query);
        Task<Category> GetCategories(Link categoryLink);
        Task<IEnumerable<Event>> GetEvents(int categoryId);
        Task<IEnumerable<Listing>> GetEventTickets(int eventId);
        Task<Event> GetEventFromEventLink(Link eventLink);
    }
}
