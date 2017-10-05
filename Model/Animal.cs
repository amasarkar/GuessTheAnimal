using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GuessTheAnimal.Model
{
    public class Animal
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string bodyPart;
        public string BodyPart
        {
            get { return bodyPart; }
            set { bodyPart = value; }
        }

        private string yellType;
        public string YellType
        {
            get { return yellType; }
            set { yellType = value; }
        }

        private Color skinColour;
        public Color SkinColour
        {
            get { return skinColour; }
            set { skinColour = value; }
        }

    }
}
