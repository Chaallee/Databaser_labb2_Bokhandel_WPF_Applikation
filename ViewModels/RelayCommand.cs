using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bokhandel_WPF_Applikation.ViewModels;

public class RelayCommand : ICommand
{
    private readonly Func<Task> _execute;

    public RelayCommand(Func<Task> executeCommand)
    {
        _execute = executeCommand;
    }

    public event EventHandler? CanExecuteChanged   // ?
    {
        add { }                                      
        remove { }
    }

    public bool CanExecute(object? parameter) => true;

    public async void Execute(object? parameter)
    {
        await _execute();
    }
}