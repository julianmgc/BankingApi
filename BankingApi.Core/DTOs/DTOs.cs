namespace BankingApi.Core.DTOs;

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