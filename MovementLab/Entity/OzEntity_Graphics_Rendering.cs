using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Ozeki
{
    partial class OzEntity
    {
        
        protected int Raduis { get; private set; }
        protected Color Fill;
        protected Color BorederFill;
        protected int BorderThickness;

        protected virtual void InitGraphics()
        {
            Raduis = 50;
            Fill = Colors.Green;
            BorederFill = Colors.Black;
            BorderThickness = 1;
        }
        
        public virtual void Render(ref Canvas canvas)
        {

        }
    }
}
