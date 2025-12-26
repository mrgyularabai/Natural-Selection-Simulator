using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NatrualSelectionSim
{
    partial class OzWorld
    {
        private static readonly object _sync = new object();
        private static OzWorld _instance;
        public static OzWorld Instance
        {
            get
            {
                if (_instance != null) return _instance;

                lock (_sync)
                {
                    if (_instance != null) return _instance;
                    _instance = new OzWorld();
                    return _instance;
                }
            }
        }

        private OzWorld()
        {

        }
    }
}
