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
            
            BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf")); // temp, switch to %appdata% 
            switch (flags)
            {
                case 1:
                    bw.Seek(0xA0C21D, SeekOrigin.Begin);
                    bw.Write((byte)value);
                    bw.Dispose();
                    break;
                case 2:
                    bw.Seek(0xA0C224, SeekOrigin.Begin);
                    bw.Write((byte)value);
                    bw.Dispose();
                    break;
                case 3:
                    bw.Seek(0xA0C22B, SeekOrigin.Begin);
                    bw.Write((byte)value);
                    bw.Dispose();
                    break;
                case 4:
                    bw.Seek(0xA0C232, SeekOrigin.Begin);
                    bw.Write((byte)value);
                    bw.Dispose();
                    break;
                case 5:
                    bw.Seek(0xA0C239, SeekOrigin.Begin);
                    bw.Write((byte)value);
                    bw.Dispose();
                    break;
                case 6:
                    bw.Seek(0xA0C240, SeekOrigin.Begin);
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

        private void Misc_Load(object sender, EventArgs e)
        {
            using (FileStream fileStream = new FileStream("C:\\Users\\Public\\omega277.swf", FileMode.Open))
            {
                fileStream.Seek(0xA0C21D, SeekOrigin.Begin);
                numericUpDown1.Value = fileStream.ReadByte();

                fileStream.Seek(0xA0C224, SeekOrigin.Begin);
                numericUpDown1.Value = fileStream.ReadByte();

                fileStream.Seek(0xA0C22B, SeekOrigin.Begin);
                numericUpDown1.Value = fileStream.ReadByte();

                fileStream.Seek(0xA0C232, SeekOrigin.Begin);
                numericUpDown1.Value = fileStream.ReadByte();

                fileStream.Seek(0xA0C239, SeekOrigin.Begin);
                numericUpDown1.Value = fileStream.ReadByte();

                fileStream.Seek(0xA0C240, SeekOrigin.Begin);
                numericUpDown1.Value = fileStream.ReadByte();

                fileStream.Close();
            }
        }
    }
}
