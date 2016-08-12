using System;
using Gtk;

namespace DocViewer
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			BenDocViewer win = new BenDocViewer ();
			win.Show ();
			Application.Run ();
		}
	}
}
