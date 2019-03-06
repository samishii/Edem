using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fiddler;

namespace Edem
{
    public partial class Form1 : Form
    {
        static OvAxShockwaveFlash axShockwaveFlash1 = new OvAxShockwaveFlash();
        static Form1 contextMenuStripControl = new Form1();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateAxShockwaveFlashControl();
            FiddlerCore.Listen();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FiddlerApplication.Shutdown();
        }

        public void CreateAxShockwaveFlashControl() 
        {
            Controls.Add(axShockwaveFlash1);
            ((System.ComponentModel.ISupportInitialize)(axShockwaveFlash1)).EndInit();
            //
            axShockwaveFlash1.Enabled = true;
            axShockwaveFlash1.Location = new System.Drawing.Point(0, 0);
            axShockwaveFlash1.Name = "axShockwaveFlash1";
            axShockwaveFlash1.Size = new System.Drawing.Size(900, 600);
            axShockwaveFlash1.TabIndex = 0;
            axShockwaveFlash1.Movie = "http://epicduelstage.artix.com/omegaloader14.swf";
        }
       
        static public void ShowContextMenuStripControl()
        {
            contextMenuStripControl.contextMenuStrip1.Show(Cursor.Position);
        }

        private void applyChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FiddlerCore.Listen();
            axShockwaveFlash1.Movie = "."; // Bypassing the null check with a "."
            axShockwaveFlash1.Movie = "http://epicduelstage.artix.com/omegaloader14.swf";
        }

        private void miscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Misc misc = new Misc();
            misc.Show();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

    public partial class FiddlerCore
    {
        static public void Listen()
        {
            System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 4351"); // Ironically speaking, everything's an interface of IE. sight.
            FiddlerApplication.Startup(0, FiddlerCoreStartupFlags.Default);
            FiddlerApplication.BeforeRequest += delegate (Session session)
            {
                if (session.uriContains("omega277.swf"))
                {
                    session.oFlags["x-replywithfile"] = Path.GetFullPath(session.url.Replace("epicduelstage.artix.com/", "C:\\Users\\Samishii\\Desktop\\"));
                    FiddlerApplication.Shutdown();
                }
            };
        }
    }
}
