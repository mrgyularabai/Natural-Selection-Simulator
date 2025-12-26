using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Controls;

namespace Ozeki
{
    public static class OzEventSyncronizer
    {
        private static System.Timers.Timer Ticker;
        private static Thread _physicsThread;
        private static Thread _timerThread;
        public static OzMovingEntity[] _entities;
        public static void Start(OzMovingEntity[] entities)
        {
            Ticker = new System.Timers.Timer(0.01);
            _physicsThread = new Thread(registerAndStartTick);
            _entities = entities;
            _physicsThread.Start();
        }

        private static void registerAndStartTick()
        {
            lock (_entities)
            {
                for (int x = 0; x < _entities.Length; x++)
                {
                    Ticker.Elapsed += _entities[x].ActualTickRequestHandler;
                }
            }
            _timerThread = new Thread(startTick);
            _timerThread.Start();
        }

        private static void startTick()
        {
            Ticker.Start();
        }

        public static void Render(ref Canvas canvas)
        {
            lock (OzEventSyncronizer._entities)
            {
                foreach (OzEntity e in _entities)
                {
                    e.Render(ref canvas);
                }
            }
        }

        public static void SetGroupDestination(OzPoint2D p)
        {
            lock (OzEventSyncronizer._entities)
            {
                foreach (OzMovingEntity e in _entities)
                {
                    e.SetDestination(p);
                }
            }
        }
    }
}
