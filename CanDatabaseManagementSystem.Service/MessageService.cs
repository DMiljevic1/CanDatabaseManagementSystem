using AutoMapper;
using CanDatabaseManagementSystem.Common.DtoModels;
using CanDatabaseManagementSystem.Contract;
using DomainModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.Service
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<List<MessageDto>> GetMessages(int dbcFileId, CancellationToken cancellationToken)
        {
            var messages = await _messageRepository.GetMessages(dbcFileId, cancellationToken);
            var messageDtos = new List<MessageDto>();
            foreach (var message in messages)
            {
                messageDtos.Add(_mapper.Map<MessageDto>(message));
            }

            return messageDtos;
        }
    }
}
