using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(DataContext context) : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var users = context.Users.ToList();
#pragma warning restore CS8604 // Possible null reference argument.

            return users;
        }
        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUsers(int id)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var user = context.Users.Find(id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            if(user == null) return NotFound();
            
            return user;
        }
    }
}
