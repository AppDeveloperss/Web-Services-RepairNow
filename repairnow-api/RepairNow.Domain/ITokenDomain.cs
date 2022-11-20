namespace RepairNow.Domain.Test;

public interface ITokenDomain
{
    string GenerateJwt(string  email);
    bool ValidateJwt(string token);

}