using Computer_Repairs.Interfaces;
using Computer_Repairs.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Computer_Repairs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController(ITicketRepo ticketRepo) : ControllerBase
    {
        private readonly ITicketRepo _ticketRepo = ticketRepo;

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _ticketRepo.GetAllAsync();

            var ticketDto = tickets.Select(s => s.ToTicketDto());

            return Ok(ticketDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var ticket = await _ticketRepo.GetByIdAsync(id);
            if(ticket == null)
            {
                return NotFound("No ticket found with the given id");
            }
            return Ok(ticket.ToTicketDto());
        }
    }
}
