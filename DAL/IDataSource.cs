using GuessTheAnimal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GuessTheAnimal.DAL
{
    interface IDataSource
    {
        void AddAnimal(Animal animal);

        IList<Animal> GetAnimals();
    }
}
