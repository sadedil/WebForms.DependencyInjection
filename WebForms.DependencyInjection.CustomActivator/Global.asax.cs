using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebForms.DependencyInjection.CustomActivator
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        public override void Init()
        {
            HttpRuntime.WebObjectActivator = new SimpleActivator();
            base.Init();
        }
    }
}