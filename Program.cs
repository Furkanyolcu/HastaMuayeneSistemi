using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace HastaMuayeneSistemi
{
	static class Program
	{

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
