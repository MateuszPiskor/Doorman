
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
    public partial class MainWindow : Window
    {
        private IAddNewEmployeeViewModel _addNewEmployeeViewModel;
        private IAddNewKeyViewModel _addNewKeyViewModel;
       

        public MainWindow(/*KeyDataService keyDataService,IEmployeeDataService employeeDataService,*/ IAddNewEmployeeViewModel addNewEmployeeViewModel, IAddNewKeyViewModel addNewKeyViewModel )
        {
            _addNewEmployeeViewModel = addNewEmployeeViewModel;
            _addNewKeyViewModel = addNewKeyViewModel;
            InitializeComponent();
        }

        private void AddEmployee_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = _addNewEmployeeViewModel;
        }

        private void AddNewKey_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = _addNewKeyViewModel;
        }
    }
}
