using GogoKit.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShowMeTheTickets.Interfaces
{
    public interface ITicketsHelper
    {
        Task<IReadOnlyList<Listing>> GetEventTickets(int eventId, int minTickets);
    }
}
