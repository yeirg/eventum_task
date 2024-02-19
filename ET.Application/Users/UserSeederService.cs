using ET.Application.Users.Auth.Abstractions;
using ET.BuildingBlocks.Application.Consistence.Abstractions;
using ET.Domain.Users;
using ET.Domain.Users.Persistence;
using ET.Domain.Users.Specifications;

namespace ET.Application.Users;

public class UserSeederService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public UserSeederService(IUserRepository userRepository, IPasswordHasher passwordHasher, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }
    
    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        const string adminUsername = "admin";
        const string adminPassword = "admin";

        if (!await _userRepository.ExistAsync(new UserSpecification().ByLogin(adminUsername), cancellationToken))
        {
            var admin = new User(adminUsername, _passwordHasher.Hash(adminPassword));

            await _userRepository.AddAsync(admin);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}