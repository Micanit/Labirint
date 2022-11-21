using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirint
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {
            Помощь программа = new Помощь();
            программа.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Начать_игру программа = new Начать_игру();
            программа.ShowDialog();
        }
    }
}
