using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PiCross;
using DataStructures;

using ViewModel;

namespace View{
    using System.ComponentModel;
    using System.Globalization;
    using Grid = DataStructures.Grid;
    using size = DataStructures.Size;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window{
        public MainWindow(){
            InitializeComponent();


            vm = new ViewModel.ViewModelMainWindow();

            this.DataContext = vm;

            picrossControl.Grid = vm.PlayablePuzzle.Grid;

            picrossControl.RowConstraints = vm.PlayablePuzzle.RowConstraints;
            picrossControl.ColumnConstraints = vm.PlayablePuzzle.ColumnConstraints;
           
            
        }

        private ViewModel.ViewModelMainWindow vm;
    }

    public class SquareConverter : IValueConverter
    {
        public object Filled { get; set; }

        public object Empty { get; set; }

        public object Unknown { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var square = (Square)value;

            if (square == Square.EMPTY)
            {
                return Empty;
            }
            else if (square == Square.FILLED)
            {
                return Filled;
            }
            else
            {
                return Unknown;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
