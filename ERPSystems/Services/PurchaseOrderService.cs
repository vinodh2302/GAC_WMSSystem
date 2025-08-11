using WMSSystems.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WMSSystems.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public async Task<PurchaseOrder> GetPurchaseOrderByIdAsync(string orderId)
        {
            return await _purchaseOrderRepository.GetPurchaseOrderByIdAsync(orderId);
        }

        public async Task<IEnumerable<PurchaseOrder>> GetAllPurchaseOrdersAsync()
        {
            return await _purchaseOrderRepository.GetAllPurchaseOrdersAsync();
        }

        public async Task AddPurchaseOrderAsync(PurchaseOrder purchaseOrder)
        {
            await _purchaseOrderRepository.AddPurchaseOrderAsync(purchaseOrder);
        }

        public async Task UpdatePurchaseOrderAsync(PurchaseOrder purchaseOrder)
        {
            await _purchaseOrderRepository.UpdatePurchaseOrderAsync(purchaseOrder);
        }

        public async Task DeletePurchaseOrderAsync(string orderId)
        {
            await _purchaseOrderRepository.DeletePurchaseOrderAsync(orderId);
        }
    }
}