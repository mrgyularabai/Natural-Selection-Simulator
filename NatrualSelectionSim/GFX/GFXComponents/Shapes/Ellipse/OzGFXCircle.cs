using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace NatrualSelectionSim
{
    public class OzGFXCircle : OzGFXEllipse
    {
        public OzGFXCircle(int radius, OzGFXApearence apearence, Ozeki.OzPoint2D pos)
        {
            Position = pos;
            Dimentions = new OzGFXCircleDimention() { Radius = radius };
            Apearence = apearence;
        }
        public new OzGFXCircleDimention Dimentions;
        public override UIElement GetComponent()
        {
            var result = new Ellipse()
            {
                Height = Dimentions.Height,
                Width = Dimentions.Width,
                Fill = Apearence.GetFillBrush(),
                Stroke = Apearence.GetBorderBrush(),
                StrokeThickness = Apearence.BorderThickness
            };
            Canvas.SetLeft(result, Position.X - Dimentions.Radius);
            Canvas.SetBottom(result, Position.Y - Dimentions.Radius);
            return result;
        }
        public override void SetComponent()
        {
            lock (Self)
            {
                ((Ellipse)Self).Height = Dimentions.Height;
                ((Ellipse)Self).Width = Dimentions.Width;
                ((Ellipse)Self).Fill = Apearence.GetFillBrush();
                ((Ellipse)Self).Stroke = Apearence.GetBorderBrush();
                ((Ellipse)Self).StrokeThickness = Apearence.BorderThickness;
                Canvas.SetLeft(Self, Position.X - Dimentions.Radius);
                Canvas.SetBottom(Self, Position.Y - Dimentions.Radius);
            }
        }

    }
}
