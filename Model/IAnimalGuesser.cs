using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheAnimal.Model
{
    public interface IAnimalGuesser
    {
        IList<Animal> Animals { get; set; }
        string NextQuestion();
        Animal Match(string currentQuestion, string currentAnswer);

        IList<string> GetAnswers();
    }
}
