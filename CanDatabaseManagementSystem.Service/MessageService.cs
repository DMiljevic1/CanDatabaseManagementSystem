using AutoMapper;
using CanDatabaseManagementSystem.Common.DtoModels;
using CanDatabaseManagementSystem.Contract;
using CanDatabaseManagementSystem.Domain.Repositories;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<MessageService> _logger;
        public MessageService(IMessageRepository messageRepository, IMapper mapper, ILogger<MessageService> logger)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<MessageDto>> GetMessages(int dbcFileId, CancellationToken cancellationToken)
        {
            try
            {
                var messages = await _messageRepository.GetMessages(dbcFileId, cancellationToken);
                _logger.LogDebug("GetMessages successfull. Response " + messages);
                var messageDtos = new List<MessageDto>();
                foreach (var message in messages)
                {
                    messageDtos.Add(_mapper.Map<MessageDto>(message));
                }
                _logger.LogDebug("Mapped messages into messageDto successfull. Response: " + messageDtos);

                return messageDtos;
            }
            catch (Exception e)
            {
                _logger.LogError("Error has occured: " + e.Message);
                throw;
            }
        }
    }
}
