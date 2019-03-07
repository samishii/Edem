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

namespace Edem
{
    public partial class Character : Form
    {
        public Character()
        {
            InitializeComponent();
        }

        private void Character_Load(object sender, EventArgs e)
        {
            int isEnabled1 = 0;
            int isEnabled2 = 0;
            int isEnabled3 = 0;
            int isEnabled4 = 0;
            int isEnabled5 = 0;
            int isEnabled6 = 0;
            int isEnabled8 = 0;
            using (FileStream fileStream = new FileStream("C:\\Users\\Public\\omega277.swf", FileMode.Open))
            {
                fileStream.Seek(0x939CC2, SeekOrigin.Begin); // armor
                isEnabled1 = fileStream.ReadByte();

                fileStream.Seek(0x939ED0, SeekOrigin.Begin);
                isEnabled2 = fileStream.ReadByte(); // primary

                fileStream.Seek(0x939F37, SeekOrigin.Begin); // bot
                isEnabled3 = fileStream.ReadByte();

                fileStream.Seek(0x939F9E, SeekOrigin.Begin); // sidearm
                isEnabled4 = fileStream.ReadByte();

                fileStream.Seek(0x93A005, SeekOrigin.Begin); // aux
                isEnabled5 = fileStream.ReadByte();

                fileStream.Seek(0x93A06C, SeekOrigin.Begin); // vehicle
                isEnabled6 = fileStream.ReadByte();
                
                fileStream.Seek(0x93A1AA, SeekOrigin.Begin); // Hair
                isEnabled8 = fileStream.ReadByte();

                fileStream.Close();

                if (isEnabled2 == 0) checkBox1.Checked = true; else checkBox1.Checked = false;
                if (isEnabled4 == 0) checkBox2.Checked = true; else checkBox2.Checked = false;
                if (isEnabled5 == 0) checkBox3.Checked = true; else checkBox3.Checked = false;
                if (isEnabled3 == 0) checkBox4.Checked = true; else checkBox4.Checked = false;
                if (isEnabled3 == 0) checkBox5.Checked = true; else checkBox5.Checked = false;
                if (isEnabled1 == 0) checkBox6.Checked = true; else checkBox6.Checked = false;
                if (isEnabled8 == 0) checkBox7.Checked = true; else checkBox7.Checked = false;  
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf")); // temp, switch to %appdata% 
            
            if (checkBox1.Checked)
            {
                bw.Seek(0x939CC2, SeekOrigin.Begin);
                bw.Write((byte)0);

                bw.Seek(0x939ED0, SeekOrigin.Begin);
                bw.Write((byte)0);

                bw.Seek(0x939F37, SeekOrigin.Begin);
                bw.Write((byte)0);

                bw.Seek(0x939F9E, SeekOrigin.Begin);
                bw.Write((byte)0);

                bw.Seek(0x93A005, SeekOrigin.Begin);
                bw.Write((byte)0);

                bw.Seek(0x93A06C, SeekOrigin.Begin);
                bw.Write((byte)0);
            }
                
            else
            {
                bw.Seek(0x939CC2, SeekOrigin.Begin);
                bw.Write((byte)1);

                bw.Seek(0x939ED0, SeekOrigin.Begin);
                bw.Write((byte)1);

                bw.Seek(0x939F37, SeekOrigin.Begin);
                bw.Write((byte)1);

                bw.Seek(0x939F9E, SeekOrigin.Begin);
                bw.Write((byte)1);

                bw.Seek(0x93A005, SeekOrigin.Begin);
                bw.Write((byte)1);

                bw.Seek(0x93A06C, SeekOrigin.Begin);
                bw.Write((byte)1);
            }
            bw.Dispose();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

            int minValue = 128;
            int maxValue = Convert.ToInt32(Math.Round(numericUpDown3.Value, 0));
            int finalValue = 0;
            int opcode = 0;

            if (maxValue >= 255)
            {
                opcode = 2;
                while (minValue <= maxValue - 128 * 2)
                {
                    opcode++;
                    minValue += 128;
                }
                finalValue = maxValue - minValue;

                BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf")); // temp, switch to %appdata% 

                bw.Seek(0x939F0C, SeekOrigin.Begin);
                bw.Write((byte)finalValue);

                bw.Seek(0x939F0D, SeekOrigin.Begin);
                bw.Write((byte)opcode);

                bw.Dispose();
            }
            else if (maxValue <= 255)
            {
                opcode = 1;

                BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf")); // temp, switch to %appdata% 


                bw.Seek(0x939F0C, SeekOrigin.Begin);
                bw.Write((byte)maxValue);

                bw.Seek(0x939F0D, SeekOrigin.Begin);
                bw.Write((byte)opcode);

                bw.Dispose();
            }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            int minValue = 128;
            int maxValue = Convert.ToInt32(Math.Round(numericUpDown4.Value, 0));
            int finalValue = 0;
            int opcode = 0;

            if (maxValue >= 255)
            {
                opcode = 2;
                while (minValue <= maxValue - 128 * 2)
                {
                    opcode++;
                    minValue += 128;
                }
                finalValue = maxValue - minValue;

                BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf")); // temp, switch to %appdata% 

                bw.Seek(0x939FDA, SeekOrigin.Begin);
                bw.Write((byte)finalValue);

                bw.Seek(0x939FDB, SeekOrigin.Begin);
                bw.Write((byte)opcode);

                bw.Dispose();
            }
            else if (maxValue <= 255)
            {
                opcode = 1;

                BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf")); // temp, switch to %appdata% 


                bw.Seek(0x939FDA, SeekOrigin.Begin);
                bw.Write((byte)maxValue);

                bw.Seek(0x939FDB, SeekOrigin.Begin);
                bw.Write((byte)opcode);

                bw.Dispose();
            }
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            int minValue = 128;
            int maxValue = Convert.ToInt32(Math.Round(numericUpDown5.Value, 0));
            int finalValue = 0;
            int opcode = 0;

            if (maxValue >= 255)
            {
                opcode = 2;
                while (minValue <= maxValue - 128 * 2)
                {
                    opcode++;
                    minValue += 128;
                }
                finalValue = maxValue - minValue;

                BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf")); // temp, switch to %appdata% 

                bw.Seek(0x93A041, SeekOrigin.Begin);
                bw.Write((byte)finalValue);

                bw.Seek(0x93A042, SeekOrigin.Begin);
                bw.Write((byte)opcode);

                bw.Dispose();
            }
            else if (maxValue <= 255)
            {
                opcode = 1;

                BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf")); // temp, switch to %appdata% 


                bw.Seek(0x93A041, SeekOrigin.Begin);
                bw.Write((byte)maxValue);

                bw.Seek(0x93A042, SeekOrigin.Begin);
                bw.Write((byte)opcode);

                bw.Dispose();
            }
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            int minValue = 128;
            int maxValue = Convert.ToInt32(Math.Round(numericUpDown6.Value, 0));
            int finalValue = 0;
            int opcode = 0;

            if (maxValue >= 255)
            {
                opcode = 2;
                while (minValue <= maxValue - 128 * 2)
                {
                    opcode++;
                    minValue += 128;
                }
                finalValue = maxValue - minValue;

                BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf")); // temp, switch to %appdata% 

                bw.Seek(0x939F73, SeekOrigin.Begin);
                bw.Write((byte)finalValue);

                bw.Seek(0x939F74, SeekOrigin.Begin);
                bw.Write((byte)opcode);

                bw.Dispose();
            }
            else if (maxValue <= 255)
            {
                opcode = 1;

                BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf")); // temp, switch to %appdata% 


                bw.Seek(0x939F73, SeekOrigin.Begin);
                bw.Write((byte)maxValue);

                bw.Seek(0x939F74, SeekOrigin.Begin);
                bw.Write((byte)opcode);

                bw.Dispose();
            }
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            int minValue = 128;
            int maxValue = Convert.ToInt32(Math.Round(numericUpDown7.Value, 0));
            int finalValue = 0;
            int opcode = 0;

            if (maxValue >= 255)
            {
                opcode = 2;
                while (minValue <= maxValue - 128 * 2)
                {
                    opcode++;
                    minValue += 128;
                }
                finalValue = maxValue - minValue;

                BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf")); // temp, switch to %appdata% 

                bw.Seek(0x93A0A8, SeekOrigin.Begin);
                bw.Write((byte)finalValue);

                bw.Seek(0x93A0A9, SeekOrigin.Begin);
                bw.Write((byte)opcode);

                bw.Dispose();
            }
            else if (maxValue <= 255)
            {
                opcode = 1;

                BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf")); // temp, switch to %appdata% 


                bw.Seek(0x93A0A8, SeekOrigin.Begin);
                bw.Write((byte)maxValue);

                bw.Seek(0x93A0A9, SeekOrigin.Begin);
                bw.Write((byte)opcode);

                bw.Dispose();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int minValue = 128;
            int maxValue = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            int finalValue = 0;
            int opcode = 0;

            if (maxValue >= 255)
            {
                opcode = 2;
                while (minValue <= maxValue - 128 * 2)
                {
                    opcode++;
                    minValue += 128;
                }
                finalValue = maxValue - minValue;

                BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf")); // temp, switch to %appdata% 

                bw.Seek(0x939CFE, SeekOrigin.Begin);
                bw.Write((byte)finalValue);

                bw.Seek(0x939CFF, SeekOrigin.Begin);
                bw.Write((byte)opcode);

                bw.Dispose();
            }
            else if (maxValue <= 255)
            {
                opcode = 1;

                BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf")); // temp, switch to %appdata% 


                bw.Seek(0x939CFE, SeekOrigin.Begin);
                bw.Write((byte)maxValue);

                bw.Seek(0x939CFF, SeekOrigin.Begin);
                bw.Write((byte)opcode);

                bw.Dispose();
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            int minValue = 128;
            int maxValue = Convert.ToInt32(Math.Round(numericUpDown2.Value, 0));
            int finalValue = 0;
            int opcode = 0;

            if (maxValue >= 255)
            {
                opcode = 2;
                while (minValue <= maxValue - 128 * 2)
                {
                    opcode++;
                    minValue += 128;
                }
                finalValue = maxValue - minValue;

                BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf")); // temp, switch to %appdata% 

                bw.Seek(0x93A1CF, SeekOrigin.Begin);
                bw.Write((byte)finalValue);

                bw.Seek(0x93A1D0, SeekOrigin.Begin);
                bw.Write((byte)opcode);

                bw.Dispose();
            }
            else if (maxValue <= 255)
            {
                opcode = 1;

                BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf")); // temp, switch to %appdata% 


                bw.Seek(0x93A1CF, SeekOrigin.Begin);
                bw.Write((byte)maxValue);

                bw.Seek(0x93A1D0, SeekOrigin.Begin);
                bw.Write((byte)opcode);

                bw.Dispose();
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf"));
            bw.Seek(0x939ED0, SeekOrigin.Begin);

            if (checkBox1.Checked == true)
                bw.Write((byte)0);
            else
                bw.Write((byte)1);

             bw.Dispose();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf"));
            bw.Seek(0x939F9E, SeekOrigin.Begin);

            if (checkBox2.Checked)
                bw.Write((byte)0);
            else
                bw.Write((byte)1);

            bw.Dispose();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf"));
            bw.Seek(0x93A005, SeekOrigin.Begin);

            if (checkBox3.Checked)
                bw.Write((byte)0);
            else
                bw.Write((byte)1);

            bw.Dispose();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf"));
            bw.Seek(0x939F37, SeekOrigin.Begin);

            if (checkBox4.Checked)
                bw.Write((byte)0);
            else
                bw.Write((byte)1);

            bw.Dispose();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf"));
            bw.Seek(0x93A06C, SeekOrigin.Begin);

            if (checkBox5.Checked)
                bw.Write((byte)0);
            else
                bw.Write((byte)1);

            bw.Dispose();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf"));
            bw.Seek(0x939CC2, SeekOrigin.Begin);

            if (checkBox6.Checked)
                bw.Write((byte)0);
            else
                bw.Write((byte)1);

            bw.Dispose();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            BinaryWriter bw = new BinaryWriter(File.OpenWrite("C:\\Users\\Public\\omega277.swf"));
            bw.Seek(0x93A1AA, SeekOrigin.Begin);

            if (checkBox7.Checked)
                bw.Write((byte)0);
            else
                bw.Write((byte)1);

            bw.Dispose();
        }
    }
}

