using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Diagnostics;

namespace NatrualSelectionSim
{
    partial class OzWorld
    {
        //time
        private int _numOfDays;
        private int _lenghtOfADay;
        private int _numOfHours;
        private int _lenghtOfAnHour;
        private int _numOfTick;
        //GFX
        private bool _refreshDayCount;
        private Action _wave;
        //setting up
        private Random _random;
        private int _numOfPlants;
        //Ticking
        private Timer _timer;
        private int _speedUp;

        private void startTick(int lenghtOfADay, int numOfPlants, Action wave)
        {
            //Time
            _numOfTick = 1;
            _numOfHours = 0;
            _lenghtOfAnHour = 360;
            _numOfDays = 0;
            _lenghtOfADay = lenghtOfADay;
            _speedUp = 1;
            //GFX
            _wave = wave;
            _refreshDayCount = true;
            //settingUp
            _numOfPlants = numOfPlants;
            _random = new Random();
            OzPlantManager.Instance.Start(_gfx, _numOfPlants, ref _random);
            OzAnimalManager.Instance.Start(ref _gfx, OzPlantManager.Instance.Plants);
            //timer
            _timer = new Timer(1);
            _timer.Elapsed += tickHandle;
            _timer.Start();
        }

        private void tickHandle(object o, EventArgs e)
        {
            _timer.Stop();
            if (_paused) return;
            if (_speedUp != 1) 
            {
                spedTick();
                _timer.Start();
                return;
            }
            _wave.Invoke();
            IncrementtickCount();
            normalTick();
            _timer.Start();
        }

        private void IncrementtickCount()
        {
            _numOfTick++;
            if (_numOfTick == _lenghtOfAnHour)
            {
                _numOfTick = 0;
                _numOfHours++;
            }
            if (_numOfHours == _lenghtOfADay)
            {
                _numOfHours = 0;
                newDay();
                _numOfDays++;
            }
        }
        private void spedTick()
        {
            for (int x = 0; x < _speedUp; x++)
            {
                _wave.Invoke();
                IncrementtickCount();
                normalTick();
            }
        }
        private void normalTick()
        {
            OzPlantManager.Instance.HandleTick();
            OzAnimalManager.Instance.HandleTick();
        }

        private void newDay()
        {
            _refreshDayCount = true;
            OzPlantManager.Instance.HandleDay();
            OzAnimalManager.Instance.HandleDay();
        }

        private void resumeTicking()
        {
            _timer.Start();
        }

        private void endTick()
        {
            _timer.Stop();
            _timer.Dispose();
            _timer = null;
        }
    }
}
