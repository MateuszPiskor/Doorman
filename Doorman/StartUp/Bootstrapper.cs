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

            builder.RegisterType<DoormanDBContext>().SingleInstance();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<AddNewKeyViewModel>().AsSelf();
            builder.RegisterType<KeyDataService>().AsSelf();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            builder.RegisterType<AddNewEmployeeViewModel>().As<IAddNewEmployeeViewModel>();
            builder.RegisterType<AddNewKeyViewModel>().As<IAddNewKeyViewModel>();
            builder.RegisterType<GiveKeyViewModel>().As<IGiveKeyViewModel>();
            builder.RegisterType<KeyDataService>().As<IKeyDataService>();

            return builder.Build();
        }
    }
}
