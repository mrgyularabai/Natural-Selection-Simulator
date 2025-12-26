using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozeki
{
    public partial struct OzPoint2D
    {
        public OzPoint2D(int x, int y)
        {
            X = x;
            Y = y;
        }
        public OzPoint2D(float x, float y)
        {
            X = x;
            Y = y;
        }
        public OzPoint2D(double x, double y)
        {
            X = x;
            Y = y;
        }
        public OzPoint2D(double both)
        {
            X = both;
            Y = both;
        }
    }
}
