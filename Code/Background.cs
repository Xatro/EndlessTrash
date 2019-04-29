/*	Endless Trash

	Background Class: Draws a scrolling background.

	Started: 17 April 2019
*/

using System;
using System.Drawing;

namespace EndlessTrash
{
	public class Background : IDrawable
	{
		// Fields
		Bitmap background;
		Rectangle area;
		int speed;

		// Properties
		public byte Layer { get; set; }
		public bool Visible { get; set; }

		// Constructor
		public Background(Bitmap b, Rectangle a, int s)
		{
			Layer = 0;
			Visible = true;

			background = b;
			area = a;
			speed = s;

			Program.Window.Images.Add(this);
			Program.Clock.Tick += update;
		}

		// Method
		public void Draw(Graphics graphics)
		{
			graphics.DrawImage(background, area);
			graphics.DrawImage(background, new Rectangle(area.X + area.Width - 1, area.Y,
				area.Width, area.Height));
		}

		// Event Handler
		private void update(object sender, EventArgs e)
		{
			if (Visible)
			{
				area.X -= speed;
				if (area.X <= -area.Width)
				{
					area.X = 0;
				}
			}
		}
	}
}