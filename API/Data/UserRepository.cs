using System;
using API.DTOs;
using API.Interface;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UserRepository(DataContext context, IMapper mapper) : IUserRepository
{
    public async Task<MembersDto?> GetMemberAsync(string username)
    {

#pragma warning disable CS8604 // Possible null reference argument.
        return await context.Users
            .Where(x => x.UserName == username)
            .ProjectTo<MembersDto>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
#pragma warning restore CS8604 // Possible null reference argument.
    }

    public async Task<IEnumerable<MembersDto>> GetMembersAsync()
    {
        return await context.Users
            .ProjectTo<MembersDto>(mapper.ConfigurationProvider)
            .ToListAsync();
    }

    // public async Task<Portfolio?> GetPortfolioByIdAsync(int id)
    // {
    //     throw new NotImplementedException();
    // }

    // public async Task<IEnumerable<Portfolio>> GetPortfoliosAsync()
    // {
    //     throw new NotImplementedException();
    // }

    public async Task<AppUser?> GetUserByIdAsync(int id)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return await context.Users.FindAsync(id);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }

    public async Task<AppUser?> GetUserByUsernameAsync(string username)
    {
#pragma warning disable CS8604 // Possible null reference argument.
        return await context.Users
        .Include(x => x.Portfolios)
        .SingleOrDefaultAsync(x => x.UserName == username);
#pragma warning restore CS8604 // Possible null reference argument.
    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
#pragma warning disable CS8604 // Possible null reference argument.
        return await context.Users
        .Include(x => x.Portfolios)
        .ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
    }

    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void Update(AppUser user)
    {
        context.Entry(user).State = EntityState.Modified;
    }
}
