using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatrualSelectionSim
{
    public class OzTrait
    {
        public OzTrait(float strength, OzMutationRate mutationRate)
        {
            Strength = strength;
            _mutationRate = mutationRate;
        }
        public float Strength;
        private OzMutationRate _mutationRate;
        public void NextGen()
        {
            var r = new Random();
            Strength = _mutationRate.NextStrength(ref r, Strength);
        }
    }
}
