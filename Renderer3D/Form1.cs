using System.Net;
using System.Net.Sockets;

using System.Numerics;


namespace Renderer3D
{
    public partial class Form1 : Form
    {
        TcpListener server;
        TcpClient clientServer;

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

        private void button2_Click(object sender, EventArgs e)
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 6969);
            server.Start();

            Cursor.Current = Cursors.WaitCursor;
            //oczekiwanie na połaczenie
            clientServer = server.AcceptTcpClient();

            Cursor.Current = Cursors.Default;
            MessageBox.Show($"Połączono z klientem ");
            button2.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (clientServer == null) return;

            NetworkStream ns = clientServer.GetStream();
            if (ns.DataAvailable)
            {
                byte[] buffer = new byte[1024];
                int count = ns.Read(buffer, 0, 1024);

                if (count != 0)
                {
                    pyramid.modelMatrix *= Matrix4x4.CreateTranslation(10, 0, 0);
                    pictureBox1.Invalidate();
                }
            }
        }
    }
}