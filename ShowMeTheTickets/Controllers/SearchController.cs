using ShowMeTheTickets.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShowMeTheTickets.Controllers
{
    public class SearchController : Controller
    {        
        private readonly ISearchForArtistsHelper _searhForArtistsHelper;
        public SearchController(ISearchForArtistsHelper searchForArtistHelper)
        {
            _searhForArtistsHelper = searchForArtistHelper;
        }
        
        [HttpGet]
        public async Task<ActionResult> ArtistSearchResults(string artistName)
        {
            var artists = await _searhForArtistsHelper.GetSearchResults(artistName);

            Session.Add(Constants.Session.ArtistSearchResultsKey, artists);

            return PartialView("~/Views/Search/ArtistResults.cshtml", artists.ToList());
        }               
    }
}