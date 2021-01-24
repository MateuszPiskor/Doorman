using Autofac;
using Doorman.DataServices;
using Doorman.ViewModels;
using DoorMan.DataAccess;
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

            builder.RegisterType<KeyDataService>().AsSelf();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<DoormanDBContext>().SingleInstance();
            builder.RegisterType<AddNewKeyViewModel>().AsSelf();
            
            return builder.Build();
        }
    }
}
