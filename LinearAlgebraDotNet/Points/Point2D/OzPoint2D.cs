using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozeki
{
    public partial struct OzPoint2D
    {
        public double X;
        public double Y;

        public double GetDist(OzPoint2D other)
        {
            return (this-other).GetLenght();
        }
    }
}
