using GogoKit;
using GogoKit.Models.Request;
using GogoKit.Models.Response;
using HalKit.Models.Response;
using ShowMeTheTickets.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShowMeTheTickets.Helpers
{
    public class ViaGoGoHelper :ViaGoGoBase, IViaGoGoHelper
    {
        public async Task<PagedResource<SearchResult>> GetSearchResults(string query)
        {
            await SetUpClient();
            var searchResults = await ViagogoClient.Search.GetAsync(query);
            return  searchResults;
        }

        public async Task<Category> GetCategories(Link categoryLink)
        {
            await SetUpClient();
            var category = await ViagogoClient.Hypermedia.GetAsync<Category>(categoryLink);
            return category;
        }

        public async Task<IReadOnlyList<Event>> GetEvents(int categoryId)
        {
            await SetUpClient();
            var events = await ViagogoClient.Events.GetAllByCategoryAsync(categoryId);
            return events;
        }
    }
}