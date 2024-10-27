using E_Commerce.Models;
namespace E_Commerce.Repositories.Interfaces
{
    public interface ITikectsSoporte
    {
        Task<List<TicketsSoporte>> GetTicketsSoporte();
        Task<bool> PostTicketsSoporte(TicketsSoporte ticketsSoporte);
    }
}
