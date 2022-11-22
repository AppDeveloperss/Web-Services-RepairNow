namespace RepairNow.Domain;

public interface ITokenDomain
{
    string GenerateJwt(string  email);
    string ValidateJwt(string token);

}