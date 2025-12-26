using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozeki
{
    partial struct OzVector2D
    {
        public static OzPoint2D operator +(OzVector2D right, OzVector2D left)
        {
            return new OzPoint2D(left.R2[0] + right.R2[0], left.R2[1] + right.R2[1]);
        }

        public static OzVector2D operator -(OzVector2D right, OzVector2D left)
        {
            return new OzVector2D(right.R2[0] - left.R2[0], right.R2[1] - left.R2[1]);
        }

        public static OzVector2D operator *(OzVector2D right, OzVector2D left)
        {
            return new OzVector2D(right.R2[0] * left.R2[0], right.R2[1] * left.R2[1]);
        }
        public static OzVector2D operator /(OzVector2D right, OzVector2D left)
        {
            return new OzVector2D(right.R2[0] / left.R2[0], right.R2[1] / left.R2[1]);
        }
        public static OzVector2D operator *(OzVector2D right, double left)
        {
            return new OzVector2D(right.R2[0] * left, right.R2[1] * left);
        }
        public static OzVector2D operator /(OzVector2D right, double left)
        {
            return new OzVector2D(right.R2[0] / left, right.R2[1] / left);
        }

        public static explicit operator OzPoint2D(OzVector2D vec)
        {
            return new OzPoint2D(vec.R2[0],vec.R2[1]);
        }

        public static bool operator !=(OzVector2D right, OzVector2D left)
        {
            return right.R2 != left.R2;
        }
        public static bool operator ==(OzVector2D right, OzVector2D left)
        {
            return right.R2 == left.R2;
        }
    }
}
