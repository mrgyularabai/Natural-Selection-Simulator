using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatrualSelectionSim
{
    public struct OzMutationRate
    {
        public OzMutationRate(float probobility, float speed)
        {
            _probobility = probobility;
            _speed = speed;
        }
        float _probobility;
        float _speed;
        public float NextStrength(ref Random random, float currentStrength)
        {
            random = new Random();
            if (_probobility >= random.NextDouble()) 
            {
                if (UpOrDown(ref random)) return currentStrength + _speed;
                return currentStrength - _speed;
            }
            return currentStrength;
        }

        public bool UpOrDown(ref Random random)
        {
            if (0.5 >= random.NextDouble()) return true;
            return false;
        }
    }
}
