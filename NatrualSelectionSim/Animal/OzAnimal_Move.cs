using Ozeki;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace NatrualSelectionSim
{
    partial class OzAnimal
    {
        private OzPoint2D _oldTarget;
        private OzPoint2D _target;
        private OzVector2D _velocety;
        public OzPoint2D Position;

        private void move()
        {
            if (isTargetChanged()) calculateVelocety();
            if (isInJumpRange()) jump();
            else step();
        }

        private bool isTargetChanged()
        {
            var result = _oldTarget != _target;
            if (result) _oldTarget = _target;
            return result;
        }

        private bool isInJumpRange()
        {
            return (Position - _target).GetLenght() < Traits.Speed.Strength;
        }

        private void jump()
        {
            Position = _target;
            _velocety = new OzVector2D(0, 0);
        }

        private void calculateVelocety()
        {
            var newVelocety = Position - _target;
            newVelocety.SetLength(Traits.Speed.Strength);
            _velocety = newVelocety;
        }

        private void step()
        {
            var res = Position + _velocety;
            while (GFX.canvas == null);
            if (res.X < (int)Traits.Size.Strength)
            {
                res.X = (int)Traits.Size.Strength;
                _velocety.R2[0] *= -1;
            }
            else if (res.X > GFX.canvas.ActualWidth - (int)Traits.Size.Strength)
            {
                res.X = GFX.canvas.ActualWidth - (int)Traits.Size.Strength;
                _velocety.R2[0] *= -1;
            }
            if (res.Y < (int)Traits.Size.Strength)
            {
                res.Y = (int)Traits.Size.Strength;
                _velocety.R2[1] *= -1;
            }
            else if (res.Y > GFX.canvas.ActualHeight - (int)Traits.Size.Strength)
            {
                res.Y = GFX.canvas.ActualHeight - (int)Traits.Size.Strength;
                _velocety.R2[1] *= -1;
            }
            Position = res;
            _circle.Position = Position;
        }
    }
}
