using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Teste
{
    public partial class Form1 : Form
    {
        float num1, ans;
        int count;

        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        // 0
        private void btn0_Click(object sender, EventArgs e)
        {
            txtExibir.Text = txtExibir.Text + 0;
        }

        // 1
        private void btn1_Click(object sender, EventArgs e)
        {
            txtExibir.Text = txtExibir.Text + 1;
        }

        // 2
        private void btn2_Click(object sender, EventArgs e)
        {
            txtExibir.Text = txtExibir.Text + 2;
        }

        // 3
        private void btn3_Click(object sender, EventArgs e)
        {
            txtExibir.Text = txtExibir.Text + 3;
        }

        // 4
        private void btn4_Click(object sender, EventArgs e)
        {
            txtExibir.Text = txtExibir.Text + 4;
        }

        // 5
        private void btn5_Click(object sender, EventArgs e)
        {
            txtExibir.Text = txtExibir.Text + 5;
        }

        // 6
        private void btn6_Click(object sender, EventArgs e)
        {
            txtExibir.Text = txtExibir.Text + 6;
        }

        // 7
        private void btn7_Click(object sender, EventArgs e)
        {
            txtExibir.Text = txtExibir.Text + 7;
        }

        // 8
        private void btn8_Click(object sender, EventArgs e)
        {
            txtExibir.Text = txtExibir.Text + 8;
        }

        // 9
        private void btn9_Click(object sender, EventArgs e)
        {
            txtExibir.Text = txtExibir.Text + 9;
        }


        // Sub
        private void btnSub_Click(object sender, EventArgs e)
        {
            if (txtExibir.Text != "")
            {
                txtHist.Text = txtExibir.Text + "-";
                num1 = float.Parse(txtExibir.Text);
                txtExibir.Clear();
                txtExibir.Focus();
                count = 1;
                
            }
        }

        // Soma
        private void btnSoma_Click(object sender, EventArgs e)
        {
            if (txtExibir.Text != "")
            {
                txtHist.Text = txtExibir.Text + "+";
                num1 = float.Parse(txtExibir.Text);
                txtExibir.Clear();
                txtExibir.Focus();
                count = 2;
                
                
            }
        }

        // Mult
        private void btnMult_Click(object sender, EventArgs e)
        {
            if (txtExibir.Text != "")
            {
                txtHist.Text = txtExibir.Text + "*";
                num1 = float.Parse(txtExibir.Text);
                txtExibir.Clear();
                txtExibir.Focus();
               
                count = 3;
                

            }
        }

        // Div
        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (txtExibir.Text != "")
            {
                txtHist.Text = txtExibir.Text + "/";
                num1 = float.Parse(txtExibir.Text);
                txtExibir.Clear();
                txtExibir.Focus();
                
                count = 4;
                

            }
        }  
        
        // Igual
        private void btnTotal_Click(object sender, EventArgs e)
        {
            compute(count);

        }
        
        
        // Metodo dos calculos
        public void compute(int count)
        {
            switch (count)
            {
                case 1: // Sub
                    txtHist.Text = txtHist.Text + txtExibir.Text;
                    ans = num1 - float.Parse(txtExibir.Text);
                    txtExibir.Text = ans.ToString();
                    txtHist.Text = txtHist.Text + "=";
                 
                    break;
                
                case 2: // Soma
                    txtHist.Text = txtHist.Text + txtExibir.Text;
                    ans = num1 + float.Parse(txtExibir.Text);
                    txtExibir.Text = ans.ToString();
                    txtHist.Text = txtHist.Text + "=";
                    break;
                
                case 3: // Mult
                    txtHist.Text = txtHist.Text + txtExibir.Text;
                    ans = num1 * float.Parse(txtExibir.Text);
                    txtExibir.Text = ans.ToString();
                    txtHist.Text = txtHist.Text + "=";
                    
                    break;
                
                case 4: // Div
                    txtHist.Text = txtHist.Text + txtExibir.Text;
                    ans = num1 / float.Parse(txtExibir.Text);
                    txtExibir.Text = ans.ToString();
                    txtHist.Text = txtHist.Text + "=";
                    break;
                
                default:
                    break;
            }
        }


        private void txtHist_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        // Limpar
        private void btnC_Click(object sender, EventArgs e)
        {
            txtExibir.Clear();
            txtHist.Clear();
            count = 0;
        }


    }
}
