using WMSSystems.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WMSSystems.Services
{
    public interface IPurchaseOrderRepository
    {
        Task<PurchaseOrders> GetPurchaseOrderByIdAsync(string orderId);
        Task<IEnumerable<PurchaseOrders>> GetAllPurchaseOrdersAsync();
        Task AddPurchaseOrderAsync(PurchaseOrders purchaseOrder);
        Task UpdatePurchaseOrderAsync(PurchaseOrders purchaseOrder);
        Task DeletePurchaseOrderAsync(string orderId);
    }
}