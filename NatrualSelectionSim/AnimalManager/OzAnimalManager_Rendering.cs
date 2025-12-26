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
    partial class OzAnimalManager
    {
        Canvas canvas;
        public void Render()
        {
            pingOn();
            update();
        }
        private void update()
        {
            lock (Animals)
            {
                if (Animals.Count == 0) return;
                for (int x = 0; x < Animals.Count; x++)
                {
                    Animals[x].GFX.Update();
                }
            }
        }
        private void pingOn()
        {

            lock (ToBePingedOn)
            {
                for (int x = 0; x < ToBePingedOn.Count; x++)
                {
                    ToBePingedOn[x].GFX.PingOn(canvas);
                }
                ToBePingedOn.Clear();
            }

            lock (ToBePingedOff)
            {
                for (int x = 0; x < ToBePingedOff.Count; x++)
                {
                    ToBePingedOff[x].GFX.unPing();
                }
                ToBePingedOff.Clear();
            }
        }
    }
}
