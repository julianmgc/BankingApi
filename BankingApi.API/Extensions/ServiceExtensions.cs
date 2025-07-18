using BankingApi.Application.Services;
using BankingApi.Core.Interfaces;

namespace BankingApi.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAccountService, AccountService>();
        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, FakeUserRepository>();
        services.AddScoped<IAccountRepository, FakeAccountRepository>();
        return services;
    }
}

internal class FakeAccountRepository : IAccountRepository
{
    public Task<IEnumerable<Account>> GetAccountsByUserId(Guid userId)
    {
        // Implementación falsa para cumplir con la interfaz
        return Task.FromResult<IEnumerable<Account>>(Enumerable.Empty<Account>());
    }
}

internal class FakeUserRepository : IUserRepository
{
    public Task<User> GetUserByCredentials(string username, string password)
    {
        // Implementación falsa para cumplir con la interfaz
        return Task.FromResult<User>(null!);
    }
}