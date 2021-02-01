using System.Windows.Input;

namespace Doorman.ViewModels
{
    public interface IAddNewEmployeeViewModel
    {
        ICommand AddEmployee { get; }
    }
}