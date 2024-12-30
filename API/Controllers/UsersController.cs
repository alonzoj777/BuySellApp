using API.Data;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  
    public class UsersController(DataContext context) : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var users = await context.Users.ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.

            return users;
        }
        
        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> GetUsers(int id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var user = await context.Users.FindAsync(id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if(user == null) return NotFound();
            
            return user;
        }
    }
}
