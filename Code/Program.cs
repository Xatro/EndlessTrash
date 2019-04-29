/*	Endless Trash

	Program Class: The main entry point of the program.  Contains handles to vital objects.

	This program will open a window which play a looping animation.
	The animation is intended to be captured an converted to an MP4 file.

	Started: 8 April 2019

*/

using System.Windows.Forms;

namespace EndlessTrash
{
	public class Program
	{
		// Vital objects
		public static frmMain Window;
		public static Timer Clock;

		// Entry point
		public static void Main()
		{
			Clock = new Timer();
			Clock.Interval = 40;
			Clock.Start();

			Application.Run(new frmMain());
		}
	}
}