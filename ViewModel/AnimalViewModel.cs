using GuessTheAnimal.DAL;
using GuessTheAnimal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace GuessTheAnimal.ViewModel
{
    class AnimalViewModel : ViewModelBase
    {
        IDataSource dataSource = new XMLDataSource();
        private Animal animal = new Animal();

        public AnimalViewModel(IDataSource dataSource, Animal animal)
        {
            this.dataSource = dataSource;
        }


        private string name;


        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                animal.Name = value;
                this.OnPropertyChanged("Name");
            }
        }

        private string bodyPart;

        public string BodyPart
        {
            get { return bodyPart; }
            set
            {
                bodyPart = value;
                animal.BodyPart = value;
                this.OnPropertyChanged("BodyPart");
            }
        }

        private string yellType;

        public string YellType
        {
            get { return yellType; }
            set
            {
                yellType = value;
                animal.YellType = value;
                this.OnPropertyChanged("YellType");
            }
        }

        private string skinColor;

        public string SkinColor
        {
            get { return skinColor; }
            set
            {
                skinColor = value;
                animal.SkinColour = (Color)ColorConverter.ConvertFromString(value);
                this.OnPropertyChanged("SkinColor");
            }
        }

        private ICommand addCommand;

        public ICommand AddCommand
        {
            get
            {
                if (this.addCommand == null)
                {
                    this.addCommand = new RelayCommand(param => this.SaveAnimal(), param => this.CanAddAnimal());
                }
                return addCommand;
            }
            set
            {
                addCommand = value;
                this.OnPropertyChanged("AddCommand");
            }
        }

        private bool CanAddAnimal()
        {
            return !string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.bodyPart) && !string.IsNullOrEmpty(this.YellType) && this.SkinColor != null;
        }

        private void SaveAnimal()
        {
            this.dataSource.AddAnimal(this.animal);
            this.Close(null, null);
        }

        public EventHandler Close;
    }
}
