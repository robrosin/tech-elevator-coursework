using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TE.AuthLib;

namespace Forms.Web.Controllers
{
    // TODO 02 (Controller): If we create a base-class controller for our application, then every 
    //  derived controller can have access to the authProvider if needed.

    public class AppController : Controller
    {
        protected IAuthProvider authProvider;
        public AppController(IAuthProvider authProvider)
        {
            this.authProvider = authProvider;
        }

        protected bool LoggedIn
        {
            get
            {
                return authProvider.IsLoggedIn;
            }
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (LoggedIn)
            {
                ViewData["CurrentUser"] = authProvider.GetCurrentUser();
            }
        }
    }
}