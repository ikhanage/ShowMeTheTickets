using GogoKit.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowMeTheTickets.Interfaces
{
    public interface ITicketsHelper
    {
        Task<IReadOnlyList<Listing>> GetEventTickets(int eventId);
    }
}
