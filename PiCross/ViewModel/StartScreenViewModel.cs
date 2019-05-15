using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class StartScreenViewModel
    {
        private MainScreenViewModel Msvm { get; }
        public ICommand Start { get; }
        public ICommand Choose { get; }

        public StartScreenViewModel(MainScreenViewModel mainScreenViewModel)
        {
            this.Msvm = mainScreenViewModel;
            this.Start = new StartCommand(this.Msvm);
            this.Choose = new ChooseCommand(this.Msvm);
        }
    }

    public class StartCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private MainScreenViewModel mainScreenViewModel;
        private bool canExecute;

        public StartCommand(MainScreenViewModel msvm)
        {
            mainScreenViewModel = msvm;
            canExecute = true;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public void Execute(object parameter)
        {
            mainScreenViewModel.StartGame();
        }
    }

    public class ChooseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private MainScreenViewModel mainScreenViewModel;
        private bool canExecute;

        public ChooseCommand(MainScreenViewModel msvm)
        {
            mainScreenViewModel = msvm;
            canExecute = true;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public void Execute(object parameter)
        {
            mainScreenViewModel.ChooseLevel();
        }
    }
}
