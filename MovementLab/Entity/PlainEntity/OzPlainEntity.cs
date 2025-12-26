using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ozeki
{
    public class OzPlainEntity : OzEntity
    {
        public OzPlainEntity(ref Canvas canvas) :
            base(ref canvas)
        {

        }

        public OzPlainEntity(int iD, ref Canvas canvas) :
            base(iD, ref canvas)
        {

        }

        public OzPlainEntity(OzPoint2D position, int iD, ref Canvas canvas) :
            base(position, iD, ref canvas)
        {

        }

        public OzPlainEntity(double x, double y, int iD, ref Canvas canvas) :
            base(x, y, iD, ref canvas)
        {

        }

        public OzPlainEntity(double x, int iD, ref Canvas canvas) :
            base(x, iD, ref canvas)
        {

        }
    }
}
