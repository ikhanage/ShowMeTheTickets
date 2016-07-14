using GogoKit.Models.Response;
using ShowMeTheTickets.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShowMeTheTickets.Controllers
{
    public class SearchController : Controller
    {
        private readonly string ArtistSearchResultsKey = "ArtistSearchResultsKey";
        private readonly ISearchForArtistsHelper _searhForArtistsHelper;
        public SearchController(ISearchForArtistsHelper searchForArtistHelper)
        {
            _searhForArtistsHelper = searchForArtistHelper;
        }
        
        [HttpGet]
        public async Task<ActionResult> ArtistSearchResults(string artistName)
        {
            var artists = await _searhForArtistsHelper.GetSearchResults(artistName);

            Session.Add(ArtistSearchResultsKey, artists);

            return PartialView("~/Views/Search/ArtistResults.cshtml", artists.ToList());
        }

        [HttpGet]
        public async Task<ActionResult> GetArtist(string artistTitle)
        {
            var artists = (IEnumerable<SearchResult>) Session[ArtistSearchResultsKey];

            var link = artists.FirstOrDefault(x => x.Title == artistTitle).CategoryLink;

            var events = await _searhForArtistsHelper.GetEvents(link);

            return PartialView("~/Views/Events/ArtistEvents.cshtml", events);
        }
    }
}