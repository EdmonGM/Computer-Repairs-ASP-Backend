namespace Computer_Repairs.Dtos.Ticket
{
    public class TicketDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
        public string Status { get; set; } = "open";
    }
}
