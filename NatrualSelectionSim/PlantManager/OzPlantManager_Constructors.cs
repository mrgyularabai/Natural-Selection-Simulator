using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatrualSelectionSim
{
    partial class OzPlantManager
    {
        private static readonly object _sync = new object();
        private static OzPlantManager _instance;
        public static OzPlantManager Instance
        {
            get
            {
                if(_instance != null) return _instance;

                lock (_sync)
                {
                    if (_instance != null) return _instance;
                    _instance = new OzPlantManager();
                    return _instance;
                }
            }
        }

        private OzPlantManager()
        {

        }
    }
}
