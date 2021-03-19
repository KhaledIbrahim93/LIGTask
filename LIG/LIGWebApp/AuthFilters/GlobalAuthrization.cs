using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LIGWebApp.AuthFilters
{
	public class GlobalAuthrization : AuthorizeAttribute, IAuthorizationFilter  
   {  
       public override void OnAuthorization(AuthorizationContext filterContext)
    {
        // Check for authorization  
        if (HttpContext.Current.Session["Admin"] == null
                   && HttpContext.Current.Session["Manager"] == null
                    && HttpContext.Current.Session["Customer"] == null)
        {
            filterContext.Result = new RedirectResult("~/Account/LogOut");
               
        }
    }
} 
	
}