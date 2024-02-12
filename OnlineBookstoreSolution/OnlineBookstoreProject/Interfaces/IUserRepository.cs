﻿using OnlineBookstoreProject.Models;
using OnlineBookstoreProject.Models.DTOs;

namespace OnlineBookstoreProject.Interfaces
{
    public interface IUserRepository
    {
        public User Add(User item);
        public User Delete(string key);
        public User GetById(string key);
        public IList<User> GetAll();
        public User Update(User item);
    }
}
