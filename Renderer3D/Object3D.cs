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

        public float angle;
        public Vector3 pos;

        public void UpdateModelMatrix()
        {
            modelMatrix = Matrix4x4.CreateRotationZ(angle)*Matrix4x4.CreateTranslation(pos);
        }


        public void Draw(Graphics g, Camera camera)
        {
            //g.DrawLine(Pens.Black, 10, 10, g.VisibleClipBounds.Width - 10, g.VisibleClipBounds.Height - 10);
        
        
            List<Vector3> vertices = new List<Vector3>();

            foreach (var vertex in mesh.Vertices)
            {
                Vector4 v =  Vector4.Transform(new Vector4(vertex,1), modelMatrix * camera.viewMatrix * camera.projectionMatrix);
                vertices.Add(new Vector3(v.X/v.W, v.Y/v.W, v.Z/v.W));
            }

            //rysowanie punktów
            foreach (var vertex in vertices)
            {
                int x = (int)((vertex.X + 1)* g.VisibleClipBounds.Width/2);
                int y = (int)((-vertex.Y + 1) * g.VisibleClipBounds.Height/2);
                g.FillEllipse(Brushes.Red, x-2, y-2, 4, 4);
            }

            //rysowanie krawędzi
            foreach (var triangle in mesh.Triangles)
            {

                int xa = (int)((vertices[triangle.Item1].X + 1) * g.VisibleClipBounds.Width / 2);
                int ya = (int)((-vertices[triangle.Item1].Y + 1) * g.VisibleClipBounds.Height / 2);

                int xb = (int)((vertices[triangle.Item2].X + 1) * g.VisibleClipBounds.Width / 2);
                int yb = (int)((-vertices[triangle.Item2].Y + 1) * g.VisibleClipBounds.Height / 2);

                int xc = (int)((vertices[triangle.Item3].X + 1) * g.VisibleClipBounds.Width / 2);
                int yc = (int)((-vertices[triangle.Item3].Y + 1) * g.VisibleClipBounds.Height / 2);

                g.DrawLine(Pens.Black, xa, ya, xb, yb);
                g.DrawLine(Pens.Black, xc, yc, xb, yb);
                g.DrawLine(Pens.Black, xc, yc, xa, ya);
                
            }

        }

    }
}
