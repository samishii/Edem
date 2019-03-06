using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edem
{
    public partial class Misc : Form
    {
        public Misc()
        {
            InitializeComponent();
        }
        
        public void CharacterCreatorModule(int flags, int value)
        {
            BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Samishii\\Desktop\\omega277.swf")); // temp, switch to %appdata% 
            switch (flags)
            {
                case 1:
                    bw.Seek(0xA0C061, SeekOrigin.Begin);
                    bw.Write((byte)value);
                    bw.Dispose();
                    break;
                case 2:
                    bw.Seek(0xA0C067, SeekOrigin.Begin);
                    bw.Write((byte)value);
                    bw.Dispose();
                    break;
                case 3:
                    bw.Seek(0xA0C06D, SeekOrigin.Begin);
                    bw.Write((byte)value);
                    bw.Dispose();
                    break;
                case 4:
                    bw.Seek(0xA0C073, SeekOrigin.Begin);
                    bw.Write((byte)value);
                    bw.Dispose();
                    break;
                case 5:
                    bw.Seek(0xA0C079, SeekOrigin.Begin);
                    bw.Write((byte)value);
                    bw.Dispose();
                    break;
                case 6:
                    bw.Seek(0xA0C07F, SeekOrigin.Begin);
                    bw.Write((byte)value);
                    bw.Dispose();
                    break;
                default: break;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CharacterCreatorModule(1, Convert.ToInt32(Math.Round(numericUpDown1.Value, 0)));
        }
    }
}
