﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Api.Application.Features.Commands.Entries.DeleteFav
{
    public class DeleteEntryFavCommand:IRequest<bool>
    {
        public DeleteEntryFavCommand(Guid userId, Guid entryId)
        {
            UserId = userId;
            EntryId = entryId;
        }

        public Guid UserId{ get; set; }
        public Guid EntryId{ get; set; }
    }
}
