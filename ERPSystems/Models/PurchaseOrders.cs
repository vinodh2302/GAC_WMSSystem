namespace WMSSystems.Models
{
    public class PurchaseOrders
    {
        public string orderId { get; set; }
        public DateTime processingDate { get; set; }
        public Customer customer { get; set; }
        public List<PurchaseOrderProduct> productLength { get; set; }
    }
}
