using GogoKit.Models.Response;
using ShowMeTheTickets.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowMeTheTickets.Helpers
{
    public class TicketsHelper: ITicketsHelper
    {
        private readonly IViaGoGoHelper _viaGoGoHelper;
        public TicketsHelper(IViaGoGoHelper viaGoGoHelper)
        {
            _viaGoGoHelper = viaGoGoHelper;
        }
        public async Task<IReadOnlyList<Listing>> GetEventTickets(int eventId, int minTickets)
        {
            var tickets = await _viaGoGoHelper.GetEventTickets(eventId);

            if (tickets == null)
                return new List<Listing>();

            if (minTickets > 0)
                tickets = FilterTickets(tickets, minTickets);

            return tickets.OrderBy(x => x.TicketPrice.Amount).ToList();
        }

        private IReadOnlyList<Listing> FilterTickets(IEnumerable<Listing> tickets, int minTickets)
        {
            return tickets.Where(x => x.NumberOfTickets != null && x.NumberOfTickets >= minTickets).ToList();
        }
    }
}