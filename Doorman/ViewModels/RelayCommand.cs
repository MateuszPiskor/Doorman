using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


class RelayCommand : ICommand
{
    //Zdarzenie  wywolywane co jakis czas, sprawdzajace co zwraca metoda CanExecute to funkcjonalnosc mozemy zlecic wbudowanej klasie commandManager
    public event EventHandler CanExecuteChanged 
    {
        add
        {
            //jezeli ktos dodajne nowwe zdarzenie to odrazu dodajemy je do commandmanagera
            CommandManager.RequerySuggested += value;
        }
        remove
        {
            CommandManager.RequerySuggested -= value;
        }
    }

    //poniewaz nasza klasa jest ogolna klasa, to bedzie przyjmowala delegaty do funkcji w konstrukotrze i bedzie je zapisywac do execute i can execute
    Action<object> execute;
    Func<object, bool> canExecute;

    //can execute nie musi byc przekazywany, w takim wypadku zwroci true;
    public RelayCommand(Action<object> execute, Func<object, bool> canExecute=null)
    {
        //w przypadku gdy nie mamy refererencji do funkcji can execute zwracamy wyjatek
        if (execute == null) throw new ArgumentNullException(nameof(execute));
        this.execute = execute;
        this.canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        if (canExecute == null) return true;
        //wywolanie funkcji przekazenej przez delegat
        else return canExecute(parameter);
    }

    public void Execute(object parameter)
    {
        //wywolanie funkcji przekazenej przez delegat
        execute(parameter);
    }
}

