using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Interfaces;
using WindowsFormsApp1.Providers;
using WindowsFormsApp1.Structures;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ILoader _loader = LoaderProvider.GetLoader();

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Load();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
        }

        new private void Load()
        {
            var data = _loader.Load();
            Height = data.Height;
            Width = data.Width;
            Location = new Point(data.Xcoord, data.Ycoord);
            textBox1.Text = data.Text;
            checkBox1.Checked = data.Check1;
            checkBox2.Checked = data.Check2;
        }

        private void Save()
        {
            _loader.Save(new StartData(Height, Width, Location.X, Location.Y, 
                        textBox1.Text, checkBox1.Checked, checkBox2.Checked));
        }
    }
}
