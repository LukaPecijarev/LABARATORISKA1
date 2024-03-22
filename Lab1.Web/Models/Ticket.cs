using System.ComponentModel.DataAnnotations;

namespace Lab1.Web.Models
{
    public class Ticket
    {
        [Key] 
        public Guid Id { get; set; }
        public double ? Price { get; set; }
        public User ? Owner { get; set; }
        public TheatreShow ? theatreShow { get; set; }
    }
}
