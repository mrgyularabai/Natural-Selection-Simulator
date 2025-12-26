using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozeki
{
    public partial struct OzVector2D
    {
        public OzVector2D(double[] r2)
        {
            R2 = r2;
        }

        public OzVector2D(double r2e0, double r2e1)
        {
            R2 = new double[2];
            R2[0] = r2e0;
            R2[1] = r2e1;
        }

        public double[] R2; 

        public double GetLenght()
        {
            var calSqured = R2[0] * R2[0] + R2[1] * R2[1];
            if (calSqured == 0) return 1;
            double result = Math.Sqrt(Math.Abs(calSqured));
            if (calSqured < 0) result *= -1;
            return result;
        }

        public void SetLength(double newlength)
        {
            double devisor = GetLenght()/newlength;
            this = this / devisor;
        }
    }
}
