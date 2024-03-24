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
    public class SignalService : ISignalService
    {
        private readonly ISignalRepository _signalRepository;
        private readonly IMapper _mapper;
        public SignalService(ISignalRepository signalRepository, IMapper mapper)
        {
            _signalRepository = signalRepository;
            _mapper = mapper;
        }
        public async Task<List<SignalDto>> GetSignals(int messageId, CancellationToken cancellationToken)
        {
            var signals = await _signalRepository.GetSignals(messageId, cancellationToken);
            var signalDtos = new List<SignalDto>();
            foreach (var signal in signals)
            {
                signalDtos.Add(_mapper.Map<SignalDto>(signal));
            }

            return signalDtos;
        }
    }
}
