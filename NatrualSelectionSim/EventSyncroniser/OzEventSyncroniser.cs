using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;

namespace NatrualSelectionSim
{
    public partial class OzEventSyncroniser
    {
        private SimulationWindow _gfx;

        public void Start(int plantNum, int daylen, int w, int h)
        {
            var canvas = windowing(w,h);
            bindWindowEvents();
            OzWorld.Instance.Start(canvas,_gfx.RefreshDayCount,_gfx.Wave,_gfx.GfxWave,plantNum,daylen);
        }

        private Canvas windowing(int w, int h)
        {
            _gfx = new SimulationWindow(w,h);
            _gfx.Show();
            MainWindow.Instence.Hide();
            return _gfx.Paper;
        }

        private void bindWindowEvents()
        {
            _gfx.SpeedUp.LostFocus += SetSpeed;
            _gfx.SpeedUp.KeyDown += SetSpeedExit;
            _gfx.PauseOrResume.Click += PauseOrResume;
            _gfx.Closing += End;
            _gfx.Closed += (object o, EventArgs e) => { _gfx = null; };
            _gfx.End.Click += (object o, RoutedEventArgs e) => { _gfx.Close(); };
        }

        private void SetSpeedExit(object o, KeyEventArgs e)
        {
            if(e.Key == Key.Enter) 
                _gfx.PauseOrResume.Focus();
        }

        private void SetSpeed(object o, EventArgs e)
        {
            _gfx.SpeedUp.Text = (OzWorld.Instance.SetSpeed(_gfx.SpeedUp.Text)).ToString();
        }

        private void PauseOrResume(object o, RoutedEventArgs e)
        {
            if (OzWorld.Instance.GetStatus())
            {
                _gfx.PauseOrResume.Content = "Pause";
                OzWorld.Instance.Resume();
                return;
            }
            _gfx.PauseOrResume.Content = "Resume";
            OzWorld.Instance.Pause();
        }

        private void End(object o, EventArgs e)
        {
            MainWindow.Instence.Show();
            OzWorld.Instance.End();
        }
    }
}
