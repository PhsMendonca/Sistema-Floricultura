using MySql.Data.MySqlClient;//ligand
using System;
using System.Windows.Forms;

namespace floricultura
{
    class ComprasDAO
    {
        public string valor, resultado;
        private MySqlConnection conexao;// defini uma variavel para abertura e fechamento da conexão
        public string [] pedidoDAO;
        public string[] nomeclienteDAO;
        public string[] datacompraDAO;
        public string[] valortotalDAO;
        public string[] produtoscompradosDAO;
        public int contador;


        public ComprasDAO()
        {
            conexao = new MySqlConnection("server=127.0.0.1;port=3306;User Id=root;database=floricultura;password=; SSL Mode=none");
            try
            {
                conexao.Open();
                MessageBox.Show("conexão efetuada com sucesso");
            }
            catch (Exception e)
            {
                MessageBox.Show("erro!" + e);
                conexao.Close();
            }
        }

        public void inserir(string pedido, string nomecliente, string datacompra, string valortotal, string produtoscomprados)
        {
            try
            {
                //montando a sentença para inserção no banco
                valor = "'" + pedido + "','" + nomecliente + "','" + datacompra + "','" + valortotal + "','" + produtoscomprados + "'";
                resultado = "insert into compra(pedido,nomecliente,datacompra,valortotal,produtoscomprados) values(" + valor + ")";
                //mandar executar a inserção
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();//resultado da operação
                                                       //mostrar essa mensagem em tela
                MessageBox.Show(resultado + "compra cadastrada");
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
        }

        //select
       public void selecionar()
        {
            try
            {
                string query = "select * from compra";//query que coleta todos os dados de cliente
                pedidoDAO = new string[20];
                nomeclienteDAO = new string[20];
                datacompraDAO = new string[20];
                valortotalDAO = new string[20];
                produtoscompradosDAO = new string[20];

                //popular o vetor - preencher o vetor com valores inicias
                for (int i = 0; i < 20; i++)
                {
                    pedidoDAO[i] = "";
                    nomeclienteDAO[i] = "";
                    datacompraDAO[i] = "";
                    valortotalDAO[i] = "";
                    produtoscompradosDAO[i] = "";
                }

                //criar o comando do banco de dados
                MySqlCommand sql = new MySqlCommand(query, conexao);

                //utilizar um elemento para leitura de uma grande qntd de dados de um banco
                MySqlDataReader leitura = sql.ExecuteReader();

                contador = 0;
                while (leitura.Read())
                {
                    pedidoDAO[contador] = leitura["pedido"] + "";
                    nomeclienteDAO[contador] = leitura["nomecliente"] + "";
                    datacompraDAO[contador] = leitura["datacompra"] + "";
                    valortotalDAO[contador] = leitura["valortotal"] + "";
                    produtoscompradosDAO[contador] = leitura["produtoscomprados"] + "";
                    contador++;
                    
                }

                //ao termino é necessario encerrar o datareader
                leitura.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("erro" + e);
            }
       }

        public void FiltrarCompras(string pedido)
        {
            try
            {
                string query = "select * from compra where pedido = '" + pedido + "'";

                //string query = "select * from cliente";//query que coleta todos os dados de cliente
                pedidoDAO = new string[20];
                nomeclienteDAO = new string[20];
                datacompraDAO = new string[20];
                valortotalDAO = new string[20];
                produtoscompradosDAO = new string[20];

                //popular o vetor - preencher o vetor com valores inicias
                for (int i = 0; i < 20; i++)
                {
                    pedidoDAO[i] = "";
                    nomeclienteDAO[i] = "";
                    datacompraDAO[i] = "";
                    valortotalDAO[i] = "";
                    produtoscompradosDAO[i] = "";
                }

                //criar o comando do banco de dados
                MySqlCommand sql = new MySqlCommand(query, conexao);

                //utilizar um elemento para leitura de uma grande qntd de dados de um banco
                MySqlDataReader leitura = sql.ExecuteReader();

                contador = 0;
                while (leitura.Read())
                {
                    pedidoDAO[contador] = leitura["pedido"] + "";
                    nomeclienteDAO[contador] = leitura["nomecliente"] + "";
                    datacompraDAO[contador] = leitura["datacompra"] + "";
                    valortotalDAO[contador] = leitura["valortotal"] + "";
                    produtoscompradosDAO[contador] = leitura["produtoscomprados"] + "";
                    contador++;
                }

                //ao termino é necessario encerrar o datareader
                leitura.Close();

                string msg = "";
                for (int i = 0; i < contador; i++)
                {
                    msg += "\npedido: "             + pedidoDAO[i]      +
                            "\nnomecliente:"        + nomeclienteDAO[i] +
                            "\ndatacompra:"         + datacompraDAO     +
                            "\nvalortotal: "        + valortotalDAO[i]  +
                            "\nprodutoscomprados; " + produtoscompradosDAO[i];
                }
                if (msg != "")
                {
                    MessageBox.Show(msg);
                }
                else
                {
                    MessageBox.Show("nenhum registro encontrado");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
        }

        //mostrar o resultado da consulta em tela
        public void consultartudo()
        {
            try
            {
                selecionar(); //preencher o vetor com os dados do banco de dados
                string msg = "";
                for (int i = 0; i < contador; i++)
                {
                    msg += "\npedido:" + pedidoDAO[i] +
                            "\nnomecliente: " + nomeclienteDAO[i] +
                            "\ndatacompra:" + datacompraDAO[i] +
                            "\nvalortotal: " + valortotalDAO[i] +
                            "\nprodutoscomprados:" + produtoscompradosDAO[i];
                }
                if (msg != "")
                {
                    MessageBox.Show(msg);
                }
                else
                {
                    MessageBox.Show("nenhum registro encontrado");
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //buscarnomecliente
        public string consultarnomecliente(string pedidodigitado)
        {
            try
            {
                selecionar(); // faz a busca do dado na base e preenche os vetores
                for (int i = 0; i < contador; i++)
                {
                    if (pedidoDAO[i] == pedidodigitado)
                    {
                        return nomeclienteDAO[i];
                    }
                }
                return "não encontrado!";
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //buscar datacompra
        public string consultardatacompra(string pedidodigitado)
        {
            try
            {
                selecionar(); // faz a busca do dado na base e preenche os vetores
                for (int i = 0; i < contador; i++)
                {
                    if (pedidoDAO[i] == pedidodigitado)
                    {
                        return datacompraDAO[i];
                    }
                }
                return "não encontrado";
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public string consultarvalortotal(string pedidodigitado)
        {
            try
            {
                selecionar(); // faz a busca do dado na base e preenche os vetores
                for (int i = 0; i < contador; i++)
                {
                    if (pedidoDAO[i] == pedidodigitado)
                    {
                        return valortotalDAO[i];
                    }
                }
                return "não encontrado!";
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public string consultarprodutoscomprados(string pedidodigitado)
        {
            try
            {
                selecionar(); // faz a busca do dado na base e preenche os vetores
                for (int i = 0; i < contador; i++)
                {
                    if (pedidoDAO[i] == pedidodigitado)
                    {
                        return produtoscompradosDAO[i];
                    }
                }
                return "não encontrado!";
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void atualizarnomecliente(string dadodigitado, string pedidodigitado)
        {
            try
            {
                resultado = "update compra set nomecliente " + " = '" + dadodigitado + "' where pedido = '" + pedidodigitado + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                //mensagem
                MessageBox.Show(resultado + "nome cliente atualizado");
            }
            catch (Exception e)
            {
                MessageBox.Show("erro!" + e);
            }
        }

        public void atualizardatacompra(string dadodigitado, string pedidodigitado)
        {
            try
            {
                resultado = "update compra set datacompra " + " = '" + dadodigitado + "' where pedido = '" + pedidodigitado + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                //mensagem
                MessageBox.Show(resultado + "data compra atualizada");
            }
            catch (Exception e)
            {
                MessageBox.Show("erro!" + e);
            }
        }

        public void atualizarvalortotal(string dadodigitado, string pedidodigitado)
        {
            try
            {
                resultado = "update compra set valortotal " + " = '" + dadodigitado + "' where pedido = '" + pedidodigitado + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                //mensagem
                MessageBox.Show(resultado + "valor total atualizado");
            }
            catch (Exception e)
            {
                MessageBox.Show("erro!" + e);
            }
        }

        public void atualizarprodutoscomprados(string dadodigitado, string pedidodigitado)
        {
            try
            {
                resultado = "update compra set produtoscomprados " + " = '" + dadodigitado + "' where pedido = '" + pedidodigitado + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                //mensagem
                MessageBox.Show(resultado + "produtos atualizados");
            }
            catch (Exception e)
            {
                MessageBox.Show("erro!" + e);
            }
        }

        //excluir
        public void excluir(string pedidodigitado)
        {
            try
            {
                resultado = "delete from compra where pedido = '" + pedidodigitado + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                //mensagem
                MessageBox.Show(resultado + "compra deletada");
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
