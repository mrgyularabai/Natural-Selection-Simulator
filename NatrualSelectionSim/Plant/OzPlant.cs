using Ozeki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace NatrualSelectionSim
{
    public partial class OzPlant
    {
        public OzPlant(OzPoint2D pos, Action<object> killMe)
        {
            _killMe = killMe;
            _pos = pos;
            GFX = new OzGFX(Genenration());
        }

        Action<object> _killMe;
        public OzGFXCircle _circle;
        public OzGFX GFX;
        public OzPoint2D _pos;
        bool rotting;
        int _grow;
        int _rott;
        int _growthSlowness = 5;
        int _rottSlowness = 4;
        int _ReddeningSpeed = 10;
        public const int _minRadius = 20;
        public const int _maxRadius = 27;
        int _maxRedness = 100;

        public void HandleTick()
        {
            rott();
            if (reGrow())return;
            grow();
        }

        void rott()
        {
            if (!rotting) return;
            if (_circle.Dimentions.Radius <= _minRadius) 
            {
                rotting = false;
                return;
            }
            if (_circle.Apearence.Fill.R <= _maxRedness) _circle.Apearence.Fill.R = (byte)(_circle.Apearence.Fill.R + _ReddeningSpeed);
            if (_rott == _rottSlowness)
            {
                _circle.Dimentions.Radius--;
                _rott = 0;
            }
            _rott++;
        }

        void grow()
        {
            if (_grow == _growthSlowness)
            {
                _circle.Dimentions.Radius++;
                _grow = 0;
            }
            _grow++;
        }

        bool reGrow()
        {
            if (rotting) return true;
            if (_circle.Apearence.Fill.R != 0) _circle.Apearence.Fill.R--;
            if (_circle.Dimentions.Radius < _maxRadius)return false;
            rotting = true;
            return true;
        }

        public void Kill()
        {
            _killMe(this);
        }

    }
}
