using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GuessTheAnimal.Helper
{
    public static class ColorExtension
    {
        public static string GetName(this Color color)
        {
            PropertyInfo colorProperty = typeof(Colors).GetProperties()
        .FirstOrDefault(p => Color.AreClose((Color)p.GetValue(null), color));
            return colorProperty != null ? colorProperty.Name : "unnamed color";
        }
    }
}
