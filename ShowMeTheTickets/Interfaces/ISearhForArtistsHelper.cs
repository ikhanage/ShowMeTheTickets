using GogoKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowMeTheTickets.Interfaces
{
    public interface ISearhForArtistsHelper
    {
        Task<IEnumerable<SearchResult>> GetSearchResults(string query);
    }
}
