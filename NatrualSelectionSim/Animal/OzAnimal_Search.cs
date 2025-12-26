using Ozeki;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace NatrualSelectionSim
{
    public partial class OzAnimal
    {
        List<OzPlant> _currentSurroundings;
        OzPlant _plantTarget;
        OzPoint2D _searchtarget;
        bool searching = true;
        private void search()
        {
            _currentSurroundings = _getSurroundings(this);
            List<OzPlant> _newSurroundings = _currentSurroundings.ToArray().ToList();
            foreach (var p in _currentSurroundings)
            {
                if (p._circle.Dimentions.Radius + (int)Traits.Size.Strength < Position.GetDist(p._pos)) continue;
                _newSurroundings.Remove(p);
                lock (p)
                {
                    p.Kill();
                        
                }
                _numOfFoodCollected++;
            }
            _currentSurroundings = _newSurroundings;
            if (searching)
            {
                Search();
                return;
            }
            if (!isTargetExisting() || _plantTarget == null)
            {
                searching = true;
                return;
            }
        }

        private void Search()
        {
            if (_currentSurroundings.Count > 0)
            {
                searching = false;
                _plantTarget = GetClosest();
                _target = _plantTarget._pos;
                return;
            }
            if (Position == _searchtarget || _searchtarget == new OzPoint2D(0, 0))
                generateSearchTarget();
        }

        private bool isTargetExisting()
        {
            if (searching) return true;
            lock (_currentSurroundings)
            {
                for (int x = 0; x < _currentSurroundings.Count; x++)
                {
                    if (_currentSurroundings[x] == _plantTarget) return true;
                }
            }
            return false;
        }

        private OzPlant GetClosest()
        {
            lock (_currentSurroundings)
            {
                var closest = _currentSurroundings[0];
                for (int x = 1; x < _currentSurroundings.Count; x++)
                {
                    if (Position.GetDist(closest._pos) > Position.GetDist(_currentSurroundings[x]._pos)) closest = _currentSurroundings[x];
                }
                return closest;
            }
        }



        private void generateSearchTarget()
        {
            var xBound = _r.Next((int)(Traits.Sense.Strength * -1 + Position.X), (int)(Traits.Sense.Strength + Position.X));
            var yBound = _r.Next((int)(Traits.Sense.Strength * -1 + Position.Y), (int)(Traits.Sense.Strength + Position.Y));
            _searchtarget = new OzPoint2D(xBound, yBound);
            realiseTarget();
            _target = _searchtarget;
        }

        private void realiseTarget()
        {
            while (GFX.canvas == null) ;
            if (_searchtarget.X < (int)Traits.Size.Strength)             
                _searchtarget.X = Traits.Size.Strength + ((int)Traits.Size.Strength - _searchtarget.X);
            
            else if (_searchtarget.X > GFX.canvas.ActualWidth - (int)Traits.Size.Strength)
                _searchtarget.X = GFX.canvas.ActualWidth - (int)Traits.Size.Strength - (GFX.canvas.ActualWidth - (int)Traits.Size.Strength - _searchtarget.X);
            
            if (_searchtarget.Y < (int)Traits.Size.Strength)
                _searchtarget.Y = Traits.Size.Strength + ((int)Traits.Size.Strength - _searchtarget.Y);

            else if (_searchtarget.Y > GFX.canvas.ActualHeight - (int)Traits.Size.Strength)
                _searchtarget.Y = GFX.canvas.ActualHeight - (int)Traits.Size.Strength - (GFX.canvas.ActualHeight - (int)Traits.Size.Strength - _searchtarget.Y);
        }
    }
}
