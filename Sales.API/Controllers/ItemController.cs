using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using Sales.API.DataAccess;
using Sales.API.DataAccessNoSql;
using Sales.API.Models;

//arquitetura MVC: model, controller e view
//model -> modelo representativo de dados atraves de objetos/classes
//view -> basicamente, esta na linha de frente da comunicacao com o usuario final do sistema
//controller -> intermediacao entre a view e as regras de negocios, com o fornecimento de model ou ate mesmo respondendo o model

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ItemDataNoSql itemDataAccess;

        public ItemController(ItemDataNoSql itemDataAccess)
        {
            this.itemDataAccess = itemDataAccess;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await itemDataAccess.GetItemsAsync();

            return Ok(items);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var item = await itemDataAccess.GetItemAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item itemModel)
        {
            itemModel.Id = ObjectId.GenerateNewId().ToString();
            
            await itemDataAccess.CreateItemAsync(itemModel);

            return Ok(itemModel);
        }

        // [HttpPut]
        // [Route("{id}")]
        // public async Task<IActionResult> Put(int id, [FromBody] Item itemModel)
        // {
        //     var model = await itemDataAccess.UpdateOne(id, itemModel);

        //     if (model != null)
        //     {
        //         return Ok(model);
        //     }

        //     return NotFound();
        // }

        // [HttpDelete]
        // [Route("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     await itemDataAccess.DeleteOne(id);
        //     return NoContent();
        // }
    }
}