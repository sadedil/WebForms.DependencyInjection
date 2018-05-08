using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;
using System.Web;
using WebForms.DependencyInjection.Services;

namespace WebForms.DependencyInjection.Autofac
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        public override void Init()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<MailService>().As<IMailService>();
            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            HttpRuntime.WebObjectActivator = serviceProvider;

            base.Init();
        }


    }
}