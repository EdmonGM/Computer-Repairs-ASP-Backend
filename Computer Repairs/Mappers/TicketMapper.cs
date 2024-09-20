using Computer_Repairs.Dtos.Ticket;
using Computer_Repairs.Models;

namespace Computer_Repairs.Mappers
{
    public static class TicketMapper
    {
        public static TicketDto ToTicketDto(this Ticket ticketModel)
        {
            return new TicketDto
            {
                Id = ticketModel.Id,
                UserId = ticketModel.UserId,
                Title = ticketModel.Title,
                Description = ticketModel.Description,
                CreatedDate = ticketModel.CreatedDate,
                UpdatedDate = ticketModel.UpdatedDate,
                Status = ticketModel.Status,
            };
        }
        public static Ticket ToTicketFromCreateDto(this CreateTicketDto ticketDto, int userId)
        {
            return new Ticket
            {
                UserId = userId,
                Title = ticketDto.Title,
                Description = ticketDto.Description,
                Status = ticketDto.Status,
            };
        }
    }
}
