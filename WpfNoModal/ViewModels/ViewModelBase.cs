using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfNoModal {
    /// <summary>
    /// Базовый функционал для ViewModel'ей - копипаст из ранее выполненных проектов
    /// </summary>

    public class RelayCommand : ICommand {

        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute) {
            if (execute == null)
                throw new ArgumentNullException("execute is null");

            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) => _canExecute == null ? true : _canExecute(parameter);
        public void Execute(object parameter) => _execute(parameter);
    }

    public class CommandHolder {
        private Dictionary<string, ICommand> _commands = new Dictionary<string, ICommand>();

        public ICommand GetOrCreateCommand(Action<object> executeCommandAction, [CallerMemberName] string commandName = null) {
            if (!_commands.ContainsKey(commandName)) {
                var command = new RelayCommand(executeCommandAction);
                _commands.Add(commandName, command);
                return command;
            }

            return _commands[commandName];
        }
    }

    public class ViewModelBase : INotifyPropertyChanged {
        public bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null) {
            if (Equals(field, newValue))
                return false;
            field = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }
        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;

        private CommandHolder _commands;
        public CommandHolder Commands => _commands ??= new CommandHolder();
    }
}
