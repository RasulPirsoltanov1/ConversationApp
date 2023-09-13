using Conversation.Common.ViewModels.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Common.ViewModels.RequestModels
{
    public class LoginUserCommand:IRequest<LoginUserViewModel>
    {
        public LoginUserCommand(string emailAdress, string password)
        {
            EmailAddress = emailAdress;
            Password = password;
        }
        public LoginUserCommand()
        {

        }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
       
    }
}
