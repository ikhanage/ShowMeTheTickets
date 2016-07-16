using GogoKit.Models.Response;
using ShowMeTheTickets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ShowMeTheTickets.Helpers
{
    public class TicketsHelper: ITicketsHelper
    {
        private readonly IViaGoGoHelper _viaGoGoHelper;
        public TicketsHelper(IViaGoGoHelper viaGoGoHelper)
        {
            _viaGoGoHelper = viaGoGoHelper;
        }
        public async Task<IReadOnlyList<Listing>> GetEventTickets(int eventId)
        {
            var tickets = await _viaGoGoHelper.GetEventTickets(eventId);
            return tickets.OrderBy(x => x.TicketPrice.Amount).ToList();
        }
    }
}