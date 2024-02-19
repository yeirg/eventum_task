using AutoMapper;
using ET.BuildingBlocks.Infrastructure.Persistence;
using ET.Domain.Users;
using ET.Domain.Users.Persistence;
namespace ET.Infrastructure.Persistence;

public class UserRepository : EfRepository<User>, IUserRepository
{
    public UserRepository(AppDb db, IMapper mapper) : base(db, mapper)
    {
    }
}