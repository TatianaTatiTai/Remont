using AutoMapper;
using LAMS.DataAccess.Common.Models.Users;
using LAMS.Logic.Common.Models.Users;

namespace LAMS.Logic.Mappings.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDb>().ReverseMap();
            CreateMap<UserDb, User>();
        }
    }
}
