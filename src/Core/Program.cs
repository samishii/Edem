using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Core
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 4351");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
