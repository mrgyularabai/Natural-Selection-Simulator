using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ozeki
{
    public partial class OzEntity
    {

        public OzEntity(ref Canvas canvas)
        {
            Position = new OzPoint2D(0, 0);
            ID = 0;
            drawComponents(ref canvas);
            _tickspeedup = 1;
        }

        public OzEntity(int iD, ref Canvas canvas)
        {
            Position = new OzPoint2D(0, 0);
            ID = iD;
            init(ref canvas, iD);
        }

        public OzEntity(OzPoint2D position, int iD, ref Canvas canvas) 
        {
            Position = position;
            ID = iD;
            init(ref canvas, iD);
        }

        public OzEntity(double x, double y, int iD, ref Canvas canvas)
        {
            Position = new OzPoint2D(x, y);
            ID = iD;
            init(ref canvas, iD);
        }

        public OzEntity(double x, int iD, ref Canvas canvas)
        {
            Position = new OzPoint2D(x, x);
            init(ref canvas, iD);
        }

        private void init(ref Canvas canvas, int iD)
        {
            drawComponents(ref canvas);
            ID = iD;
            _tickspeedup = 1;
            SelfInit();
        }

        protected virtual void SelfInit()
        {

        }
    }
}
