using System;
using Unity;
using WebForms.DependencyInjection.Services;

namespace WebForms.DependencyInjection.Unity
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        public override void Init()
        {
            var container = new UnityContainer();
            container.RegisterType<IMailService, MailService>();
    

            //TODO: Find a way
            //HttpRuntime.WebObjectActivator =

            base.Init();
        }
    }
}