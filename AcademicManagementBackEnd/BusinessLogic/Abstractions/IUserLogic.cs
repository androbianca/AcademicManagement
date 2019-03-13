﻿using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface IUserLogic
    {
        User Authenticate(string code, string password);
        User Create(UserDto userDto);
        UserDetailsDto GetById(string userCode);

    }
}
