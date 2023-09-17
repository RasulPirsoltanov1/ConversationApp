using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Common.Events.Users
{
    public class ChangeUserPasswordCommand:IRequest<bool>
    {
        public Guid? Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public ChangeUserPasswordCommand(Guid? id,string newPassword, string oldPassword)
        {
            NewPassword = newPassword;
            OldPassword = oldPassword;
            Id = id;
        }
    }
}
