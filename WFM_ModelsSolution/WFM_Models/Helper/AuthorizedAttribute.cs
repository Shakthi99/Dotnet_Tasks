using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WFM_Models.Helper
{
    public class AuthorizedAttribute
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class AuthorisedAttribute Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (Users)context.HttpContext.Items["User"];
            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
}
