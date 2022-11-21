namespace RepairNow.Domain.Test;

public interface ITokenDomain
{
    string GenerateJwt(string  email);
    string ValidateJwt(string token);

}