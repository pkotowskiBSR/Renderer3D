using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Renderer3D
{
    internal class Mesh
    {
        public List<Vector3> Vertices = new List<Vector3> ();
        public List<(int,int,int)> Triangles = new List<(int,int,int)> ();

    }
}
