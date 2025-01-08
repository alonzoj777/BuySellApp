using System;
using API.DTOs;
using API.Models;

namespace API.Interface;

public interface IUserRepository
{
    void Update(AppUser user);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<AppUser?> GetUserByIdAsync(int id);
    Task<AppUser?> GetUserByUsernameAsync(string username);
    Task<IEnumerable<MembersDto>> GetMembersAsync();
    Task<MembersDto?> GetMemberAsync(string username);
    // Task<IEnumerable<Portfolio>> GetPortfoliosAsync();
    // Task<Portfolio?> GetPortfolioByIdAsync(int id);

}
