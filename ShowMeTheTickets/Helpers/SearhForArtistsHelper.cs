using ShowMeTheTickets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GogoKit.Models.Response;
using System.Threading.Tasks;
using MoreLinq;

namespace ShowMeTheTickets.Helpers
{
    public class SearhForArtistsHelper : ISearhForArtistsHelper
    {
        private readonly IViaGoGoHelper _viaGoGoHelper;
        public SearhForArtistsHelper(IViaGoGoHelper viaGoGoHelper)
        {
            _viaGoGoHelper = viaGoGoHelper;
        }
        public async Task<IEnumerable<SearchResult>> GetSearchResults(string query)
        {
            var artists = await _viaGoGoHelper.GetSearchResults(query);

            return artists.Items.DistinctBy(x => x.Title).OrderBy(x => x.Category);
        }
    }
}