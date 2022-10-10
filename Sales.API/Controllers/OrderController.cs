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

        //RECUPERAR OS PEDIDOS

        //INSERIR UM PEDIDO
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await customerDataAccess.GetCustomerAsync(inputModel.CustomerId);

            var model = new Order(inputModel.Vendor, customer);
            foreach (var itemDict in inputModel.Items)
            {
                var item = await itemDataAccess.GetItemAsync(itemDict.Key);
                model.AddOrderItem(new OrderItem(item, itemDict.Value));
            }

            await orderDataAccess.CreateOrderAsync(model);

            return Ok(inputModel);
        }
    }
}