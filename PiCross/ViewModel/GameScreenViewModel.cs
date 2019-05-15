using Cells;
using DataStructures;
using PiCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class GameScreenViewModel
    {
        public Puzzle Puzzle;
        public PiCrossFacade Facade { get; }
        public IPlayablePuzzle PlayablePuzzle { get; private set; }
        public ICommand ClickCommand { get; private set; }
        public MainScreenViewModel Msvm { get; private set; }
        public IGrid<SquareViewModel> Grid { get; private set; }
        public Cell<bool> IsSolved { get { return PlayablePuzzle.IsSolved; }}

        public GameScreenViewModel(MainScreenViewModel mainScreenViewModel)
        {
            this.Puzzle = Puzzle.FromRowStrings("..", "xx");
            this.Facade = new PiCrossFacade();
            this.PlayablePuzzle = Facade.CreatePlayablePuzzle(this.Puzzle);
            this.Start(mainScreenViewModel, PlayablePuzzle);
            
        }

        public GameScreenViewModel(MainScreenViewModel mainScreenViewModel, IPlayablePuzzle playablePuzzle)
        {
            this.Start(mainScreenViewModel, playablePuzzle);
        }

        public void Start(MainScreenViewModel mainScreenViewModel, IPlayablePuzzle puzzle)
        {
            this.Msvm = mainScreenViewModel;
            this.PlayablePuzzle = puzzle;
            this.Grid = this.PlayablePuzzle.Grid.Map(square => new SquareViewModel(square)).Copy();
        }
    }

    public class ClickRectangle : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private GameScreenViewModel gsvm;
        private bool canExecute;

        public ClickRectangle(GameScreenViewModel gameScreenViewModel)
        {
            gsvm = gameScreenViewModel;
            canExecute = true;
        }

        private void ChangeValue(IPlayablePuzzleSquare square)
        {

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
