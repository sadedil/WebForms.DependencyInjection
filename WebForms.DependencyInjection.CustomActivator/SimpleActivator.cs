/* This class is taken from this address:
 * https://gist.github.com/preetikr/ed3953c7f07dfaa6589eae89e0c289a2#file-net472_aspnet_dependencyinjection_step1-cs
 */

using System;
using System.Linq;
using System.Reflection;
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
                var instance = Activator.CreateInstance(
                    serviceType,
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.CreateInstance,
                    null,
                    null,
                    null);

                return instance;
            }
        }
    }

}