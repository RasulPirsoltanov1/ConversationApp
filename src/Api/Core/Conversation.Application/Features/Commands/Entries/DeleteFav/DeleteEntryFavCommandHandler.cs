using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Api.Application.Features.Commands.Entries.DeleteFav
{
    public class DeleteEntryFavCommandHandler : IRequestHandler<DeleteEntryFavCommand, bool>
    {
        public Task<bool> Handle(DeleteEntryFavCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
