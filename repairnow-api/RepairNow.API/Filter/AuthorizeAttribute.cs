using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RepairNow.Infraestructure;

namespace RepairNowAPI.Filter;

public class AuthorizeAttribute: Attribute,IAuthorizationFilter
{
    private readonly List<string> _roles;

    public AuthorizeAttribute(params string[] roles)
    {
        _roles = (roles.Count() > 0) ? roles.FirstOrDefault().Split(",").ToList() : new List<string>();
    }
    
    
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnnonymus = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();

        if (allowAnnonymus)
        {
            return;
        }


        var user = (User)context.HttpContext.Items["User"];
        
        Console.WriteLine(user.roles);
        Console.WriteLine("/n");

        if (user == null || (_roles.Any() && !_roles.Contains(user.roles))) 
        {
            context.Result = new JsonResult(new{message = "Unathorized"}){StatusCode = StatusCodes.Status401Unauthorized};
        }


    }
}