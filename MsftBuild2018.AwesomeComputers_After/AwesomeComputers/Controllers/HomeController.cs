using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwesomeComputers.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public void EditProfile()
        {
            if (Request.IsAuthenticated)
            {
                // Let the middleware know you are trying to use the edit profile policy (see OnRedirectToIdentityProvider in Startup.Auth.cs)
                HttpContext.GetOwinContext().Set("Policy", Startup.EditProfilePolicyId);

                // Set the page to redirect to after editing the profile
                var authenticationProperties = new AuthenticationProperties { RedirectUri = "/" };
                HttpContext.GetOwinContext().Authentication.Challenge(authenticationProperties);
                return;

            }

            Response.Redirect("/");

        }

        public void ResetPassword()
        {
            if (Request.IsAuthenticated)
            {
                // Let the middleware know you are trying to use the edit profile policy (see OnRedirectToIdentityProvider in Startup.Auth.cs)
                HttpContext.GetOwinContext().Set("Policy", Startup.ResetPasswordPolicyId);

                // Set the page to redirect to after editing the profile
                var authenticationProperties = new AuthenticationProperties { RedirectUri = "/" };
                HttpContext.GetOwinContext().Authentication.Challenge(authenticationProperties);
                return;

            }

            Response.Redirect("/");

        }
    }
}