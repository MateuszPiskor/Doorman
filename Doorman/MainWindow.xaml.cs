
using Autofac;
using Doorman.DataServices;
using Doorman.StartUp;
using Doorman.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Doorman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private AddNewKeyViewModel addNewKeyViewModel;
        //private IContainer _container;
        private KeyDataService _keyDataSerivice;

        //public MainWindow(AddNewKeyViewModel addNewKeyViewModel)
        //{
        //    this.addNewKeyViewModel = addNewKeyViewModel;
        //    InitializeComponent();
        //}
        public MainWindow(KeyDataService keyDataService)
        {
            _keyDataSerivice = keyDataService;
            InitializeComponent();
        }

        private void GetKey_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new GetKeyViewModel();
        }

        private void AddNewKey_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new AddNewKeyViewModel(_keyDataSerivice);
        }
    }
}
