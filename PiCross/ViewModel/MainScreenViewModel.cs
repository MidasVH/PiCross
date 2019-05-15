using PiCross;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MainScreenViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private object activeWindow;
        public object ActiveWindow {
            get { return activeWindow; }
            set { activeWindow = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActiveWindow))); }
        }

        public MainScreenViewModel()
        {
            this.ActiveWindow = new StartScreenViewModel(this);
        }

        public void StartGame()
        {
            this.ActiveWindow = new GameScreenViewModel(this);
        }

        public void StartGame(IPlayablePuzzle playablePuzzle)
        {
            this.ActiveWindow = new GameScreenViewModel(this, playablePuzzle);
        }

        public void ChooseLevel()
        {
            //this.ActiveWindow = new ChooseLevelScreenViewModel(this);
        }
    }
}
