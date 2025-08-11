using WMSSystems.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WMSSystems.Services
{
    public class PurchaseOrderRepository : IPurchaseOrderRepository
    {
        private readonly AppDbContext _context;

        public PurchaseOrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PurchaseOrder> GetPurchaseOrderByIdAsync(string orderId)
        {
            return await _context.PurchaseOrders
                .Include(po => po.products)
                .ThenInclude(pop => pop.productId)
                .Include(po => po.products)
                .FirstOrDefaultAsync(po => po.orderId == orderId);
        }

        public async Task<IEnumerable<PurchaseOrder>> GetAllPurchaseOrdersAsync()
        {
            return await _context.PurchaseOrders
                .Include(po => po.products)
                .ThenInclude(pop => pop.productId)
                .Include(po => po.products)
                .ToListAsync();
        }

        public async Task AddPurchaseOrderAsync(PurchaseOrder purchaseOrder)
        {
            _context.PurchaseOrders.Add(purchaseOrder);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePurchaseOrderAsync(PurchaseOrder purchaseOrder)
        {
            _context.PurchaseOrders.Update(purchaseOrder);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePurchaseOrderAsync(string orderId)
        {
            var purchaseOrder = await _context.PurchaseOrders
                .FirstOrDefaultAsync(po => po.orderId == orderId);

            if (purchaseOrder != null)
            {
                _context.PurchaseOrders.Remove(purchaseOrder);
                await _context.SaveChangesAsync();
            }
        }
    }
}