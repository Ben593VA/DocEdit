using System;
using Gtk;

public partial class BenDocViewer: Gtk.Window
{
	public BenDocViewer () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnOpen (object sender, EventArgs e)
	{
		int width, height;
		this.GetDefaultSize( out width, out height );
		this.Resize( width, height );

		DocTextView.Buffer.Text = "";

		FileChooserDialog chooser = new FileChooserDialog(
			"Choisissez un fichier texte...",
			this,
			FileChooserAction.Open,
			"Cancel", ResponseType.Cancel,
			"Open", ResponseType.Accept );

		if( chooser.Run() == ( int )ResponseType.Accept )
		{
			System.IO.StreamReader file =
				System.IO.File.OpenText( chooser.Filename );

			DocTextView.Buffer.Text = file.ReadToEnd();

			this.Title = "Doc Viewer 1.0 -- " + chooser.Filename.ToString();

			this.Resize( 1080, 800 );

			file.Close();
		}
		chooser.Destroy();
	}

	protected void OnClose (object sender, EventArgs e)
	{
		int width, height;
		this.GetDefaultSize( out width, out height );
		this.Resize( width, height );

		DocTextView.Buffer.Text = "";

		this.Title = "Doc Viewer 1.0";
	}

	protected void OnExit (object sender, EventArgs e)
	{
		Application.Quit ();
	}

	protected void OnAbout (object sender, EventArgs e)
	{
		AboutDialog about = new AboutDialog();

		about.ProgramName = "Doc Viewer";
		about.Version = "1.0";

		about.Run();

		about.Destroy();
	}

}
