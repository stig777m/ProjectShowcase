using BussinessLogicLayer.DTOs;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace BussinessLogicLayer.Services
{
    public class TicketRepositories : ITicketServices
    {
        private readonly ITicketRepositories _repositories;
        public TicketRepositories(ITicketRepositories repositories)
        {
            _repositories = repositories;
        }

        public async Task<bool> UpdateStatus(string id, string status)
        {
            return await _repositories.UpdateStatus(id, status);
        }

        public async Task<TicketDTO> CreateTicket(TicketDTO ticket)
        {
            return await _repositories.CreateTicket((Ticket)ticket);
        }
    }
}
