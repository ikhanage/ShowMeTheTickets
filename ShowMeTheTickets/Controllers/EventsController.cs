using GogoKit.Models.Response;
using ShowMeTheTickets.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> GetArtistEvents(string artistTitle, string dateFrom)
        {
            var artists = (IEnumerable<SearchResult>)Session[Constants.Session.ArtistSearchResultsKey];

            var artist = artists.FirstOrDefault(x => x.Title == artistTitle);

            IEnumerable<Event> events;
            if(artist.Type == "Event")
            {
                events = await _eventsHelper.GetEventsFromEvent(artist.EventLink, dateFrom);
            }
            else
            {
                events = await _eventsHelper.GetEventsFromCategory(artist.CategoryLink, dateFrom);
            }
            

            return PartialView("~/Views/Events/ArtistEvents.cshtml", events);
        }
    }
}