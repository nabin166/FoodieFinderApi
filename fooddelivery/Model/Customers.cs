using System.ComponentModel.DataAnnotations;

namespace fooddelivery.Model
{
    public class Customers
    {
        public Customers()
        {
            resturants = new HashSet<Resturants>();

            customerOrders = new HashSet<CustomerOrders>();

            deliveries = new HashSet<Deliveries>();
        }
        [Key]
        public int Customer_Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        [Required]
        public int? PhoneNumber { get; set; }
        [Required]
        public string? password { get; set; }
        [Required]
        public Boolean? Available { get; set; } = true;

        public int? Role_Id { get; set; }

        public virtual Roles? Role { get; set; }

        public virtual ICollection<Resturants> resturants { get; set; }

        public virtual ICollection<CustomerOrders> customerOrders { get; set; }

        public virtual ICollection<Deliveries> deliveries { get; set; }



    }
}
