using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpLocker
{
    class CustomPictureBox : PictureBox
    {
        public CustomPictureBox()
        {
        }

        public CustomPictureBox(Image image)
        {
            this.Image = image;
        }
       
        public InterpolationMode InterpolationMode { get; set; }
        public SmoothingMode SmoothingMode { get; set; }

        protected override void OnPaint(PaintEventArgs paintEventArgs)
        {
            paintEventArgs.Graphics.InterpolationMode = InterpolationMode;
            paintEventArgs.Graphics.SmoothingMode = SmoothingMode;
            base.OnPaint(paintEventArgs);
        }
    }
}
