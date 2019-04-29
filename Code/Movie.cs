/*	Endless Trash

	Movie Class: Runs a series of animations.

	Started: 17 April 2019
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace EndlessTrash
{
	public static class Movie
	{
		/* Phases
			0 - "Vinesauce Presents" appears
			1 - cut to black
			2 - fade in
			3 - Can w/ eyes crosses
			4 - Rats cross
			5 - Meat crosses
			6 - fade to black
		*/
		static byte phase;
		static int timer;

		// Movie object handles
		static Fade fade;
		static List<Background> backgrounds;
		static List<Letter> trash;
		static Sprite eyes;
		static List<Sprite> rats;
		static Sprite meat;
		static Label presents;
		static Label endless;
		static Label soon;

		// Initializes objects and begins the animation
		public static void Play()
		{
			fade = new Fade();
			fade.Finished += fade_Finished;

			backgrounds = new List<Background>();
			backgrounds.Add(new Background(new Bitmap("Art\\Sky.png"), new Rectangle(0, 0, 960, 540), 0));
			backgrounds.Add(new Background(new Bitmap("Art\\Background1.png"), new Rectangle(0, 0, 960, 540), 1));
			backgrounds.Add(new Background(new Bitmap("Art\\Background2.png"), new Rectangle(0, 290, 960, 200), 2));
			backgrounds.Add(new Background(new Bitmap("Art\\Foreground.png"), new Rectangle(0, 440, 960, 100), 3));

			var letters = new Bitmap("Art\\TRASH.png");
			var format = PixelFormat.Format32bppArgb;

			trash = new List<Letter>();
			trash.Add(new Letter(letters.Clone(new Rectangle(186, 185, 179, 213), format), new RectangleF(620f, 190f, 179f, 213f), 20));
			trash.Add(new Letter(letters.Clone(new Rectangle(4, 194, 148, 199), format), new RectangleF(520f, 190f, 148f, 199f), 15));
			trash.Add(new Letter(letters.Clone(new Rectangle(324, 9, 178, 158), format), new RectangleF(370f, 190f, 178f, 158f), 10));
			trash.Add(new Letter(letters.Clone(new Rectangle(178, 4, 122, 158), format), new RectangleF(270f, 190f, 122f, 158f), 5));
			trash.Add(new Letter(letters.Clone(new Rectangle(3, 2, 138, 160), format), new RectangleF(170f, 190f, 138f, 160f), 0));

			eyes = new Sprite(new Bitmap("Art\\Eyes.png"), new Rectangle(960, 470, 26, 36), 13, 18);

			rats = new List<Sprite>();
			rats.Add(new Sprite(new Bitmap("Art\\Rat.png"), new Rectangle(960, 490, 64, 40), 32, 20, 3, true));
			rats.Add(new Sprite(new Bitmap("Art\\Rat.png"), new Rectangle(1030, 500, 48, 30), 32, 20, 2, true));
			rats.Add(new Sprite(new Bitmap("Art\\Rat.png"), new Rectangle(1080, 500, 48, 30), 32, 20, 2, true));

			meat = new Sprite(new Bitmap("Art\\Meat.png"), new Rectangle(960, 440, 64, 64), 32, 32);

			presents = new Label();
			presents.Text = "-VINESAUCE-\nPresents";
			presents.TextAlign = ContentAlignment.MiddleCenter;
			presents.Location = new Point(0, 0);
			presents.Size = new Size(960, 540);
			presents.BackColor = Color.Transparent;
			presents.Visible = false;
			Program.Window.Controls.Add(presents);

			endless = new Label();
			endless.Text = "Vinny and the\nE N D L E S S";
			endless.TextAlign = ContentAlignment.MiddleCenter;
			endless.Font = new Font(FontFamily.GenericMonospace, 24f);
			endless.Location = new Point(0, 64);
			endless.Size = new Size(960, 64);
			endless.BackColor = Color.Transparent;
			endless.Visible = false;
			Program.Window.Controls.Add(endless);

			soon = new Label();
			soon.Text = "Stream starting soon...";
			soon.TextAlign = ContentAlignment.MiddleCenter;
			soon.Location = new Point(0, 500);
			soon.Width = 960;
			soon.BackColor = Color.Transparent;
			soon.Visible = false;
			Program.Window.Controls.Add(soon);

			phase = 0;
			timer = 0;
			Program.Clock.Tick += update;
		}

		static void fade_Finished()
		{
			if (phase == 2)
			{
				endless.Visible = true;
				foreach (var letter in trash)
				{
					letter.Visible = true;
				}
				phase = 3;
				timer = 0;
			}
		}

		static void update(object sender, EventArgs e)
		{
			if (phase < 6)
				timer++;

			if (phase > 2 && phase < 6)
			{
				if (timer % 25 == 0)
				{
					soon.Visible = !soon.Visible;
				}
			}

			if (rats.Any(r => r.Playing && r.X > -100))
			{
				foreach (var rat in rats)
				{
					rat.Translate(-8);
				}
			}

			if (phase == 0)
			{
				if (timer >= 100)
				{
					presents.Visible = true;
					phase = 1;
					timer = 0;
				}
			}
			else if (phase == 1)
			{
				if (timer >= 50)
				{
					presents.Visible = false;
					phase = 2;
					timer = 0;
				}
			}
			else if (phase == 2)
			{
				if (timer == 25)
				{
					fade.FadeIn();
				}
			}
			else if (phase == 3)
			{
				if (timer >= 25)
					eyes.Translate(-3);

				if (eyes.X == 288)
				{
					eyes.Playing = true;
				}
				else if (eyes.X < -30)
				{
					phase = 4;
					timer = 0;
				}
			}
			else if (phase == 4)
			{
				foreach (var rat in rats)
				{
					rat.Playing = true;
					phase = 5;
					timer = 0;
				}
			}
			else if (phase == 5)
			{
				if (timer >= 200)
					meat.Translate(-3);

				if (meat.X == 690)
				{
					meat.Playing = true;
				}
				else if (meat.X < -100)
				{
					endless.Visible = false;
					fade.FadeOut();
					phase = 6;
					timer = 0;
				}
			}
		}
	}
}