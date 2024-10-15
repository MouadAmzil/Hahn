using Hahn_Task.Contract;
using System.ComponentModel.DataAnnotations;

namespace Hahn_Task.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [Required]
        public string Description { get; set; } =string.Empty;

        [EnumDataType(typeof(TicketStatus))]
        public TicketStatus Status { get; set; }

        public DateTime Date { get; set; }
    }
}
