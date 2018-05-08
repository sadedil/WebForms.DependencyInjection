using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using WebForms.DependencyInjection.Services;

namespace WebForms.DependencyInjection.Ninject
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        public override void Init()
        {
            var settings = new NinjectSettings
            {
                InjectNonPublic = true
            };
            var kernel = new StandardKernel(settings);
            kernel.Bind<IMailService>().To<MailService>();

            HttpRuntime.WebObjectActivator = kernel;

            base.Init();
        }
    }
}