using System.ComponentModel.DataAnnotations;

namespace fooddelivery.Model
{
    public class Deliveries
    {

        
        [Key]
        public int Delivery_Id { get; set; }
        [Required]
        public DeliveryStatus DeliveryStatus { get; set; } = DeliveryStatus.OrderPlaced;
        public string? Deliverylocation { get; set; }

        public int? FinalOrder_Id { get; set; }
        public virtual FinalOrders? FinalOrder { get; set; }

        public int? Customer_Id { get; set; }
        public virtual Customers? Customers { get; set; }
    }

  
}
public enum DeliveryStatus
{
    OrderPlaced,
    OntheWay,
    Received

}