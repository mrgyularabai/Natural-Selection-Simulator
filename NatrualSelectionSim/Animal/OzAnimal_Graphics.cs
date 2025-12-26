using Ozeki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace NatrualSelectionSim
{
    partial class OzAnimal
    {

        private List<OzGFXComponent> Genenration()
        {
            var apearence = new OzGFXApearence(Colors.Red, Colors.Black, 0);
            _circle = new OzGFXCircle((int)Traits.Size.Strength,apearence,Position);
            var result = new List<OzGFXComponent>(1);
            result.Add(_circle);
            return result;
        }
    }
}
