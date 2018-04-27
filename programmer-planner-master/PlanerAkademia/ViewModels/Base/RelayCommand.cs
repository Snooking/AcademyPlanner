using System;
using System.Windows.Input;

namespace PlanerAkademia
{
    class RelayCommand : ICommand
    {
        #region PrivateMembers

        private Action action;

        #endregion

        #region Constructor

        public RelayCommand (Action action)
        {
            this.action = action;
        }

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Commands

        public bool CanExecute (object parameter)
        {
            return true;
        }

        public void Execute (object parameter)
        {
            action();
        }

        #endregion
    }
}
