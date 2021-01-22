using Autofac;
using Doorman.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorman.StartUp
{
    public class Bootstrapper
    {
        public IContainer Bootstarp()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<KeyDataService>().As<IKeyDataService>();
            return builder.Build();
        }
    }
}
