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
    partial class OzPlant
    {

        private List<OzGFXComponent> Genenration()
        {
            var apearence = new OzGFXApearence(Colors.Green, Colors.Black, 1);
            _circle = new OzGFXCircle(3,apearence,_pos);
            var result = new List<OzGFXComponent>(1);
            result.Add(_circle);
            return result;
        }
    }
}
