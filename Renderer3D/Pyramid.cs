using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Renderer3D
{
    internal class Pyramid : Object3D
    {
       
        public Pyramid(float a, float b, float h)
        {
            mesh.Vertices.Add(new Vector3(-a / 2, b/2, 0));
            mesh.Vertices.Add(new Vector3(a / 2, b / 2, 0));
            mesh.Vertices.Add(new Vector3(a / 2, b / 2, 0));


        }

    }
}
