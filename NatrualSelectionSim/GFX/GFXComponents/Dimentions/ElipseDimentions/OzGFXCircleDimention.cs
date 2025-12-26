using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatrualSelectionSim
{
    public class OzGFXCircleDimention : OzGFXDimentions
    {
        public int Radius;
        protected override int GetHeight()
        {
            return Radius*2;
        }
        protected override int GetWidth()
        {
            return Radius*2;
        }
    }
}
