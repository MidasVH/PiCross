using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cells;
using PiCross;
using Grid = DataStructures.Grid;

using System.Windows.Input;

namespace ViewModel
{
    public class ViewModelMainWindow
    {
        public ViewModelMainWindow()
        {
            //Maak puzzle van String
             this.Puzzle = Puzzle.FromRowStrings(
                "xxxxx",
                "x...x",
                "x...x",
                "x...x",
                "xxxxx"
            );

            //Maak
            this.Facade = new PiCrossFacade();
            this.PlayablePuzzle = Facade.CreatePlayablePuzzle(this.Puzzle);
            this.ClickCommand = new ClickSquare(this);
        }

        public Cell<bool> IsSolved {
            get {
                return PlayablePuzzle.IsSolved;
            }
        }

        public Puzzle Puzzle;
        public PiCrossFacade Facade { get; }
        public IPlayablePuzzle PlayablePuzzle { get; }
        public ICommand ClickCommand { get; private set; }

        public class ClickSquare : ICommand
        {
            public event EventHandler CanExecuteChanged;
            private ViewModelMainWindow viewModelMainWindow;
            public bool canExecute;
            public EventHandler CanExecuteChange;

            public ClickSquare(ViewModelMainWindow viewModelMainWindow)
            {
                this.viewModelMainWindow = viewModelMainWindow;
                canExecute = true;
            }

            private void ChangeValue(IPlayablePuzzleSquare square)
            {
                if(viewModelMainWindow.PlayablePuzzle.Grid[square.Position].Contents.Value == Square.EMPTY || viewModelMainWindow.PlayablePuzzle.Grid[square.Position].Contents.Value == Square.UNKNOWN)
                {
                    viewModelMainWindow.PlayablePuzzle.Grid[square.Position].Contents.Value = Square.FILLED;
                }
                else
                {
                    viewModelMainWindow.PlayablePuzzle.Grid[square.Position].Contents.Value = Square.EMPTY;
                }
            }

            public bool CanExecute(object parameter)
            {
                return canExecute;
            }

            public void Execute(object parameter)
            {
                var square = parameter as IPlayablePuzzleSquare;
                ChangeValue(square);
            }
        }
    }
}
