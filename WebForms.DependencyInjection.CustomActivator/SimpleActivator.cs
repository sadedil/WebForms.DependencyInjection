using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using WebForms.DependencyInjection.Services;

namespace WebForms.DependencyInjection.CustomActivator
{

    public class SimpleActivator : IServiceProvider
    {
        public object GetService(Type serviceType)
        {
            var ctors = serviceType.GetConstructors();
            ConstructorInfo targetCtor = null;
            foreach (var c in ctors)
            {
                var parameters = c.GetParameters();
                if (c.GetParameters().Count(p => p.ParameterType == typeof(IMailService)) == 1)
                {
                    targetCtor = c;
                    break;
                }
            }

            if (targetCtor != null)
            {
                return targetCtor.Invoke(new object[] { new MailService() });
            }
            else
            {
                var x = Activator.CreateInstance(
                serviceType,
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.CreateInstance,
                null,
                null,
                null);

                return x;
            }
        }
    }

}