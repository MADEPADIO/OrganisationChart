using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemCoordinatesandWorldCoordinates
{
    public partial class CoordinateSystems : Form
    {
        public CoordinateSystems()
        {
            InitializeComponent();
        }

        private PointF currentPosition; 
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            currentPosition = PointToCartesian(e.Location);
            label1.Text = string.Format("{0}, {1}", e.Location.X, e.Location.Y);
        }
        
        // GET SCREEN DPI
        private float DPI
        {
            get
            {
                using (var g = CreateGraphics())
                    return g.DpiX;
            }
        }

        // CONVERT SYSTEM COORDINATES TO WORLD COORDINATES
        private PointF PointToCartesian(Point point)
        {
            return new PointF(point.X, drawing.Height - point.Y);
        }
    }
}
