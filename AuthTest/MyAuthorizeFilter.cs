using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersTestWebApi.AuthTest
{
    //public class MyAuthorizeAttribute : FilterAttribute { }

    ///// Filter
    //public class MyAuthorizeFilter : IAuthorizationFilter
    //{
    //    private readonly IUserService _userService;
    //    public MyAuthorizeFilter(IUserService userService)
    //    {
    //        _userService = userService;
    //    }

    //    public void OnAuthorization(AuthorizationContext filterContext)
    //    {
    //        var validUser = _userService.CheckIsValid();

    //        if (!validUser)
    //        {
    //            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "action", "AccessDenied" }, { "controller", "Error" } });
    //        }
    //    }
    //}

}
