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
    public class OzGFXEllipse : OzGFXComponent
    {
        protected OzGFXEllipse()
        {

        }

        public OzGFXEllipse(int radiusW, int radiusH, OzGFXApearence apearence, Ozeki.OzPoint2D pos)
        {
            Position = pos;
            Dimentions = new OzGFXEllipseDimention() { RadiusW = radiusW, RadiusH = radiusH };
            Apearence = apearence;
        }

        new public OzGFXEllipseDimention Dimentions;

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
            Canvas.SetLeft(result, Position.X - Dimentions.RadiusW);
            Canvas.SetBottom(result, Position.Y - Dimentions.RadiusH);
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
                Canvas.SetLeft(Self, Position.X - Dimentions.RadiusW);
                Canvas.SetBottom(Self, Position.Y - Dimentions.RadiusH);
            }
        }
    }
}
