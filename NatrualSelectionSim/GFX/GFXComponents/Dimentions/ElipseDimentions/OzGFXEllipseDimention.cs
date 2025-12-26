using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatrualSelectionSim
{
    public class OzGFXEllipseDimention : OzGFXDimentions
    {
        public int RadiusW;
        public int RadiusH;
        protected override int GetHeight()
        {
            return RadiusH * 2;
        }
        protected override int GetWidth()
        {
            return RadiusW * 2;
        }
    }
}
