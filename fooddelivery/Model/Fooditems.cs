using System.ComponentModel.DataAnnotations;

namespace fooddelivery.Model
{
    public class Fooditems
    {

        public Fooditems()
        {
            orders = new HashSet<Orders>();
        }
        [Key]
        public int Fooditem_id { get; set; }
        [Required]
        public string? Fooditem_name { get; set; }
        [Required]
        public string? Fooditem_description { get; set; }
        [Required]
        public decimal? Fooditem_Price { get; set; }
        [Required]
        public string? Fooditem_Image { get; set; }

        public int? Resturant_Id { get; set; }
        public int? Category_Id { get; set; }

        public virtual Resturants? Resturant { get; set; }
        public virtual Categories? Category { get; set; }

        public virtual ICollection<Orders> orders { get; set; }

    }
}
