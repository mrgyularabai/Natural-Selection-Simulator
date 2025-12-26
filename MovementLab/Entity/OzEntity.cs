using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ozeki
{
    public abstract partial class OzEntity
    {
        public OzPoint2D Position { get; protected set; }
        protected int ID { get; private set; }

        private int _tickspeedup;

        public void ActualTickRequestHandler(object o, EventArgs e)
        {
            for(int x = 0; x < _tickspeedup; x++)
            {
                TickRequestHandler();
            }
        }
        protected virtual void TickRequestHandler()
        {
            
        }

        protected virtual void AfterRender()
        {

        }

        private void SetTickSpeed(int speedUp)
        {
            _tickspeedup = speedUp;
        }
    }
}
