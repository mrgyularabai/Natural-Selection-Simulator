using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ozeki
{
    partial class OzMovingEntity
    {

        protected override void InitGraphics()
        {
            base.InitGraphics();
            Fill = Colors.Red;
        }
        public override void Render(ref Canvas canvas)
        {
            RenderStatic(ref canvas);
            RenderDebugging(ref canvas);
            RenderDynaminc(ref canvas);
        }

        private void RenderDebugging(ref Canvas canvas)
        {

        }

        protected virtual void RenderDynaminc(ref Canvas canvas)
        {

        }

        private void RenderStatic(ref Canvas canvas)
        {
            RenderStaticShapes(ref canvas);
            RenderStaticLines(ref canvas);
        }

        private void RenderStaticShapes(ref Canvas canvas)
        {
            for(int x = 0; x < FirstStaticLineIndex; x++)
            {
                OzShapeFactory.SetShapeToPosition(RealComponentIndexes[x], ref canvas, Position + (OzVector2D)StaticRelativePostions[x]);
            }
        }

        private void RenderStaticLines(ref Canvas canvas)
        {
            for (int x = FirstStaticLineIndex; x < FirstDynamicIndex*2 - FirstStaticLineIndex; x += 2)
            {
                OzShapeFactory.SetLinePositions(RealComponentIndexes[x], ref canvas, Position + (OzVector2D)StaticRelativePostions[x], Position + (OzVector2D)StaticRelativePostions[x+1]);
            }
        }
    }
}
