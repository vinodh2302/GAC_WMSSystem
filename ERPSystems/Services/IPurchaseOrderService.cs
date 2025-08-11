using WMSSystems.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WMSSystems.Services
{
    public interface IPurchaseOrderService
    {
        Task<PurchaseOrder> GetPurchaseOrderByIdAsync(string orderId);
        Task<IEnumerable<PurchaseOrder>> GetAllPurchaseOrdersAsync();
        Task AddPurchaseOrderAsync(PurchaseOrder purchaseOrder);
        Task UpdatePurchaseOrderAsync(PurchaseOrder purchaseOrder);
        Task DeletePurchaseOrderAsync(string orderId);
    }
}