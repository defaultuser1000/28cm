using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _28cm
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(@"D:\Учеба\ВУЗ\Мерген\28cm\28cm_2\28cm\28cm\28cm\bin\Release\Кнопки\ОК нажат.png", false);
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            Close();
        }
    }
}
