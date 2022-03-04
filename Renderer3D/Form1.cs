using System.Numerics;

namespace Renderer3D
{
    public partial class Form1 : Form
    {
        Pyramid pyramid = new Pyramid(100, 100, 200);
        Camera camera = new Camera(new Vector3(0, 300, 100), new Vector3(0, 0, 100), (float)Math.PI / 2, 100, 1000);

        public Form1()
        {
            InitializeComponent();
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            pyramid.Draw(g);
        }
               
    }
}