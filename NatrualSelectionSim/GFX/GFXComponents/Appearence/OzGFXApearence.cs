using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace NatrualSelectionSim
{
    public class OzGFXApearence
    {
        public OzGFXApearence(Color fill, Color borderFill, int borderThickness)
        {
            Fill = fill;
            BorderFill = borderFill;
            BorderThickness = borderThickness;
        }
        public Color Fill;
        public Color BorderFill;
        public int BorderThickness;

        public SolidColorBrush GetFillBrush()
        {
            return new SolidColorBrush(Fill);
        }
        public SolidColorBrush GetBorderBrush()
        {
            return new SolidColorBrush(BorderFill);
        }
    }
}
