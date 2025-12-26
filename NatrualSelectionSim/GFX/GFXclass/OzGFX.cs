using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace NatrualSelectionSim
{
    public class OzGFX
    {
        public Canvas canvas;
        public Ozeki.OzPoint2D MousePos;
        public List<OzGFXComponent> Components;

        public OzGFX(List<OzGFXComponent> components)
        {
            Components = components;
        }

        public void PingOn(Canvas _canvas)
        {
            canvas = _canvas;
            lock (canvas)
            {
                for (int x = 0; x < Components.Count; x++)
                {
                    Components[x].Self = Components[x].GetComponent();
                    canvas.Children.Add(Components[x].Self);
                }
            }
        }

        public void unPing()
        {
            for (int x = 0; x < Components.Count; x++)
            {
                canvas.Children.Remove(Components[x].Self);
            }
        }

        public void Update()
        {
            MousePos = Mouse.GetPosition(canvas);
            MousePos.Y = canvas.ActualHeight - MousePos.Y;
            for (int x = 0; x < Components.Count; x++)
            {
                Components[x].SetComponent(); 
            }
        }
    }
}
