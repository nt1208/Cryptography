﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ChatLib.Models;

namespace ChatLib
{
    [ServiceContract(CallbackContract = typeof(IOneToOneCallback))]
    public interface IOneToOneChatService
    {
        [OperationContract]
        [FaultContract(typeof(DuplicateUserFault))]
        bool AddMeToServer(string userName);


        [OperationContract]
        bool LeaveServer(string userName);

        [OperationContract]
        bool LogInState(string userName);


        [OperationContract(IsOneWay = false)]
        void SendMessageToParticularUser(string sender, string receiver, string message);


        [OperationContract]
        List<SingleChatMessage> GetMessageHistory(string sendername, string receivename);

        [OperationContract]
        List<string> GetAllOnlineUsers(string request_sender);
    }
}
