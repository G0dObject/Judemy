using AutoMapper;
using Judemy.Application.Common.Entity;
using Judemy.Domain.Entity;
using Judemy.Domain.Entity.Users;
using System.Linq.Expressions;

namespace Judemy.Application.Common.Mapping.Profiles
{
	public class AppMappingProfile : Profile
	{
		public AppMappingProfile()
		{
			_ = CreateMap<CreateUser, User>().ForMember(f=>f.PasswordHash, c=>c.MapFrom(c=>c.Password));
			_ = CreateMap<LoginUser, User>();
		}
	}

}
