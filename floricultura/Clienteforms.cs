using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace floricultura
{
    public partial class Clienteforms : Form
    {
        ClienteDAO clienteD;
        public Clienteforms()
        {

            InitializeComponent();
            clienteD = new ClienteDAO();//ligação com a classe cliente do banco
        }

        private void Clienteforms_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//textbox rg

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//textboxnome

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//textboxtelefone

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//textbox endereco

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //preenchendo vetores llocais com dados
                string rg = textBox1.Text;//coletar rg
                string nome = textBox2.Text;
                string telefone = textBox3.Text;
                string endereco = textBox4.Text;

                //inserir dados no bd
                clienteD.inserir(rg, nome, telefone, endereco);
            }
            catch (Exception ero)
            {
                MessageBox.Show("algo deu errado!" + ero);
            }

            //limpar o campo
            limpar();

        }//botaocadastrar

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                clienteD.FiltrarCliente(textBox1.Text);

            }
            catch (Exception ero)
            {
                MessageBox.Show("algo seu errado" + ero);
            }

        }//botaoconsultar

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    clienteD.atualizarnome(textBox2.Text, textBox1.Text);
                }
                if (textBox3.Text != "")
                {
                    clienteD.atualizartelefone(textBox3.Text, textBox1.Text);
                }
                if (textBox4.Text != "")
                {
                    clienteD.atualizarendereco(textBox4.Text, textBox1.Text);
                }
            }
            catch (Exception ero)
            {
                MessageBox.Show("algo deu errado!" + ero);
            }
        }//botaoatualizar

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                clienteD.excluir(textBox1.Text);
            }
            catch (Exception ero)
            {
                MessageBox.Show("algo deu errado" + ero);
            }
        }//botaodeletar

        private void button5_Click(object sender, EventArgs e)
        {
            limpar();
        }//botaolimpar

        public void limpar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clienteD.consultartudo();
        }//botaoconsultartudo
    }
}
