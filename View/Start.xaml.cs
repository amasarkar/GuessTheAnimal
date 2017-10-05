using GuessTheAnimal.Model;
using GuessTheAnimal.ViewModel;
using System;
using System.Windows;

namespace GuessTheAnimal.View
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        public Start()
        {
            InitializeComponent();
            SimpleAnimalGuesser guesser = new SimpleAnimalGuesser();
            StartViewModel vm = new StartViewModel(guesser);
            vm.DisplayMessage = this.DisplayMessage;
            this.DataContext = vm;

            //Animal a = new Animal();
            //a.Name = "Elephant";
            //a.BodyPart = "Trunk";
            //a.YellType = "Trumpets";
            //a.SkinColour = Colors.Gray;

            //Animal b = new Animal();
            //b.Name = "Elephant";
            //b.BodyPart = "Trunk";
            //b.YellType = "Trumpets";
            //b.SkinColour = Colors.Gray;

            //Animal c = new Animal();
            //c.Name = "Elephant";
            //c.BodyPart = "Trunk";
            //c.YellType = "Trumpets";
            //c.SkinColour = Colors.Gray;

            //List<Animal> col = new List<Animal>();
            //col.Add(a);
            //col.Add(b);


            //string xml = XMLHelper.GetXMLFromObject(col);

            //XMLDataSource data = new XMLDataSource();
            //data.AddAnimal(c);
        }

        private void DisplayMessage(object sender, EventArgs args)
        {
            MessageBox.Show("The animal name is " + ((Animal)sender).Name);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddAnimal addAnimal = new AddAnimal();
            addAnimal.Show();
            addAnimal.Closing += AddAnimal_Closing;
        }

        private void AddAnimal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ((StartViewModel)this.DataContext).RefreshAnimals();
        }
    }
}
