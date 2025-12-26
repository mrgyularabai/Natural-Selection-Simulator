using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatrualSelectionSim
{
    partial class OzAnimalManager
    {
        private static readonly object _sync = new object();
        private static OzAnimalManager _instance;
        public static OzAnimalManager Instance
        {
            get
            {
                if (_instance != null) return _instance;

                lock (_sync)
                {
                    if (_instance != null) return _instance;
                    _instance = new OzAnimalManager();
                    return _instance;
                }
            }
        }

        private OzAnimalManager()
        {

        }
    }
}
