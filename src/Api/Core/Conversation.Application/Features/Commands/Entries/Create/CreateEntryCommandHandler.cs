using AutoMapper;
using Conversation.Api.Application.Interfaces.Repositories;
using Conversation.Api.Domain.Models;
using Conversation.Common.ViewModels.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Api.Application.Features.Commands.Entries.Create
{
    public class CreateEntryCommandHandler : IRequestHandler<CreateEntryCommand, Guid>
    {
        IEntryRepository _entryRepository;
        IMapper _mapper;
        public CreateEntryCommandHandler(IEntryRepository entryRepository, IMapper mapper)
        {
            _entryRepository = entryRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
        {
            Entry dbEntry = _mapper.Map<Entry>(request);
            await _entryRepository.AddAsync(dbEntry);
            return dbEntry.Id;
        }
    }
}
