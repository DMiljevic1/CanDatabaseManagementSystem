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
    public class SignalService : ISignalService
    {
        private readonly ISignalRepository _signalRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SignalService> _logger;
        public SignalService(ISignalRepository signalRepository, IMapper mapper, ILogger<SignalService> logger)
        {
            _signalRepository = signalRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<List<SignalDto>> GetSignals(int messageId, CancellationToken cancellationToken)
        {
            try
            {
                var signals = await _signalRepository.GetSignals(messageId, cancellationToken);
                _logger.LogDebug("GetSignals successfull. Response: " + signals);
                var signalDtos = new List<SignalDto>();
                foreach (var signal in signals)
                {
                    signalDtos.Add(_mapper.Map<SignalDto>(signal));
                }
                _logger.LogDebug("Signals mapped into signalDtos sucessfull. Response: " +  signalDtos);

                return signalDtos;
            }
            catch (Exception e)
            {
                _logger.LogError("Error has occured: " + e.Message);
                throw;
            }
        }
    }
}
