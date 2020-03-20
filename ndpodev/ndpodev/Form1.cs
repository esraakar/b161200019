using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ndpodev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        int hak = 5;
        private void button1_Click(object sender, EventArgs e)
        {

            if(textBox1.Text==" "||textBox2.Text == "")
            {
                MessageBox.Show("Kullanıcı adı ve/veya şifre boş geçilemez", "Uyarı");
            }
            else
            {
                if(textBox1.Text=="asanmobilya" && textBox2.Text == "123")
                {
                    Form2 frm = new Form2();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    hak--;
                    MessageBox.Show("Kullanıcı adı ve/veya şifre yanlış.Kalan hakkınız: "+hak, "Uyarı");
                    if (hak == 0)
                    {
                        Application.Exit();
                    }
                }
            }





        }
    }
}
