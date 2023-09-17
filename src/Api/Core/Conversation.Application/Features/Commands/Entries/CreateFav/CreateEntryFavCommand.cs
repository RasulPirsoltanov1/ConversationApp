﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Api.Application.Features.Commands.Entries.CreateFav
{
    public class CreateEntryFavCommand:IRequest<bool>
    {
        public CreateEntryFavCommand(Guid? entryId, Guid? userId)
        {
            EntryId = entryId;
            UserId = userId;
        }

        public Guid? EntryId { get; set; }
        public Guid? UserId { get; set; }
    }
}
