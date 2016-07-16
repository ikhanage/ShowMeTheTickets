using GogoKit.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShowMeTheTickets.Interfaces
{
    public interface ISearchForArtistsHelper
    {
        Task<IEnumerable<SearchResult>> GetSearchResults(string query);        
    }
}
