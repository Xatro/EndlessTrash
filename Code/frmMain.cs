/*	Endless Trash

	frmMain Class: The main form which will play the animation.

	Started: 8 April 2019
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace EndlessTrash
{
	public class frmMain : Form
	{
		// Property
		public List<IDrawable> Images { get; set; }

		// Constructor
		public frmMain() : base()
		{
			ClientSize = new Size(960, 540);
			BackColor = Color.Black;
			ForeColor = Color.White;
			Font = new Font(FontFamily.GenericMonospace, 16f);
			Text = "Endless Trash";
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			Images = new List<IDrawable>();
			Paint += frmMain_Paint;
			Program.Clock.Tick += update;

			Program.Window = this;

			Movie.Play();
		}

		// Event Hanlders
		private void frmMain_Paint(object sender, PaintEventArgs e)
		{
			var imagesToDraw = from image in Images
				where image.Visible
				orderby image.Layer
				select image;

			e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;

			foreach (var image in imagesToDraw)
			{
				image.Draw(e.Graphics);
			}
		}
		private void update(object sender, EventArgs e)
		{
			Invalidate();
		}
	}
}