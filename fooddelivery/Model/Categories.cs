using System.ComponentModel.DataAnnotations;

namespace fooddelivery.Model
{
    public class Categories
    {
        public Categories()
        {
            fooditems = new HashSet<Fooditems>();
        }
        [Key]
        public int Category_Id { get; set; }
        [Required]
        public string? Category_Name { get; set; }
        public virtual ICollection<Fooditems> fooditems { get; set; }
        
    }
}
