using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Ozeki
{
    public static partial class OzShapeFactory
    {
        public static void SetShapeToPosition(int index, ref Canvas canvas, OzPoint2D newCenterPosition)
        {
            Shape e = (Shape)canvas.Children[index];
            Canvas.SetLeft(e, newCenterPosition.X - (e.ActualWidth / 2));
            Canvas.SetTop(e, newCenterPosition.Y - (e.ActualHeight / 2));
            canvas.Children[index] = e;
        }

        public static void SetLinePositions(int index, ref Canvas canvas, OzPoint2D Pos1, OzPoint2D Pos2)
        {
            var line = (Line)canvas.Children[index];
            line.X1 = Pos1.X;
            line.X2 = Pos2.X;
            line.Y1 = Pos1.Y;
            line.Y2 = Pos2.Y;
            canvas.Children[index] = line;
        }
    }
}
