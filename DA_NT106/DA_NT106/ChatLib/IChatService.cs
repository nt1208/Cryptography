using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ChatLib.Models;

namespace ChatLib
{
    [ServiceContract(CallbackContract =typeof(IChatServiceCallback))]
    public interface IChatService
    {
        [OperationContract]
        [FaultContract(typeof(DuplicateUserFault))]
        bool AddMeToServer(string userName);


        [OperationContract]
        bool LeaveServer(string userName);


        [OperationContract]
        bool LogInState(string userName);


        [OperationContract(IsOneWay = false)]
        void SendMessage(string userName, string message);


        [OperationContract]
        List<ChatMessage> GetMessageHistory();
    }
}
