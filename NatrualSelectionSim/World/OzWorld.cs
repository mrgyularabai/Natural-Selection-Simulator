using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NatrualSelectionSim
{
    public partial class OzWorld
    {
        private bool _paused;
        public void Start(Canvas gfx, Action<int> refday,Action wave, Action waveGfx, int numplants, int daylen)
        {
            _paused = false;
            startRender(gfx, refday, waveGfx);
            startTick(daylen, numplants, wave);
        }

        public bool GetStatus()
        {
            return _paused;
        }

        public int SetSpeed(string speed)
        {
            _speedUp = ValidityCheck(speed);
            return _speedUp;
        }

        public int ValidityCheck(string input)
        {
            input.Replace(" ", "");
            input.Replace(",", ".");

            var result = 0;
            if (int.TryParse(input, out result)) return result;

            double resultD = 0;
            if (double.TryParse(input, out resultD)) 
                return (int)Math.Round(resultD);

            return 1;
        }

        public void Pause()
        {
            _paused = true;
        }

        public void Resume()
        {
            _paused = false;
            resumeTicking();
        }

        public void End()
        {
            endTick();
            endRender();
            
        }
    }
}
