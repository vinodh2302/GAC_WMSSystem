using WMSSystems.Models;
using WMSSystems.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WMSSystems.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseOrderController : Controller
    {
        private readonly IPurchaseOrderService _purchaseOrderService;

        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        [HttpGet]
        [Route("orders")]
        public async Task<List<PurchaseOrder>> GetPurchaseOrders()
        {
            var orders = await _purchaseOrderService.GetAllPurchaseOrdersAsync();
            return orders is List<PurchaseOrder> list ? list : new List<PurchaseOrder>(orders);
        }

        [HttpGet]
        [Route("orders/{id}")]
        public async Task<ActionResult<PurchaseOrder>> GetPurchaseOrderById(string id)
        {
            var order = await _purchaseOrderService.GetPurchaseOrderByIdAsync(id);
            if (order == null)
                return NotFound();
            return order;
        }

        [HttpPost]
        [Route("orders")]
        public async Task<ActionResult> AddPurchaseOrder([FromBody] PurchaseOrder purchaseOrder)
        {
            await _purchaseOrderService.AddPurchaseOrderAsync(purchaseOrder);
            return CreatedAtAction(nameof(GetPurchaseOrderById), new { id = purchaseOrder.orderId }, purchaseOrder);
        }

        [HttpPut]
        [Route("orders/{id}")]
        public async Task<ActionResult> UpdatePurchaseOrder(string id, [FromBody] PurchaseOrder purchaseOrder)
        {
            if (id != purchaseOrder.orderId)
                return BadRequest();

            await _purchaseOrderService.UpdatePurchaseOrderAsync(purchaseOrder);
            return NoContent();
        }

        [HttpDelete]
        [Route("orders/{id}")]
        public async Task<ActionResult> DeletePurchaseOrder(string id)
        {
            await _purchaseOrderService.DeletePurchaseOrderAsync(id);
            return NoContent();
        }
    }
}