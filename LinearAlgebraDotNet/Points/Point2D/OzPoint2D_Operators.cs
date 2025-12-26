using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows;

namespace Ozeki
{
    public partial struct OzPoint2D
    {
        public static OzPoint2D operator +(OzPoint2D left,OzVector2D right)
        {
            return new OzPoint2D(left.X + right.R2[0], left.Y + right.R2[1]);
        }

        public static OzPoint2D operator +(OzVector2D right, OzPoint2D left)
        {
            return new OzPoint2D(left.X + right.R2[0], left.Y + right.R2[1]);
        }
        public static OzVector2D operator -(OzPoint2D left, OzPoint2D right)
        {
            return new OzVector2D(right.X - left.X, right.Y - left.Y);
        }

        public static implicit operator OzVector2D(OzPoint2D point)
        {
            return new OzVector2D(point.X, point.Y);
        }

        public static implicit operator OzPoint2D(Point point)
        {
            return new OzPoint2D(point.X, point.Y);
        }

        public static bool operator !=(OzPoint2D right, OzPoint2D left)
        {
            return right.X != left.X || right.Y != left.Y;
        }
        public static bool operator ==(OzPoint2D right, OzPoint2D left)
        {
            return right.X == left.X && right.Y == left.Y;
        }
    }
}
