using Ozeki;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace NatrualSelectionSim
{
    public abstract class OzGFXComponent
    { 

        public UIElement Self;
        public OzGFXDimentions Dimentions;
        public OzGFXApearence Apearence;
        public OzPoint2D Position;
        public virtual UIElement GetComponent()
        {
            return Self;
        }
        public virtual void SetComponent()
        {

        }
        public int getIndex(ref Canvas canvas)
        {
            return canvas.Children.IndexOf(Self);
        }
    }
}
