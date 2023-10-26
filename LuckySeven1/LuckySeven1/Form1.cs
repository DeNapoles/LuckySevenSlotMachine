using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuckySeven1
{
    public partial class Form1 : Form
    {
        private int credits = 100; // Variável para controlar os créditos do jogador
        int resultado;
        public Form1()
        {
            InitializeComponent();
            credits = 100;
            UpdateCreditsLabel();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult resposta;
            resposta = MessageBox.Show("Tem a certeza?", "Confirmar", MessageBoxButtons.YesNo);
            if(resposta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnspin_Click(object sender, EventArgs e)
        {
            credits -= 1; // Cada spin custa 10 créditos
            MessageBox.Show("Você perdeu 10 créditos!", "Aviso", MessageBoxButtons.OK);
            UpdateCreditsLabel();

            if (credits >= 10)
            {
                pictureBox2.Visible = false;// Ocultar a imagem de ganhou
                pictureBox3.Visible = false;

                Random rnd = new Random();// Criar um gerador de números aleatórios

                int num1 = rnd.Next(1, 8);
                int num2 = rnd.Next(1, 8);
                int num3 = rnd.Next(1, 8);

                label1.Text = num1.ToString();
                label2.Text = num2.ToString();
                label3.Text = num3.ToString();

                int pontos = 0; //pontos que vou receber

                

                if (num1 == 7 && num2 == 7 && num3 == 7)
                {
                    pontos = 100; // Jackpot: 100 créditos
                    pictureBox3.Visible = true;
                }
                else if (num1 == 7 && num2 == 7)
                {
                    pontos = 50; // Dois 7: 50 créditos
                    pictureBox2.Visible = true;
                }
                else if (num1 == 7 || num2 == 7 || num3 == 7)
                {
                    pontos = 20; // Um 7: 20 créditos
                }

                if (pontos > 0)
                {
                    credits += pontos;
                    UpdateCreditsLabel();
                    MessageBox.Show($"Você ganhou {pontos} crédito(s)!", "Parabéns", MessageBoxButtons.OK);
                }
            }
            else if (credits < 10)
            { 

                DialogResult resposta;
                resposta = MessageBox.Show("Nao tens mais dinheiro para apostar, ficas-te pobre.", "Confirmar", MessageBoxButtons.OK);
                MessageBox.Show("A minha avó sempre me disse (Insiste sempre nunca apostes), fica a dica.", "Confirmar", MessageBoxButtons.OK);
                if (resposta == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            
        }

        private void UpdateCreditsLabel()
        {
            lblWins.Text = "Saldo: " + credits;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
