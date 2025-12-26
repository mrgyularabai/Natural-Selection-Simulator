using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Ozeki
{
    public static partial class OzShapeFactory
    {
        public static Ellipse GetEllipse(OzPoint2D center, int widthRadius, int heightRadius, Color fill, Color borderFill, int borderWidth)
        {
            var result = new Ellipse()
            {
                Height = heightRadius * 2,
                Width = widthRadius * 2,
                Fill = new SolidColorBrush(fill),
                Stroke = new SolidColorBrush(borderFill),
                StrokeThickness = borderWidth
            };
            Canvas.SetLeft(result,center.X-widthRadius);
            Canvas.SetTop(result, center.Y-heightRadius);
            return result;
        }

        public static Ellipse GetEllipse(OzPoint2D center, int widthRadius, int heightRadius, Color fill)
        {
            var result = new Ellipse()
            {
                Height = heightRadius * 2,
                Width = widthRadius * 2,
                Fill = new SolidColorBrush(fill)
            };
            Canvas.SetLeft(result, center.X);
            Canvas.SetBottom(result, center.Y);
            return result;
        }

        public static Ellipse GetCircle(OzPoint2D center, int radius, Color fill, Color borderFill, int borderWidth)
        {
            return GetEllipse(center,radius,radius,fill,borderFill,borderWidth);
        }

        public static Ellipse GetCircle(OzPoint2D center, int radius, Color fill)
        {
            return GetEllipse(center, radius, radius, fill);
        }
    }
}
