using System.ComponentModel.DataAnnotations;

namespace Lab1.Web.Models
{
    public class TheatreShow
    {
        [Key]
        public Guid Id { get; set; }
        public string ? Title { get; set; }
        public string ? Description { get; set; }
        public string ? Place { get; set; }
        public DateTime ? ShowDate { get; set; }
        public string ? ImageURL { get; set; }
        public virtual ICollection<Ticket> ? Tickets { get; set; }
    }
}
