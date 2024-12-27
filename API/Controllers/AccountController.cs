using API.Data;
using API.DTOs;
using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace API.Controllers
{
    public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController
    {
        [HttpPost("register")]//api/account/register
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            context.Users.Add(user);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            await context.SaveChangesAsync();

            return new UserDto{
                Username = user.UserName,
                Token = tokenService.CreateToken(user)
            };
        }
        [HttpPost("login")]//api/account/login
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
#pragma warning restore CS8604 // Possible null reference argument.

            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new UserDto{
                Username = user.UserName,
                Token = tokenService.CreateToken(user)
            };
        }
        private async Task<bool> UserExists(string username)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return context.Users != null && await context.Users.AnyAsync(x => x.UserName == username.ToLower());
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }

//     public async Task<ActionResult<AppUser>> Register(string userName, string password)
//         {
//             //if (await UserExists(userName)) return BadRequest("Username is taken");

//             using var hmac = new HMACSHA512();

//             var user = new AppUser
//             {
//                 UserName = userName.ToLower(),
//                 PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
//                 PasswordSalt = hmac.Key
//             };

// #pragma warning disable CS8602 // Dereference of a possibly null reference.
//             context.Users.Add(user);
// #pragma warning restore CS8602 // Dereference of a possibly null reference.
//             await context.SaveChangesAsync();

//             return user;
//         }
}
