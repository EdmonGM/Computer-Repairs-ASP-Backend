using Computer_Repairs.Dtos.Ticket;
using Computer_Repairs.Interfaces;
using Computer_Repairs.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Computer_Repairs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController(ITicketRepo ticketRepo, IUserRepo userRepo) : ControllerBase
    {
        private readonly ITicketRepo _ticketRepo = ticketRepo;
        private readonly IUserRepo _userRepo = userRepo;


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
        [HttpPost]
        public async Task<IActionResult> CreateTicket(int userId, CreateTicketDto ticketDto)
        {
            if(!await _userRepo.UserExsits(userId))
            {
                return BadRequest("User does NOT exist!");
            }
            var ticketModel = ticketDto.ToTicketFromCreateDto(userId);
            await _ticketRepo.CreateAsync(ticketModel);
            return CreatedAtAction(nameof(GetTicket),new {id = ticketModel}, ticketModel.ToTicketDto());   
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] int id)
        {
            var ticket = await _ticketRepo.DeleteAsync(id);
            if( ticket == null)
            {
                return NotFound("No ticket found with the given id");
            }
            return NoContent();
        }
    }
}
