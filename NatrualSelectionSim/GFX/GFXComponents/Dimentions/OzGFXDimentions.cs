using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatrualSelectionSim
{
    public class OzGFXDimentions
    {
        public OzGFXDimentions()
        {
            _height = 1;
            _width = 1;
        }
        public OzGFXDimentions(int height, int width)
        {
            _height = height;
            _width = width;
        }
        private int _height;
        private int _width;
        public int Height
        {
            set { return; }
            get
            {
                return GetHeight();
            }
        }
        public int Width
        { 
            get 
            {
                return GetWidth();
            }
        }
        protected virtual int GetHeight()
        {
            return _height;
        }
        protected virtual int GetWidth()
        {
            return _width;
        }
    }
}
