using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ozeki
{
    partial class OzMovingEntity
    {
        public OzMovingEntity(ref Canvas canvas) : 
            base(ref canvas)
        {

        }

        public OzMovingEntity(int iD, ref Canvas canvas) : 
            base(iD, ref canvas)
        {

        }

        public OzMovingEntity(OzPoint2D position, int iD, ref Canvas canvas) : 
            base( position, iD, ref canvas)
        {

        }

        public OzMovingEntity(double x, double y, int iD, ref Canvas canvas) : 
            base(x,  y, iD, ref canvas)
        {

        }

        public OzMovingEntity(double x, int iD, ref Canvas canvas) : 
            base( x, iD, ref canvas)
        {

        }

        protected override void SelfInit()
        {
            _velocety = new OzVector2D(0, 0);
            Destination = Position;
            _oldDestiantion = Destination;
            Speed = 5;
        }
    }
}
