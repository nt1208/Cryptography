﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ChatLib.Models;
namespace ChatLib
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User Register(User user);

        [OperationContract]
        User Login(String username, String password);

        [OperationContract]
        String DoWork();

        [OperationContract]
        User GetUserByUserName(String username);

        [OperationContract]
        User UpdateUserByUsername(User olduser);

        [OperationContract]
        bool DeletUserByUsername(User olduser);
    }
}
