﻿using MediatR;

namespace Conversation.Common.ViewModels.RequestModels
{
    public class CreateEntryCommand : IRequest<Guid>
    {
        public CreateEntryCommand(string subject, string content, Guid? createdById)
        {
            Subject = subject;
            Content = content;
            CreatedById = createdById;
        }

        public string Subject { get; set; }
        public string Content { get; set; }
        public Guid? CreatedById { get; set; }
       
    }
}
