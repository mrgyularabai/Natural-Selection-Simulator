using System;
using Ozeki;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;

namespace NatrualSelectionSim
{
    public partial class OzPlantManager
    {
        public List<OzPlant> Plants = new List<OzPlant>();
        public List<OzPlant> ToBePingedOn;
        public List<OzPlant> ToBePingedOff;
        Canvas canvas;
        Random _r;
        int _numOfPlants;
        public void Start(Canvas _canvas, int numOfPlants, ref Random r)
        {
            _r = r;
            canvas = _canvas;
            _numOfPlants = numOfPlants;
            Plants = new List<OzPlant>(numOfPlants);
            ToBePingedOn = new List<OzPlant>(numOfPlants);
            ToBePingedOff = new List<OzPlant>(numOfPlants);
            for (int x = 0; x < numOfPlants; x++)
            {
                Spawn();
            }
        }
        public void Spawn()
        {
            lock(Plants)
            {
                lock (ToBePingedOn)
                {
                    var x = _r.Next((OzPlant._maxRadius + 10), (int)canvas.ActualWidth - (OzPlant._maxRadius + 9));
                    var y = _r.Next((OzPlant._maxRadius + 10), (int)canvas.ActualHeight - (OzPlant._maxRadius + 9));
                    var p = new OzPlant(new OzPoint2D(x, y), kill);
                    Plants.Add(p);
                    ToBePingedOn.Add(p);
                }
            }
        }

        private void kill(object o)
        {
            lock (Plants)
            {
                lock (ToBePingedOff)
                {
                    ToBePingedOff.Add((OzPlant)o);
                    Plants.Remove((OzPlant)o);
                }
            }
        }

        public void HandleTick()
        {
            lock (Plants)
            {
                for (int x = 0; x < Plants.Count; x++)
                {
                    Plants[x].HandleTick();
                }
            }
        }

        public void HandleDay()
        {
            lock (Plants)
            {
                while (Plants.Count != 0)
                {
                    Plants[0].Kill();
                }

                for (int x = 0; x < _numOfPlants; x++)
                {
                    Spawn();
                }
            }
        }
    }
}
