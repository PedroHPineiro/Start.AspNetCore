using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.API.Models;
using Sales.API.Services;

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userService;

        public UserController(UserServices UserService) =>
            _userService = UserService;

        // Implementando a API REST
        // Get faz a pesquisa de uma lista de usuarios GetAsync
        [HttpGet]
        public async Task<List<User>> Get() =>
       await _userService.GetAsync();

        //Get tem um parametro que so pesquisa um usuario atraves do Id GetAsync(id) 
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var User = await _userService.GetAsync(id);

            if (User is null)
            {
                return NotFound();
            }

            return User;
        }

        //Post faz com que adicionamos um Usuario usando CreateAsync
        [HttpPost]
        public async Task<IActionResult> Post(User newUser)
        {
          
            await _userService.CreateAsync(newUser);
            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }

        //Put faz com que atualizamos um Usuario já existente usando Update UpdateAsync
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, User updatedUser)
        {
            var User = await _userService.GetAsync(id);

            if (User is null)
            {
                return NotFound();
            }

            updatedUser.Id = User.Id;

            await _userService.UpdateAsync(id, updatedUser);

            return NoContent();
        }

        //Delte faz com que deletamos um Usuario já existente usando Delete RemoveAsync
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var User = await _userService.GetAsync(id);

            if (User is null)
            {
                return NotFound();
            }

            await _userService.RemoveAsync(id);

            return NoContent();
        }
    }
}
