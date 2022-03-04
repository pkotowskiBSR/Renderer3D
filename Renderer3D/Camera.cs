using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Renderer3D
{
    internal class Camera
    {
        public Vector3 Position;
        public Vector3 Target;

        public Matrix4x4 viewMatrix;

        public float FOV;  //w radianach
        public float Near;
        public float Far;

        public Matrix4x4 projectionMatrix;

        public Camera(Vector3 position, Vector3 target, float fOV, float near, float far)
        {
            Position = position;
            Target = target;
            FOV = fOV;
            Near = near;
            Far = far;
        }

        public void UpdateViewMatrix()
        {
            viewMatrix = Matrix4x4.CreateLookAt(Position, Target, new Vector3(0,0,1));
        }

        public void UpdateProjectionMatrix(PictureBox pb)
        {
            projectionMatrix = Matrix4x4.CreatePerspectiveFieldOfView(FOV, 1f*pb.Width / pb.Height, Near, Far);
        }
    }
}
