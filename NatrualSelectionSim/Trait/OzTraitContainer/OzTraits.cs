using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatrualSelectionSim
{
    public class OzTraits
    {
        public OzTraits(float[] traits, float mutation)
        {
            Speed = new OzTrait(traits[0], new OzMutationRate(mutation, 0.5f));
            Size = new OzTrait(traits[1], new OzMutationRate(mutation, 2));
            Eficiencey = new OzTrait(traits[2], new OzMutationRate(mutation, 0.02f));
            Sense = new OzTrait(traits[3], new OzMutationRate(mutation, 1));
            _maxEnergy = Size.Strength*Size.Strength*Size.Strength * Eficiencey.Strength;
            _currentMaxEnergy = _maxEnergy;
        }

        public OzTrait Speed;
        public OzTrait Sense;
        public OzTrait Size;
        public OzTrait Eficiencey;
        float _maxEnergy;
        float _currentMaxEnergy;
        float _limiter = 0.3f;
        float _scaler = 0.001f; //so it is not too easy or hard for them

        public void Refill()
        {
            _currentMaxEnergy = _maxEnergy;
        }

        public float Tick()
        {
            _currentMaxEnergy -= energycost();
            return _currentMaxEnergy;
        }

        public float energycost()
        {
            var efficencyMultiplyer = 1 - Eficiencey.Strength + _limiter;
            var speedCost = Speed.Strength * Size.Strength;
            return (speedCost + Sense.Strength) * efficencyMultiplyer * _scaler;
        }

        public OzTraits nextGen()
        {
            var nextTraits = this;
            nextTraits.Speed.NextGen();
            nextTraits.Size.NextGen();
            nextTraits.Sense.NextGen();
            nextTraits.Eficiencey.NextGen();
            return nextTraits;
        }
    }
}
