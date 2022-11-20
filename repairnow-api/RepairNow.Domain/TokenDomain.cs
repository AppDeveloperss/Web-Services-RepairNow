using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RepairNow.Shared;

namespace RepairNow.Domain.Test;

public class TokenDomain:ITokenDomain
{
    public string GenerateJwt(string email)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(Constans.SecretKey);

        var tokenDescriptor = new SecurityTokenDescriptor

        {

            Subject = new ClaimsIdentity(new[] { new Claim("email", email) }),

            Expires = DateTime.UtcNow.AddDays(1),

            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
        
    }

    public bool ValidateJwt(string token)
    {
        throw new NotImplementedException();
    }
}