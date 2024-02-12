﻿using OnlineBookstoreProject.Contexts;
using OnlineBookstoreProject.Interfaces;
using OnlineBookstoreProject.Models;
using Microsoft.EntityFrameworkCore;
namespace OnlineBookstoreProject.Reposittories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookStoreContext _context;

        public UserRepository(BookStoreContext context)
        {
            _context = context;
        }

        public User Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public User Delete(string key)
        {
            var user = GetById(key);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return user;
            }

            return null; 
        }

        public IList<User> GetAll()
        {
            if (_context.Users.Count() == 0)
                return null; 

            return _context.Users.ToList();  
        }

        public User GetById(string key)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserName == key);
            return user;
        }

        public User Update(User entity)
        {
            var user = GetById(entity.UserName);

            if (user != null)
            {
                _context.Entry<User>(user).State = EntityState.Modified;
                _context.SaveChanges();
                return user;
            }

            return null; 
        }
    }
}