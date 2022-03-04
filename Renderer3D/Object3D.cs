using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Renderer3D
{
    internal abstract class Object3D
    {
        public Matrix4x4 modelMatrix = Matrix4x4.Identity;
        protected Mesh mesh = new Mesh();


        public void Draw(Graphics g)
        {
            g.DrawLine(Pens.Black, 10, 10, g.VisibleClipBounds.Width - 10, g.VisibleClipBounds.Height - 10);
        }

    }
}
