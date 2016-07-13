using GogoKit.Models.Response;
using HalKit.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShowMeTheTickets.Interfaces
{
    public interface ISearhForArtistsHelper
    {
        Task<IEnumerable<SearchResult>> GetSearchResults(string query);
        Task<IReadOnlyList<Event>> GetEvents(Link categoryLink);
    }
}
