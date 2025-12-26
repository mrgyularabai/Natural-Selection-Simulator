using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Ozeki
{
    public static partial class OzShapeFactory
    {
        public static Line GetLine(OzPoint2D Pos1,OzPoint2D Pos2,Color color, int width)
        {
            var result = new Line()
            {
                X1 = Pos1.X,
                X2 = Pos2.X,
                Y1 = Pos1.Y,
                Y2 = Pos2.X,
                Stroke = new SolidColorBrush(color),
                StrokeThickness = width
            };
            return result;
        }
        public static Line GetLine(OzPoint2D Pos1, OzPoint2D Pos2, Color color)
        {
            var result = new Line()
            {
                X1 = Pos1.X,
                X2 = Pos2.X,
                Y1 = Pos1.Y,
                Y2 = Pos2.X,
                Stroke = new SolidColorBrush(color)
            };
            return result;
        }
    }
}
