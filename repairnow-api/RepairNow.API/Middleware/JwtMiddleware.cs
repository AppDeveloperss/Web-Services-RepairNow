using Microsoft.EntityFrameworkCore.Query.Internal;
using RepairNow.Domain;
using RepairNow.Domain.Test;

namespace RepairNowAPI.Middleware;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ITokenDomain tokenDomain, IUsersDomain usersDomain)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault() ?.Split(" ").Last();
        var email = tokenDomain.ValidateJwt(token);

        if (email != null)
        {
            context.Items["User"]=await usersDomain.getByEmail(email);
        }
        await _next(context);
    }
}