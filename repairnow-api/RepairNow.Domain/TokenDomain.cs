using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RepairNow.Shared;

namespace RepairNow.Domain;

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

    public string ValidateJwt(string token)
    {
        if (token == null)return null;

        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(Constans.SecretKey);

        try

        {

            tokenHandler.ValidateToken(token, new TokenValidationParameters

            {

                ValidateIssuerSigningKey = true,

                IssuerSigningKey = new SymmetricSecurityKey(key),

                ValidateIssuer = false,

                ValidateAudience = false,

                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)

                ClockSkew = TimeSpan.Zero

            }, out SecurityToken validatedToken);



            var jwtToken = (JwtSecurityToken)validatedToken;

            var email =jwtToken.Claims.First(x => x.Type == "email").Value;



            // return user id from JWT token if validation successful

            return email;

        }
        catch
        {
            // return null if validation fails
            return null;

        }
    }
}