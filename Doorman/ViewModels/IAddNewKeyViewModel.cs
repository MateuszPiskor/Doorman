using System.Windows.Input;

namespace Doorman.ViewModels
{
    public interface IAddNewKeyViewModel
    {
        ICommand AddKey { get; }
    }
}