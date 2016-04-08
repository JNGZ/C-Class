using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace gregsGrocerys
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            gregsGrocerys.Operator u = new gregsGrocerys.Operator();
            u.Roles["AddOperators"] = "Deny";
            u.Roles["AllProducts"] = "Deny";
            u.Roles["AllSales"] = "Deny";
            u.Roles["Default"] = "Deny";
            u.Roles["EditProduct"] = "Deny";
            u.Roles["NewProduct"] = "Deny";
            u.Roles["NewSale"] = "Deny";
            Session["user"] = u;

        }
    }
}