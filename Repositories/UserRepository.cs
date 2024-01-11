﻿using AutoMapper;
using CrudApiAssignment.DTOs;
using CrudApiAssignment.Interfaces;
using CrudApiAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApiAssignment.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<UserResponse> GetSingleUser(string id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
            var userResponse = _mapper.Map<UserResponse>(user);
            return userResponse;
        }
    }
}
