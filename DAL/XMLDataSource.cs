using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessTheAnimal.Model;
using System.Xml;
using GuessTheAnimal.Helper;

namespace GuessTheAnimal.DAL
{
    class XMLDataSource : IDataSource
    {
        private static XmlDocument doc = new XmlDocument();
        private static List<Animal> animals = new List<Animal>();
        static XMLDataSource()
        {
            doc.Load("DAL/Data.xml");
            animals = (List<Animal>)XMLHelper.GetObjectFromXML(doc.InnerXml, animals.GetType());
        }
        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
            doc.LoadXml(XMLHelper.GetXMLFromObject(animals));
            doc.Save("DAL/Data.xml");
        }

        public IList<Animal> GetAnimals()
        {
            return animals;
        }
    }
}
