using GogoKit.Models.Response;
using HalKit.Models.Response;
using System.Threading.Tasks;

namespace ShowMeTheTickets.Interfaces
{
    public interface IViaGoGoHelper
    {
        Task<PagedResource<SearchResult>> GetSearchResults(string query);
        Task<Category> GetCategories(Link categoryLink);
    }
}
