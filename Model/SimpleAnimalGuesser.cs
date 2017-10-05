using GuessTheAnimal.Helper;
using System.Collections.Generic;
using System.Linq;

namespace GuessTheAnimal.Model
{
    class SimpleAnimalGuesser : IAnimalGuesser
    {
        private bool rightBodyPart = false;
        private bool rightYellType = false;
        private bool rightSkinCOlor = false;
        private string answeredBodyPart = string.Empty;
        private string answeredSkinColor = string.Empty;
        private string answeredYellType = string.Empty;
        private Animal guessAnimal = new Animal();
        private string question = string.Empty;

        public IList<Animal> Animals
        {
            get;

            set;
        }

        public SimpleAnimalGuesser()
        {
            
        }
        public string NextQuestion()
        {
            if (!rightBodyPart)
            {
                question =  Constants.BODYPARTQUESTION;
            }
            else if (!rightYellType)
            {
                question =  Constants.YELLTYPEQUESTION;
            }
            else //if (!rightSkinCOlor)
            {
                question =  Constants.SKINCOLORQUESTION;
            }

            return question;
        }

        public Animal Match(string currentQuestion, string currentAnswer)
        {
            if (question.Equals(Constants.BODYPARTQUESTION))
            {
                answeredBodyPart = currentAnswer;
                rightBodyPart = true;
            }
            else if (question.Equals(Constants.YELLTYPEQUESTION))
            {
                answeredYellType = currentAnswer;
                rightYellType = true;
            }
            else
            {
                answeredSkinColor = currentAnswer;
                rightSkinCOlor = true;
            }

            if (answeredBodyPart != null && answeredYellType != null && answeredSkinColor != null)
            {
                return this.Animals.Where(x => x.BodyPart.Equals(answeredBodyPart) && x.YellType.Equals(answeredYellType) && x.SkinColour.GetName().Equals(answeredSkinColor)).FirstOrDefault();
            }
            else
                return null;
        }

        public IList<string> GetAnswers()
        {
            List<string> result = new List<string>();
            if (question.Equals(Constants.BODYPARTQUESTION))
            {
                result = Animals.Select(x => x.BodyPart).ToList();
            }
            else if (question.Equals(Constants.YELLTYPEQUESTION))
            {
                result = Animals.Select(x => x.YellType).ToList();
            }
            else
            {
                result = Animals.Select(x => x.SkinColour.GetName()).ToList();
            }

            return result;
        }
    }
}
