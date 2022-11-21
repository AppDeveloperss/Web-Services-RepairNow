using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RepairNow.Infraestructure;

namespace RepairNowAPI.Filter;

public class AuthorizeAttribute: Attribute,IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnnonymus = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();

        if (allowAnnonymus)
        {
            return;
        }


        var user = (User)context.HttpContext.Items["User"];

        if (user == null)
        {
            context.Result = new JsonResult(new{message = "Unathorized"}){StatusCode = StatusCodes.Status401Unauthorized};
        }


    }
}