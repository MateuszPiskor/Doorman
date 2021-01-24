using Autofac;
using Doorman.StartUp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Doorman
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            IContainer conteiner = bootstrapper.Bootstarp();
            var mainWindow = conteiner.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
