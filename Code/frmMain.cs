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
		// Constructor
		public frmMain() : base()
		{
			ClientSize = new Size(960, 540);
			Text = "Endless Trash";
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		}
	}
}