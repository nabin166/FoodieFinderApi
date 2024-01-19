using System.ComponentModel.DataAnnotations;

namespace fooddelivery.Model
{
    public class FinalOrders
    {
        public FinalOrders()
        {
            orders = new HashSet<Orders>();
            deliveries = new HashSet<Deliveries>();
        }
        [Key]
        public int FinalOrder_Id { get; set; }
        [Required]
        public string? FinalOrder_Status { get; set; }
        public decimal? TotalAmount { get; set; }
        [Required]
        public int? Deliver_Location { get; set; }
        public DateTime dateTime { get; set; } = DateTime.Now;

        public virtual ICollection<Orders> orders { get; set; } 

        public virtual ICollection<Deliveries> deliveries { get; set; }

    }
}
