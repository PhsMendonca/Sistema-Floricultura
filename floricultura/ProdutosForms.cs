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
    public partial class ProdutosForms : Form
    {
        ProdutoDAO produtosD;
        public ProdutosForms()
        {
            InitializeComponent();
            produtosD = new ProdutoDAO();
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //preenchendo vetores locais com dados
                Int64 codigo = Convert.ToInt64(maskedTextBox3.Text);
                string nomeproduto = textBox1.Text;
                string tipo = textBox2.Text;
                double preco = Convert.ToDouble(maskedTextBox2.Text);
                Int64 quantidade = Convert.ToInt64(maskedTextBox1.Text);

                //inserir dados no bd
                produtosD.inserir(codigo, nomeproduto, tipo, preco, quantidade);
            }
            catch (Exception ero)
            {
                MessageBox.Show("algo deu errado!" + ero);
            }

            //limpar o campo
            limpar();
        }//botao cadastrar

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                produtosD.FiltrarProdutos(Convert.ToInt64(maskedTextBox3.Text));

            }
            catch (Exception ero)
            {
                MessageBox.Show("algo seu errado" + ero);
            }
        }//consultar

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    produtosD.atualizarnomeproduto(textBox1.Text, Convert.ToInt64(maskedTextBox3.Text));
                }
                if (maskedTextBox1.Text != "")
                {
                    produtosD.atualizarpreco(maskedTextBox2.Text, Convert.ToInt64(maskedTextBox3.Text));
                }
                if (maskedTextBox2.Text != "")
                {
                    produtosD.atualizarquantidade(maskedTextBox1.Text, Convert.ToInt64(maskedTextBox3.Text));
                }
                if (textBox2.Text != "")
                {
                    produtosD.atualizartipo(textBox2.Text, Convert.ToInt64(maskedTextBox3.Text));
                }
            }
            catch (Exception ero)
            {
                MessageBox.Show("algo deu errado!" + ero);
            }
        }//atualizar

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                produtosD.excluir(Convert.ToInt64(maskedTextBox3.Text));
            }
            catch (Exception ero)
            {
                MessageBox.Show("algo deu errado" + ero);
            }
        }//deletar

        private void button5_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void ProdutosForms_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            produtosD.consultartudo();
        }

        public void limpar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
        }
    }
}
