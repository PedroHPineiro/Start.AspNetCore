using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sales.API.DataAccessNoSql;
using Sales.API.Models;
using Sales.API.ViewModels;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderDataNoSql orderDataAccess;
        private readonly CustomerDataNoSql customerDataAccess;
        private readonly ItemDataNoSql itemDataAccess;

        public OrderController(OrderDataNoSql orderDataAccess, CustomerDataNoSql customerDataAccess, ItemDataNoSql itemDataAccess)
        {
            this.orderDataAccess = orderDataAccess;
            this.customerDataAccess = customerDataAccess;
            this.itemDataAccess = itemDataAccess;
        }

        //RECUPERAR UM PEDIDO
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var order = await orderDataAccess.GetOrderAsync(id);
            return Ok(order);
        }

        //RECUPERAR OS PEDIDOS
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = await orderDataAccess.GetOrdersAsync();

            return Ok(orders);
        }

        //INSERIR UM PEDIDO
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await customerDataAccess.GetCustomerAsync(inputModel.CustomerId);
            if (customer == null)
                return BadRequest("Customer doesn't exist");

            var model = new Order(inputModel.Vendor, customer);
            foreach (var itemDict in inputModel.Items)
            {
                var item = await itemDataAccess.GetItemAsync(itemDict.Key);
                if (item == null)
                    return BadRequest("Item doesn't exist");

                model.AddOrderItem(new OrderItem(item, itemDict.Value));
            }

            await orderDataAccess.CreateOrderAsync(model);

            return Ok(inputModel);
        }

        //ATUALIZAR PEDIDO
       [HttpPut]
       [Route("{id}")]
       public async Task<IActionResult> Update(string id, OrderInputModel orderModel)
       {
            var order = await orderDataAccess.GetOrderAsync(id);
           if (order == null)
               return NotFound("Order doesn't exist");

            order.Vendor = orderModel.Vendor;
            order.Customer.Id = orderModel.CustomerId;
            order.Items = order.Items;

           await orderDataAccess.UpdateOrderAsync(id, order);
       
           return Ok(order);
       }
        //DELETAR UM PEDIDO
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var order = await orderDataAccess.GetOrderAsync(id);
            if (order == null)
                return NotFound("Order doesn't exist");

            await orderDataAccess.DeleteOrderAsync(id);

            return NoContent();
        }
    }
}