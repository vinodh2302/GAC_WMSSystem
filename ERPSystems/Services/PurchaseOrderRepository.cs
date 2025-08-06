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

        public async Task<PurchaseOrders> GetPurchaseOrderByIdAsync(string orderId)
        {
            return await _context.PurchaseOrders
                .Include(po => po.productLength)
                .ThenInclude(pop => pop.product)
                .Include(po => po.customer)
                .FirstOrDefaultAsync(po => po.orderId == orderId);
        }

        public async Task<IEnumerable<PurchaseOrders>> GetAllPurchaseOrdersAsync()
        {
            return await _context.PurchaseOrders
                .Include(po => po.productLength)
                .ThenInclude(pop => pop.product)
                .Include(po => po.customer)
                .ToListAsync();
        }

        public async Task AddPurchaseOrderAsync(PurchaseOrders purchaseOrder)
        {
            _context.PurchaseOrders.Add(purchaseOrder);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePurchaseOrderAsync(PurchaseOrders purchaseOrder)
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