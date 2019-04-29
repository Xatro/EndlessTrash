/*	Endless Trash

	IDrawable Interface: Defines members of drawable elements.

	Started: 17 April 2019
*/

using System.Drawing;

namespace EndlessTrash
{
	public interface IDrawable
	{
		byte Layer { get; set; }
		bool Visible { get; set; }
		void Draw(Graphics graphics);
	}
}