using AutoMapper;
using CanDatabaseManagementSystem.Common.DtoModels;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.Service.Mapping
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageDto>().ReverseMap();
            CreateMap<Signal, SignalDto>().ReverseMap();
        }
    }
}
