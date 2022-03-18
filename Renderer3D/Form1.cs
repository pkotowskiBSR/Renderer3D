using System.Numerics;


namespace Renderer3D
{
    public partial class Form1 : Form
    {
        Pyramid pyramid = new Pyramid(100, 100, 200);
        Sphere sphere = new Sphere(100, 20, 20);

        Camera camera = new Camera(new Vector3(0, 300, 100), new Vector3(0, 0, 100), (float)Math.PI / 2, 100, 1000);


        public Form1()
        {
            InitializeComponent();

            camera.UpdateViewMatrix();
            camera.UpdateProjectionMatrix(pictureBox1);

            pyramid.modelMatrix *= Matrix4x4.CreateTranslation(new Vector3(100, 0, 0));
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            pyramid.Draw(g, camera);
            sphere.Draw(g, camera);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sphere.modelMatrix *= Matrix4x4.CreateRotationZ((float)(10 * Math.PI / 180));

            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

    }
}