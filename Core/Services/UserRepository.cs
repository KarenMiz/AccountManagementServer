﻿using AccountManagementServer.Core.Interfaces;
using AccountManagementServer.Core.Models;
using AccountManagementServer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace AccountManagementServer.Core.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly AccountManagementDbContext _context;
        public UserRepository(AccountManagementDbContext context)
        {
            _context = context;
        }

        public async Task<User?> CreateUserAsync(User user)
        {
            try
            {
                // בדוק אם האימייל כבר קיים
                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email.ToLower() == user.Email.ToLower());
                if (existingUser != null)
                {
                    throw new Exception("Email already exists in the system.");
                }

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error while creating user: {e.Message}");
                return null;
            }
        }


        public async Task<User?> GetUserByEmailAsync(string email)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task<User?> UpdateUserAsync(int id, User user)
        {
            try
            {
                User? userToUpdate = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (userToUpdate == null)
                {
                    return null;
                }
                userToUpdate.Name = user.Name;               
                userToUpdate.Email = user.Email;
                userToUpdate.Password = user.Password; 
                await _context.SaveChangesAsync();
                return userToUpdate;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<User?> DeleteUserAsync(int id)
        {
            try
            {
                User? userToDelete = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
                if (userToDelete == null)
                {
                    return null;
                }
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
                return userToDelete;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}

