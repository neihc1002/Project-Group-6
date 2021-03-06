﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Constants;
using Helper;
using Models;
using Repositories;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _repositoryUser;
        private readonly HashingData _hashingData;
        public UserService(IBaseRepository<User> repositoryUser)
        {
            _repositoryUser = repositoryUser;
            _hashingData = new HashingData(AppSettingConstant.SaltLength);
        }
        public User CheckLogin(string username, string password)
        {
            User user = _repositoryUser.Find(u =>
                u.Username == username && u.Status.Equals(UserStatus.Active));
            if(user!=null)
            {
                if (password.Equals(_hashingData.DecryptString(user.Password, AppSettingConstant.PasswordHash)))
                return user;
            }

            return null;
        }

    }
}
