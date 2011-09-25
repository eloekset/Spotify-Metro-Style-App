using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Input;

namespace Spotify.Metro.Util
{
    public class Command : ICommand
    {
        Predicate<Object> _canExecute = null;
        Action<Object> _executeAction = null;

        public Command(Predicate<Object> canExecute, Action<object> executeAction)
        {
            _canExecute = canExecute;
            _executeAction = executeAction;
        }
            
        public void UpdateCanExecuteState()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }        

        #region ICommand
        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute(parameter);

            return true;
        }

        public event Windows.UI.Xaml.EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (_executeAction != null)
                _executeAction(parameter); 
            UpdateCanExecuteState();
        }
        #endregion
    }
}
