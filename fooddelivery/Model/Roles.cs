using System.ComponentModel.DataAnnotations;

namespace fooddelivery.Model
{
    public class Roles
    {
        public Roles(){

            customers = new HashSet<Customers>();
        }
        [Key]
        public int Role_Id { get; set; } 
        [Required]
        public string? Role { get; set; }

        public virtual ICollection<Customers> customers { get; set; }
    }
}
