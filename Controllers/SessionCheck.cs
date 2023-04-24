using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPNetCoreInventory.Controllers;

public class SessionCheck: ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
       var session = filterContext.HttpContext.Session.GetString("Email");
        if (string.IsNullOrEmpty(session))
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "Controller", "Frontend" },
                    { "Action", "Login" }
                }
            );
        }
    }
}
