
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
        private IGiveKeyViewModel _getKeyViewModel;
        private ITakeKeyViewModel _takeKeyViewModel;
        private IListKeyInUseViewModel _listKeyViewModel;
        private IEditKeyViewModel _editKeyViewModel;

        public MainWindow(/*KeyDataService keyDataService,IEmployeeDataService employeeDataService,*/ IAddNewEmployeeViewModel addNewEmployeeViewModel, IAddNewKeyViewModel addNewKeyViewModel, IGiveKeyViewModel getKeyViewModel, ITakeKeyViewModel takeKeyViewModel, IListKeyInUseViewModel listKeyViewModel, IEditKeyViewModel editKeyViewModel)
        {
            _addNewEmployeeViewModel = addNewEmployeeViewModel;
            _addNewKeyViewModel = addNewKeyViewModel;
            _getKeyViewModel = getKeyViewModel;
            _takeKeyViewModel = takeKeyViewModel;
            _listKeyViewModel = listKeyViewModel;
            _editKeyViewModel = editKeyViewModel;
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

        private void GetKeyViewModel_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = _getKeyViewModel;
        }

        private void TakeKey_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = _takeKeyViewModel;
        }

        private void ListKeysInUse_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = _listKeyViewModel;
        }

        private void EditKey_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = _editKeyViewModel;
        }

        //private void GetKeyViewModel_Clicker(object sender, RoutedEventArgs e)
        //{
        //    DataContext = _getNewKeyViewModel;
        //}
    }
}
