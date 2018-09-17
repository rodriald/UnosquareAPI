using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Models;


    public interface IUserService
    {
        List<User> GetAll();

        User GetById(long id);
        void Create(User user);
        User Delete(long id);
        User Update(long id, User user);
    }
