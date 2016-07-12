using GogoKit;
using ShowMeTheTickets.Interfaces;
using System.Threading.Tasks;

namespace ShowMeTheTickets.Helpers
{
    public class ViaGoGoHelper :ViaGoGoBase, IViaGoGoHelper
    {
        public async Task GetSearchResults()
        {
            await SetUpClient();
            var searchResults = await ViagogoClient.Search.GetAsync("FC Barcelona tickets");
        }
    }
}