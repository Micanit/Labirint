using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Помощь программа = new Помощь();
            программа.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Настройки программа = new Настройки();
            программа.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Начать_игру программа = new Начать_игру();
            программа.ShowDialog();
        }
    }
}
