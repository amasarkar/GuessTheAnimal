using GuessTheAnimal.DAL;
using GuessTheAnimal.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace GuessTheAnimal.ViewModel
{
    public class StartViewModel : ViewModelBase
    {
        private XMLDataSource dataSource = new XMLDataSource();
        private IAnimalGuesser guesser = default(IAnimalGuesser);
        public StartViewModel(IAnimalGuesser guesser)
        {
            animals = new ObservableCollection<Animal>(dataSource.GetAnimals());
            this.guesser = guesser;
            this.guesser.Animals = animals;
            question = this.guesser.NextQuestion();
            answers = new ObservableCollection<string>(this.guesser.GetAnswers());         
        }

        private string question;

        public string Question
        {
            get
            {
                return question;
            }

            set
            {
                question = value;
                this.OnPropertyChanged("Question");
            }
        }

        private ObservableCollection<string> answers;

        public ObservableCollection<string> Answers
        {
            get
            {
                return answers;
            }
            set
            {
                answers = value;
                this.OnPropertyChanged("Answers");
            }
        }

        private string selectedAnswer;

        public string SelectedAnswer
        {
            get { return selectedAnswer; }
            set { selectedAnswer = value; }
        }



        private ObservableCollection<Animal> animals;
        public ObservableCollection<Animal> Animals
        {
            get { return animals; }
            set
            {
                animals = value;
                this.OnPropertyChanged("Animals");
            }
        }

        private ICommand guessCommand;

        public ICommand GuessCommand
        {
            get
            {
                if (guessCommand == null)
                {
                    guessCommand = new RelayCommand(param => this.GuessOperation(), param => this.CanGuess());
                }
                return guessCommand;
            }
            set { guessCommand = value; }
        }

        public EventHandler DisplayMessage;

        private bool CanGuess()
        {
            return !string.IsNullOrEmpty(this.Question) && !string.IsNullOrEmpty(this.SelectedAnswer);
        }

        private void FoundAnswer(Animal animal)
        {
            this.DisplayMessage(animal, null);
        }

        private void Play()
        {

        }

        private void GuessOperation()
        {
            Animal guessAnimal = this.guesser.Match(this.Question, this.SelectedAnswer);
            if (guessAnimal == null)
            {
                this.Question = this.guesser.NextQuestion();
                this.Answers = new ObservableCollection<string>(this.guesser.GetAnswers()); 
            }
            else
            {
                this.FoundAnswer(guessAnimal);
            }
        }

        public void RefreshAnimals()
        {
            this.Animals = new ObservableCollection<Animal>(dataSource.GetAnimals());
        }
    }
}
