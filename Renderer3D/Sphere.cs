using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Renderer3D
{
    internal class Sphere : Object3D
    {

        public Sphere(float r, int n1, int n2)
        {
            //wierzchołki:
            for (int i = 0; i < n1; i++)
                for (int j = 0; j < n2; j++)
                {
                    float fi = -MathF.PI / 2 + MathF.PI * i / (n1-1);
                    float al = 2 * MathF.PI * j / n2;

                    float x = r * MathF.Cos(fi) * MathF.Cos(al);
                    float y = r * MathF.Cos(fi) * MathF.Sin(al);
                    float z = r * MathF.Sin(fi);

                    mesh.Vertices.Add(new Vector3(x,y,z));
                }


            //trójkaty/ściany:
            for (int i = 1; i < n1*n2-n2; i++)
            {
                mesh.Triangles.Add((i, i - 1, i + n2 - 1));
                mesh.Triangles.Add((i, i + n2 - 1, i + n2));
            }

            //mesh.Triangles.Add((0, 1, 2));
            //......

        }

    }
}
