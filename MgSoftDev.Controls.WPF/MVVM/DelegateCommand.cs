using System;
using System.Windows.Input;

namespace MgSoftDev.Controls.WPF.MVVM
{
    internal class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _CanExecute;
        private readonly Action<object>    _Execute;

        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
            _Execute = execute;
        }

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _Execute    = execute;
            _CanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _CanExecute == null || _CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _Execute(parameter);
        }

        // Ensures WPF commanding infrastructure asks all DelegateCommand objects whether their
        // associated views should be enabled whenever a command is invoked 
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                CanExecuteChangedInternal       += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                CanExecuteChangedInternal       -= value;
            }
        }

        private event EventHandler CanExecuteChangedInternal;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChangedInternal.Raise(this);
        }
    }

    internal class DelegateCommand<T> : ICommand
    {
        private readonly Predicate<T> _CanExecute;
        private readonly Action<T>    _Execute;

        public DelegateCommand(Action<T> execute)
            : this(execute, null)
        {
            _Execute = execute;
        }

        public DelegateCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _Execute    = execute;
            _CanExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _CanExecute == null || _CanExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _Execute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested    += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }


    internal static class EventRaiser
    {
        public static void Raise(this EventHandler handler, object sender)
        {
            handler?.Invoke(sender, EventArgs.Empty);
        }

        public static void Raise<T>(this EventHandler<EventArgs<T>> handler, object sender, T value)
        {
            handler?.Invoke(sender, new EventArgs<T>(value));
        }

        public static void Raise<T>(this EventHandler<T> handler, object sender, T value) where T : EventArgs
        {
            handler?.Invoke(sender, value);
        }

        public static void Raise<T>(this EventHandler<EventArgs<T>> handler, object sender, EventArgs<T> value)
        {
            handler?.Invoke(sender, value);
        }
    }


    internal class EventArgs<T> : EventArgs
    {
        public EventArgs(T value)
        {
            Value = value;
        }

        public T Value { get; private set; }
    }
}
