namespace WMSSystems.Models
{
    public class PurchaseOrderProduct
    {
        public string orderId { get; set; }
        public Product product { get; set; }
        public int quantity { get; set; }
    }
}
