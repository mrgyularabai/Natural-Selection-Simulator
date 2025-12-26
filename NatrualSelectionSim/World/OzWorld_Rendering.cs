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
    partial class OzWorld
    {
        private Canvas _gfx;
        private Action<int> _refreshDayCountMethod;
        private Action _waveGfx;

        private void startRender(Canvas canvas, Action<int> refD, Action waveGfx)
        {
            _waveGfx = waveGfx;
            _refreshDayCountMethod = refD;
            _gfx = canvas;
            CompositionTarget.Rendering += render;
        }

        private void render(object o, EventArgs e)
        {
            if (_paused) return;
            if (_refreshDayCount)
            {
                _refreshDayCountMethod.Invoke(_numOfDays);
                _refreshDayCount = false;
            }
            _waveGfx.Invoke();
            OzPlantManager.Instance.Render();
            OzAnimalManager.Instance.Render();
        }
        private void endRender()
        {
            CompositionTarget.Rendering -= render;
            _gfx = null;
        }
    }
}
