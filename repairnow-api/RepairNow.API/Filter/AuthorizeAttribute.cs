using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RepairNow.Infraestructure;

namespace RepairNowAPI.Filter;

public class AuthorizeAttribute : Attribute,IAuthorizationFilter
{
    private string _roles;

    public AuthorizeAttribute(params string[] roles)
    {
        _roles ="customer";
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // If action is decorated with [AllowAnonymous] attribute
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        // Then skip authorization process
        if (allowAnonymous)
            return;
        
        //Console.WriteLine(_roles.Count);
        // Authorization process
        var user = (User)context.HttpContext.Items["User"];

        if (user == null || !_roles.Any() || (_roles.Any() && !_roles.Contains(user.roles)))
        {
            context.Result = new JsonResult(new {message="Unathorized"}) {StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}