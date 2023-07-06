﻿using BookHiveDB.Domain.Identity;
using BookHiveDB.Repository.Interface;
using BookHiveDB.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookHiveDB.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public BookHiveApplicationUser findByEmail(string email)
        {
            return userRepository.FindByEmail(email);
        }

        public BookHiveApplicationUser findById(string id)
        {
            return userRepository.Get(id);
        }

        public BookHiveApplicationUser update(BookHiveApplicationUser user, string name, string surname, string email, string password, string confirmPassword)
        {
            if (name != null && !name.Equals(""))
                user.FirstName = name;

            if (surname != null && !surname.Equals(""))
                user.LastName = surname;

            return user;
        }
    }
}
