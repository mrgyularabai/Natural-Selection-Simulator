using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozeki
{
    public partial class OzMovingEntity : OzEntity
    {
        protected OzPoint2D Destination;
        protected int Speed;
        private OzPoint2D _oldDestiantion;
        private OzVector2D _velocety;

        public void SetDestination(OzPoint2D newDest)
        {
            Destination = newDest;
        }
        protected override void TickRequestHandler()
        {
            Position += _velocety;
            if (checkForDestination()) calculateVelocety();
            if (checkIfInJumpRange()) jump();
            move();
        }

        private bool checkForDestination()
        {
            var result = _oldDestiantion != Destination;
            if (result) _oldDestiantion = Destination;
            return !result;
        }

        private bool checkIfInJumpRange()
        {
            return (Position - Destination).GetLenght() < _velocety.GetLenght();
        }

        private void jump()
        {
            Position = Destination;
            _velocety = new OzVector2D(0, 0);
        }

        private void calculateVelocety()
        {
            var newVelocety = (Position - Destination);
            newVelocety.SetLength(Speed);
            _velocety = newVelocety;
        }

        private void move()
        {
            Position += _velocety;
        }
    }
}
