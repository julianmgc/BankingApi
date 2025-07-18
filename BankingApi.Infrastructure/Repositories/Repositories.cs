using BankingApi.Core.Interfaces;
using BankingApi.Core.Models;
using System.Security.Cryptography;
using System.Text;

namespace BankingApi.Infrastructure.Repositories;

public class FakeUserRepository : IUserRepository
{
    // In a real application, this would be a database context
    private readonly List<User> _users = new()
    {
        new User
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Username = "testuser",
            Password = HashPassword("password123")
        }
    };

    public Task<User> GetUserByCredentials(string username, string password)
    {
        var hashedPassword = HashPassword(password);
        var user = _users.FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);
        return Task.FromResult(user);
    }

    private static string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
    }
}

public class FakeAccountRepository : IAccountRepository
{
    // In a real application, this would be a database context
    private readonly List<Account> _accounts = new()
    {
        new Account
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Number = "1234567890",
            Type = "Checking",
            Balance = 1500.50m,
            UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
        },
        new Account
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Number = "0987654321",
            Type = "Savings",
            Balance = 5000.00m,
            UserId = Guid.Parse("11111111-1111-1111-1111-111111111111")
        }
    };

    public Task<IEnumerable<Account>> GetAccountsByUserId(Guid userId)
    {
        var accounts = _accounts.Where(a => a.UserId == userId);
        return Task.FromResult(accounts);
    }
}