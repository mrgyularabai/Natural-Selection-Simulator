using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatrualSelectionSim
{
    partial class OzEventSyncroniser
    {
        private static readonly object _sync = new object();
        private static OzEventSyncroniser _instance;
        public static OzEventSyncroniser Instance
        {
            get
            {
                if(_instance != null) return _instance;

                lock (_sync)
                {
                    if (_instance != null) return _instance;
                    _instance = new OzEventSyncroniser();
                    return _instance;
                }
            }
        }

        private OzEventSyncroniser()
        {

        }
    }
}
