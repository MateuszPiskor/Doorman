﻿using Autofac;
using Doorman.DataServices;
using Doorman.Model;
using Doorman.ViewModels;
using Doorman.Wrappers;
using DoorMan.DataAccess;

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
            builder.RegisterType<KeyRepository>().AsSelf();
            builder.RegisterType<TakeKeyWrapper>().AsSelf();
            builder.RegisterType<TakeKeyModel>().AsSelf();

            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            builder.RegisterType<KeyInUseRepository>().As<IKeyInUseRepository>();
            builder.RegisterType<AddNewEmployeeViewModel>().As<IAddNewEmployeeViewModel>();
            builder.RegisterType<AddNewKeyViewModel>().As<IAddNewKeyViewModel>();
            builder.RegisterType<GiveKeyViewModel>().As<IGiveKeyViewModel>();
            builder.RegisterType<TakeKeyViewModel>().As<ITakeKeyViewModel>();
            builder.RegisterType<EditKeyViewModel>().As<IEditKeyViewModel>();
            builder.RegisterType<KeyRepository>().As<IKeyRepository>();
            builder.RegisterType<ListKeyInUseViewModel>().As<IListKeyInUseViewModel>();
            builder.RegisterType<RemoveKeyViewModel>().As<IRemoveKeyViewModel>();
            builder.RegisterType<RemoveEmployeeViewModel>().As<IRemoveEmployeeViewModel>();


            return builder.Build();
        }
    }
}
