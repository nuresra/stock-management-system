namespace StockManagementSystem.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                filterContext.Result = RedirectToAction("Login", "Account");
            }

            base.OnActionExecuting(filterContext);
        }
    }

}
