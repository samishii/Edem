using System.Windows.Forms;

namespace Core
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            FiddlerCore.Listen();
            InitializeComponent();
        }
    }
}
