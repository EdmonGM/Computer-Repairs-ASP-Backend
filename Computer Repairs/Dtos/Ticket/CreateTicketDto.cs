namespace Computer_Repairs.Dtos.Ticket
{
    public class CreateTicketDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "open";
    }
}
