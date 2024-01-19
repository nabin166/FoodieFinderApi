using System.ComponentModel.DataAnnotations;

namespace fooddelivery.Model
{
    public class CustomerOrders
    {
        [Key]
        public int? CustomerOrders_Id { get; set; }
        public int? Customer_Id { get; set; }
        public virtual Customers? Customer { get; set; }
        public int? Order_Id { get; set; }
        public virtual Orders? Order { get; set; }

    }
}
