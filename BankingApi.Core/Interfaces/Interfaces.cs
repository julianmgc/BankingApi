namespace BankingApi.Core.Interfaces;

public interface IAuthService
{
    Task<TokenDTO> Login(LoginDTO loginDTO);
}

public interface IAccountService
{
    Task<IEnumerable<AccountDTO>> GetAccounts();
}

public interface IUserRepository
{
    Task<User> GetUserByCredentials(string username, string password);
}

public interface IAccountRepository
{
    Task<IEnumerable<Account>> GetAccountsByUserId(Guid userId);
}

public class TokenDTO
{
    public string Token { get; set; } = string.Empty;
}

public class LoginDTO
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class AccountDTO
{
    public string Number { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal Balance { get; set; }
}

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class Account
{
    public Guid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public Guid UserId { get; set; }
}