using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3D_Render_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = (1366);
            this.Height = (768);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            //  #######   #       ##   ### ####          #####                           #####
            //  #     ##  #       ##  #   ##  ##         #             #####  ##         #  
            //  #     ##  #   ##  ##  #   ##  ##         ###    #####  #      ##  #####  ###
            //  #     ##  #   ##  ##  #       ##         #      #  ##  #  ##  ##  #  ##  #
            //  #######    ### ####   #       ##         #####  #  ##  #####  ##  #  ##  #####


            //USAGES:        ~ DrawLine3D(YourPen, x1, y1, z1, x2, y2, z2)     ~
            //               ~ DrawQuadrilateral23(YourPen, x1, y1, x2, y2, z) ~
            //               ~ DrawTriangle3D(YourPen, x1, y1, x2, y2, z)      ~
            //               ~ DrawCube3D(YourPen, x1, y1, z1, x2, y2, z2)     ~
            //   ~ DrawCube3D uses some pretty confusing math, just experiment with the engine! ~

            int fov = 25;
            int camX = 700;
            int camY = 400;
            int camZ = 0;
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2.5f);

            void DrawLine3D(Pen Line, int x1, int y1, int z1, int x2, int y2, int z2)
            {
                g.DrawLine(Line, (fov * ((x1 + camX) / (z1 + camZ))), (fov * ((y1 + camY) / (z1 + camZ))), (fov * ((x2 + camX) / (z2 + camZ))), (fov * ((y2 + camY) / (z2 + camZ))));
            }

            void DrawQuadrilateral3D(Pen Line, int x1, int y1, int x2, int y2, int z)
            {
                DrawLine3D(Line, x1, y1, z, x2, y1, z);
                DrawLine3D(Line, x2, y1, z, x2, y2, z);
                DrawLine3D(Line, x2, y2, z, x1, y2, z);
                DrawLine3D(Line, x1, y2, z, x1, y1, z);
            }

            void DrawTriangle3D(Pen Line, int x1, int y1, int x2, int y2, int z)
            {
                DrawLine3D(Line, x1, y1, z, x2, y2, z);
                DrawLine3D(Line, x2, y2, z, x2, y1, z);
                DrawLine3D(Line, x2, y1, z, x1, y1, z);
            }

            void DrawCube3D(Pen Line, int x1, int y1, int z1, int x2, int y2, int z2)
            {
                DrawQuadrilateral3D(pen, x1, y1, x2, y2, z1);
                DrawQuadrilateral3D(pen, x1, y1, x2, y2, z2);
                DrawLine3D(pen, x1, y1, z1, x1, y1, z2);
                DrawLine3D(pen, x2, y1, z1, x2, y1, z2);
                DrawLine3D(pen, x2, y2, z1, x2, y2, z2);
                DrawLine3D(pen, x1, y2, z1, x1, y2, z2);
            }
        }
    }
}
