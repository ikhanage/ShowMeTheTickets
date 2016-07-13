using ShowMeTheTickets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShowMeTheTickets.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearhForArtistsHelper _searhForArtistsHelper;
        public SearchController(ISearhForArtistsHelper searchForArtistHelper)
        {
            _searhForArtistsHelper = searchForArtistHelper;
        }
        
        [HttpGet]
        public async Task<ActionResult> ArtistSearchResults(string artistName)
        {
            var artists = await _searhForArtistsHelper.GetSearchResults(artistName);

            return PartialView("~/Views/Search/ArtistResults.cshtml", artists.ToList());
        }
    }
}