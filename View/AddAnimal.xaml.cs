using GuessTheAnimal.DAL;
using GuessTheAnimal.ViewModel;
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
using System.Windows.Shapes;

namespace GuessTheAnimal.View
{
    /// <summary>
    /// Interaction logic for Animal.xaml
    /// </summary>
    public partial class AddAnimal : Window
    {
        public AddAnimal()
        {
            InitializeComponent();
            XMLDataSource dataSource = new XMLDataSource();
            AnimalViewModel vm = new AnimalViewModel(dataSource, new Model.Animal());
            vm.Close = this.Close;
            this.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Close(object sender, EventArgs args)
        {
            this.Close();
        }
    }
}
