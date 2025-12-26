using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Ozeki
{
    partial class OzEntity
    {
        protected int[] RealComponentIndexes { get; private set; }
        protected int FirstStaticLineIndex { get; private set; }
        protected int FirstDynamicIndex { get; private set; }
        protected OzVector2D[] StaticRelativePostions { get; private set; }

        private Shape[] AddArrays(Shape[] array1, Shape[] array2)
        {
            var result = new Shape[array1.Length + array2.Length];
            for (int x = 0; x < array1.Length; x++)
            {
                result[x] = array1[x];
            }
            for (int x = array1.Length; x < array1.Length + array2.Length; x++)
            {
                result[x] = array2[x - array1.Length];
            }
            return result;
        }

        private Shape[] generateStaticComponents()
        {
            var shapes = generateStaticShapes();
            var lines = generateStaticLines();
            StaticRelativePostions = new OzVector2D[lines.Length + shapes.Length];
            FirstStaticLineIndex = shapes.Length;
            for (int x = 0; x < shapes.Length; x++)
            {
                getShapePosition(x, ref shapes);
            }
            for (int x = shapes.Length; x < shapes.Length + lines.Length; x += 2)
            {
                getLinePosition(x, ref shapes, ref lines);
            }
            var result = AddArrays(shapes, lines);
            return result;
        }

        private void getShapePosition(int x, ref Shape[] shapes)
        {
            var px = Canvas.GetLeft(shapes[x]);
            var py = Canvas.GetTop(shapes[x]);
            var dimentionalCompensation = new OzVector2D(shapes[x].Width/2, shapes[x].Height / 2);
            StaticRelativePostions[x] = (new OzVector2D(px, py) + dimentionalCompensation)-Position;
        }

        private void getLinePosition(int x, ref Shape[] shapes, ref Line[] lines)
        {
            var px = lines[x - shapes.Length].X1;
            var py = lines[x - shapes.Length].Y1;
            StaticRelativePostions[x] = new OzPoint2D(px, py) - Position;

            px = lines[x - shapes.Length].X2;
            py = lines[x - shapes.Length].Y2;
            StaticRelativePostions[x + 1] = new OzPoint2D(px, py) - Position;
        }
        private void drawComponents(ref Canvas canvas)
        {
            InitGraphics();
            var components = generateComponents();
            RealComponentIndexes = new int[components.Length];
            for (int x = 0; x < components.Length; x++)
            {
                RealComponentIndexes[x] = canvas.Children.Add(components[x]);
            }
        }

        private Shape[] generateComponents()
        {
            var statics = generateStaticComponents();
            FirstDynamicIndex = statics.Length;
            var dynamics = generateDynamicComponents();
            var result = AddArrays( statics, dynamics);
            return result;
        }

        protected virtual Shape[] generateStaticShapes()
        {
            var result = new Shape[1];
            result[0] = OzShapeFactory.GetCircle(Position, Raduis, Fill, BorederFill, BorderThickness);
            return result;
        }
        protected virtual Line[] generateStaticLines()
        {
            var result = new Line[0];
            return result;
        }

        protected virtual Shape[] generateDynamicComponents()
        {
            var result = new Shape[0];
            return result;
        }
    }
}
