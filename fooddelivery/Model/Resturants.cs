using System.ComponentModel.DataAnnotations;

namespace fooddelivery.Model
{
    public class Resturants{
        public Resturants()
        {
            fooditems = new HashSet<Fooditems>();
        }

        [Key]
        public int Resturant_Id { get; set; }
        [Required]
        public string? Resturant_Name { get; set; }
        public string? Resturant_Location { get; set; }

        public int? Customer_Id { get; set; }
        public virtual Customers? Customer { get; set; }

        public virtual ICollection<Fooditems> fooditems { get; set; }

        

    }
}
