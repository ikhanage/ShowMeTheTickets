using ShowMeTheTickets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShowMeTheTickets.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketsHelper _ticketsHelper;
        public TicketsController(ITicketsHelper ticketsHelper)
        {
            _ticketsHelper = ticketsHelper;
        }
        [HttpGet]
        public async Task<ActionResult> GetEventTickets(int eventId)
        {
            var tickets = await _ticketsHelper.GetEventTickets(eventId);

            Session.Add(Constants.Session.EventTicketsResultsKey, tickets);

            return PartialView("~/Views/Events/Tickets.cshtml", tickets);
        }
    }
}