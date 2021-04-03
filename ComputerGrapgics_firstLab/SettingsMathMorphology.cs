using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerGraphics_firstLab
{
    public partial class SettingsMathMorphology : Form
    {
        int size = 5;

        public SettingsMathMorphology()
        {
            InitializeComponent();
            textBox1.Text = size.ToString();
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                size = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                PrintError();
            }

            if((size < 2) || (size % 2 == 0))
            {
                PrintError();
            }

            Close();
        }

        private void PrintError()
        {
            MessageBox.Show("Введено неверное значение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
