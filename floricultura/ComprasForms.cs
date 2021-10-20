using System;
using System.Windows.Forms;

namespace floricultura
{
    public partial class ComprasForms : Form
    {
        ComprasDAO comprasD;
        public ComprasForms()
        {
            InitializeComponent();
            comprasD = new ComprasDAO();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            limpar();
        }//limpar

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //preenchendo vetores locais com dados
                string pedido = textBox3.Text;
                string nomecliente = textBox1.Text;
                string datacompra = maskedTextBox1.Text;
                string valortotal = maskedTextBox2.Text;
                string produtoscomprados = textBox2.Text;

                //inserir dados no bd
                comprasD.inserir(pedido, nomecliente, datacompra, valortotal, produtoscomprados);
            }
            catch (Exception ero)
            {
                MessageBox.Show("algo deu errado!" + ero);
            }

            //limpar o campo
            limpar();
        }//cadastrar

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                comprasD.FiltrarCompras(textBox3.Text);

            }
            catch (Exception ero)
            {
                MessageBox.Show("algo seu errado" + ero);
            }
        }//consultar

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    comprasD.atualizarnomecliente(textBox1.Text, textBox3.Text);
                }
                if (maskedTextBox1.Text != "")
                {
                    comprasD.atualizardatacompra(maskedTextBox1.Text, textBox3.Text);
                }
                if (maskedTextBox2.Text != "")
                {
                    comprasD.atualizarvalortotal(maskedTextBox2.Text, textBox3.Text);
                }
                if (textBox2.Text != "")
                {
                    comprasD.atualizarprodutoscomprados(textBox2.Text, textBox3.Text);
                }
            }
            catch (Exception ero)
            {
                MessageBox.Show("algo deu errado!" + ero);
            }
        }//atualizar

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                comprasD.excluir(textBox3.Text);
            }
            catch (Exception ero)
            {
                MessageBox.Show("algo deu errado" + ero);
            }
        }//deletar

        private void label6_Click(object sender, EventArgs e)
        {

        }//limpar

        public void limpar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            comprasD.consultartudo();
        }
    }
}
