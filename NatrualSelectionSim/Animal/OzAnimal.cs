using Ozeki;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NatrualSelectionSim
{
    public partial class OzAnimal
    {
        public OzAnimal(OzPoint2D pos, Func<OzAnimal, List<OzPlant>> getSurroundings, Action<OzAnimal> killMe, Action<OzTraits> reproduce, OzTraits traits)
        {
            _killMe = killMe;
            _reproduce = reproduce;
            Traits = traits;
            _getSurroundings = getSurroundings;
            GFX = new OzGFX(Genenration());
            _r = new Random();
            Position = pos;
            _circle.Position = Position;
            _Home = Position;
            _target = _Home;
        }
        Action<OzAnimal> _killMe;
        Action<OzTraits> _reproduce;
        OzGFXCircle _circle;
        public OzGFX GFX;
        int _numOfFoodCollected;
        OzPoint2D _Home;
        bool DayEnded;
        Random _r;
        Func<OzAnimal, List<OzPlant>> _getSurroundings;
        //traits
        public OzTraits Traits;

        public void HandleTick()
        {
            move();
            if (DayEnded) 
                return; // if you run out of time stop
            search();
            if (Traits.Tick() <= 0) //if you run out of engergy stop
            {
                DayEnded = true;
                return;
            }
            if (_numOfFoodCollected == 2)
            {
                DayEnded = true;
                return;
            }
        }
        public void EndDay()
        {
            DayEnded = true;
            _target = _Home;
            var numfood = _numOfFoodCollected;
            _numOfFoodCollected = 0;
            if (numfood == 0)
            {
                _killMe(this);
                return;
            }
            Traits.Refill();
            DayEnded = false;
            if (numfood == 1) return;
            _reproduce(Traits.nextGen());
        }
    }
}
