using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sales.API.DataAccessNoSql;
using Sales.API.Models;

namespace Sales.API.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly OrderDataNoSql orderDataAccess;

        public OrderController(OrderDataNoSql orderDataAccess)
        {
            this.orderDataAccess = orderDataAccess;
        }

        //RECUPERAR UM PEDIDO

        //RECUPERAR OS PEDIDOS

        //INSERIR UM PEDIDO
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order itemModel)
        {            
            await orderDataAccess.CreateOrderAsync(itemModel);

            return Ok(itemModel);
        }
    }
}