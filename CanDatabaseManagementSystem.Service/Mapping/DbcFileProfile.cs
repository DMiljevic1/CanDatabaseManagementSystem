using AutoMapper;
using CanDatabaseManagementSystem.Common.DtoModels;
using CanDatabaseManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.Service.Mapping
{
	public class DbcFileProfile : Profile
	{
		public DbcFileProfile()
		{
			CreateMap<DbcFile, DbcFileDto>().ReverseMap();
			CreateMap<NetworkNode, NetworkNodeDto>().ReverseMap();
			CreateMap<Message, MessageDto>().ReverseMap();
		}
	}
}
