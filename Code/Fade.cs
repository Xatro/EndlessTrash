/*	Endless Trash

	Fade Class: Plays a fade-in/out transition.

	Started: 21 April 2019
*/

using System;
using System.Drawing;

namespace EndlessTrash
{
	public class Fade : IDrawable
	{
		// Fields
		int alpha;
		int direction;

		// Properties
		public byte Layer { get; set; }
		public bool Visible { get; set; }

		// Constructor
		public Fade()
		{
			Layer = 3;
			Visible = true;

			alpha = 255;

			Program.Window.Images.Add(this);
			Program.Clock.Tick += update;
		}

		// Event
		public Action Finished;

		// Methods
		public void Draw(Graphics graphics)
		{
			graphics.FillRectangle(new SolidBrush(Color.FromArgb(alpha, 0, 0, 0)), 0, 0, 960, 540);
		}
		public void FadeOut()
		{
			direction = 1;
		}
		public void FadeIn()
		{
			direction = -1;
		}

		// Event Handler
		private void update(object sender, EventArgs e)
		{
			if (direction != 0)
			{
				if (alpha >= 0 && alpha <= 255)
				{
					alpha += direction * 5;
				}
				if (alpha == 0 || alpha == 255)
				{
					direction = 0;
					if (Finished != null)
						Finished();
				}
			}
		}
	}
}