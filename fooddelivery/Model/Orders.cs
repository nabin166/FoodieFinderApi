using System.ComponentModel.DataAnnotations;

namespace fooddelivery.Model
{
    public class Orders
    {
        public Orders() {
            customerOrders = new HashSet<CustomerOrders>();
        }
        [Key]
        public int Order_Id { get; set; }
        [Required]
        public string? Order_Quantity { get; set; }
        [Required]
        public decimal? Order_Payment { get; set; }
        [Required]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public OrderStatus? Order_Status { get; set; } = OrderStatus.Purchase;
   
        public int? Fooditem_Id { get; set; }
        public virtual Fooditems Fooditem { get; set; }

        public int? FinalOrder_ID { get; set; }

        public virtual FinalOrders FinalOrder { get; set; }
        
        
        public virtual ICollection<CustomerOrders> customerOrders { get; set; } 
    }

    public enum OrderStatus
    {
        Purchase,
        Preapere,
        ReadytoGo
        
    }
}
