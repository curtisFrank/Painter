//*************************************************************************
//       Name: frmPainter.cs
// Programmer: Curtis N Frank
//       Date: 10/04/2015
//    Purpose: use radio buttons to allow user to select and
//             attach paint graphics size/color choices to
//             mouse events to draw on a panel
//*************************************************************************  

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mouse_Events
{
    // creates a form that's a drawing surface
    public partial class frmPainter : Form
    {
        // instantiate sound player object
        ///System.Media.SoundPlayer player = new System.Media.SoundPlayer();        

        // form load event handler
        private void frmPainter_Load(object sender, EventArgs e)
        {
            // start music
            //player.PlayLooping();

            // instantiate new thread
            MyThread t1 = new MyThread();

            // wrap thread and assign method
            Thread splashThread = new Thread(new ThreadStart(t1.SplashStart));

            // start thread
            splashThread.Start();

            // pause 5 seconds
            Thread.Sleep(5000);

            // abort thread
            splashThread.Abort();

            this.Show();
            this.Refresh();
        }

        // determines whether to paint
        bool shouldPaint = false;

        // default constructor
        public frmPainter()
        {
            InitializeComponent();

            // assign sound file to player
            //player.SoundLocation = "Giant_Steps.wav";
        }

        // should paint when mouse button is down
        private void frmPainter_MouseDown_1(object sender, MouseEventArgs e)
        {
            // indicate that user is dragging the mouse
            shouldPaint = true;
        }

        // stop painting when the mouse is released
        private void frmPainter_MouseUp(object sender, MouseEventArgs e)
        {
            // indicate that user released the mouse button
            shouldPaint = false;
        }

        // draw circle whenever mouse is clicked
        private void drawPanel_MouseClick(object sender, MouseEventArgs e)
        {
            paintEllipse(e.X, e.Y);
        }

        // draw circle whenever mouse moves with its button held down
        private void frmPainter_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (shouldPaint)
                paintEllipse(e.X, e.Y);
        }

        // clear button event handler
        private void btnClear_Click(object sender, EventArgs e)
        {
            // refresh the form
            this.Refresh();
        }
        
        private void paintEllipse(int X, int Y)
        {
            
            // draw a circle where the mouse pointer is present
            using (Graphics graphics = drawPanel.CreateGraphics())
            {
                // color radio buttons selection structure...
                if (radBlue.Checked)
                {
                    graphics.FillEllipse(new SolidBrush(Color.Blue),
                        X, Y, Convert.ToInt32(numSize.Value),
                        Convert.ToInt32(numSize.Value));
                }
                else if (radRed.Checked)
                {
                    graphics.FillEllipse(new SolidBrush(Color.Red),
                        X, Y, Convert.ToInt32(numSize.Value),
                        Convert.ToInt32(numSize.Value));
                }
                else if (radGreen.Checked)
                {
                    graphics.FillEllipse(new SolidBrush(Color.Lime),
                        X, Y, Convert.ToInt32(numSize.Value),
                        Convert.ToInt32(numSize.Value));
                }
                else if (radViolet.Checked)
                {
                    graphics.FillEllipse(new SolidBrush(Color.Violet),
                        X, Y, Convert.ToInt32(numSize.Value),
                        Convert.ToInt32(numSize.Value));
                }
                else if (radOrange.Checked)
                {
                    graphics.FillEllipse(new SolidBrush(Color.Orange),
                        X, Y, Convert.ToInt32(numSize.Value),
                        Convert.ToInt32(numSize.Value));
                }
                else if (radYellow.Checked)
                {
                    graphics.FillEllipse(new SolidBrush(Color.Yellow),
                        X, Y, Convert.ToInt32(numSize.Value),
                        Convert.ToInt32(numSize.Value));
                }
                else if (radBrown.Checked)
                {
                    graphics.FillEllipse(new SolidBrush(Color.SaddleBrown),
                        X, Y, Convert.ToInt32(numSize.Value),
                        Convert.ToInt32(numSize.Value));
                }
                else if (radWhite.Checked)
                {
                    graphics.FillEllipse(new SolidBrush(Color.White),
                        X, Y, Convert.ToInt32(numSize.Value),
                        Convert.ToInt32(numSize.Value));
                }
                else if (radBlack.Checked)
                {
                    graphics.FillEllipse(new SolidBrush(Color.Black),
                        X, Y, Convert.ToInt32(numSize.Value),
                        Convert.ToInt32(numSize.Value));
                }
            }
        }
    }

    // splash screen thread
    public class MyThread
    {
        // instantiate form object
        mySplashScreen splash = new mySplashScreen();

        // class method
        public void SplashStart()
        {
            // run splash screen
            Application.Run(splash);
        }
    }
}
