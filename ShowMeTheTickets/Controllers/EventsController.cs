using GogoKit.Models.Response;
using ShowMeTheTickets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShowMeTheTickets.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventsHelper _eventsHelper;
        public EventsController(IEventsHelper eventsHelper)
        {
            _eventsHelper = eventsHelper;
        }

        [HttpGet]
        public async Task<ActionResult> GetArtistEvents(string artistTitle)
        {
            var artists = (IEnumerable<SearchResult>)Session[Constants.Session.ArtistSearchResultsKey];

            var link = artists.FirstOrDefault(x => x.Title == artistTitle).CategoryLink;

            var events = await _eventsHelper.GetEvents(link);

            return PartialView("~/Views/Events/ArtistEvents.cshtml", events);
        }
    }
}