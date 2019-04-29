/*	Endless Trash

	Letter Class: Draws an animated letter to make up the title.

	Started: 21 April 2019
*/

using System;
using System.Drawing;

namespace EndlessTrash
{
	public class Letter : IDrawable
	{
		// Fields
		Bitmap image;
		RectangleF area;
		double x;

		const int m = 3;
		const double i = 0.1f;

		// Properties
		public byte Layer { get; set; }
		public bool Visible { get; set; }

		// Constructor
		public Letter(Bitmap i, RectangleF a, double initial)
		{
			Layer = 2;
			Visible = false;

			image = i;
			area = a;
			x = initial;

			Program.Window.Images.Add(this);
			Program.Clock.Tick += update;
		}

		// Method
		public void Draw(Graphics graphics)
		{
			graphics.DrawImage(image, area);
		}

		// Event Handler
		private void update(object sender, EventArgs e)
		{
			if (Visible)
			{
				x += i;
				area.Y += (int)(m * Math.Sin(x));
			}
		}
	}
}