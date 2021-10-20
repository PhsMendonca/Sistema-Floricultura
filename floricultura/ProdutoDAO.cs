using MySql.Data.MySqlClient;//ligand
using System;
using System.Windows.Forms;


namespace floricultura
{
    class ProdutoDAO
    {
        public string valor, resultado;
        private MySqlConnection conexao;// defini uma variavel para abertura e fechamento da conexão
        public long[] codigoDAO;
        public string[] nomeprodutoDAO;
        public string[] tipoDAO;
        public double[] precoDAO;
        public long[] quantidadeDAO;
        public int contador;


        public ProdutoDAO()
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

        public void inserir(long codigo, string nomeproduto, string tipo, double preco, long quantidade)
        {
            try
            {
                //montando a sentença para inserção no banco
                valor = "'" + codigo + "','" + nomeproduto + "','" + tipo + "','" + preco + "','" + quantidade + "'";
                resultado = "insert into produto(codigo,nomeproduto,tipo,preco,quantidade) values(" + valor + ")";
                //mandar executar a inserção
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();//resultado da operação
                                                       //mostrar essa mensagem em tela
                MessageBox.Show(resultado + "produto cadastrado");
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
                string query = "select * from produto";//query que coleta todos os dados de cliente
                codigoDAO = new long[20];
                nomeprodutoDAO = new string[20];
                tipoDAO = new string[20];
                precoDAO = new double[20];
                quantidadeDAO = new long[20];

                //popular o vetor - preencher o vetor com valores inicias
                for (int i = 0; i < 20; i++)
                {
                    codigoDAO[i] = 0;
                    nomeprodutoDAO[i] = "";
                    tipoDAO[i] = "";
                    precoDAO[i] = 0;
                    quantidadeDAO[i] = 0;
                }

                //criar o comando do banco de dados
                MySqlCommand sql = new MySqlCommand(query, conexao);

                //utilizar um elemento para leitura de uma grande qntd de dados de um banco
                MySqlDataReader leitura = sql.ExecuteReader();

                contador = 0;
                while (leitura.Read())
                {
                    codigoDAO[contador] = Convert.ToInt64(leitura["codigo"]);
                    nomeprodutoDAO[contador] = leitura["nomeproduto"] + "";
                    tipoDAO[contador] = leitura["tipo"] + "";
                    precoDAO[contador] = Convert.ToDouble(leitura["preco"]);
                    quantidadeDAO[contador] = Convert.ToInt64(leitura["quantidade"]);
                    contador++;

                }

                //ao termino é necessario encerrar o datareader
                leitura.Close();
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void FiltrarProdutos(long codigo)
        {
            try
            {
                string query = "select * from produto where codigo = '" + codigo + "'";

                codigoDAO   = new long[20];
                nomeprodutoDAO = new string[20];
                tipoDAO = new string[20];
                precoDAO = new double[20];
                quantidadeDAO = new long[20];

                //popular o vetor - preencher o vetor com valores inicias
                for (int i = 0; i < 20; i++)
                {
                    codigoDAO[i] = 0;
                    nomeprodutoDAO[i] = "";
                    tipoDAO[i] = "";
                    precoDAO[i] = 0;
                    quantidadeDAO[i] = 0;
                }

                //criar o comando do banco de dados
                MySqlCommand sql = new MySqlCommand(query, conexao);

                //utilizar um elemento para leitura de uma grande qntd de dados de um banco
                MySqlDataReader leitura = sql.ExecuteReader();

                contador = 0;
                while (leitura.Read())
                {
                    codigoDAO[contador] = Convert.ToInt64(leitura["codigo"]);
                    nomeprodutoDAO[contador] = leitura["nomeproduto"] + "";
                    tipoDAO[contador] = leitura["tipo"] + "";
                    precoDAO[contador] = Convert.ToDouble(leitura["preco"]);
                    quantidadeDAO[contador] = Convert.ToInt64(leitura["quantidade"]);
                    contador++;
                }

                //ao termino é necessario encerrar o datareader
                leitura.Close();

                string msg = "";
                for (int i = 0; i < contador; i++)
                {
                    msg +=  "\ncodigo: "     + codigoDAO[i] +
                            "\nnomeproduto:" + nomeprodutoDAO[i] +
                            "\ntipo:"        + tipoDAO +
                            "\npreco: "      + precoDAO[i] +
                            "\nquantidade; " + quantidadeDAO[i];
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
            selecionar(); //preencher o vetor com os dados do banco de dados
            string msg = "";
            for (int i = 0; i < contador; i++)
            {
                msg += "\ncodigo: "      + codigoDAO[i]      +
                       "\nnomeproduto: " + nomeprodutoDAO[i] +
                       "\ntipo:"         + tipoDAO[i]        +
                       "\npreco: "       + precoDAO[i]       +
                       "\nquantidade:"   + quantidadeDAO[i];
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

        //buscar nome
        public string consultarnomeproduto(long codigodigitado)
        {
            try
            {
                selecionar(); // faz a busca do dado na base e preenche os vetores
                for (int i = 0; i < contador; i++)
                {
                    if (codigoDAO[i] == codigodigitado)
                    {
                        return nomeprodutoDAO[i];
                    }
                }
                return "não encontrado!";
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public string consultartipo(long codigodigitado)
        {
            try
            {
                selecionar(); // faz a busca do dado na base e preenche os vetores
                for (int i = 0; i < contador; i++)
                {
                    if (codigoDAO[i] == codigodigitado)
                    {
                        return tipoDAO[i];
                    }
                }
                return "não encontrado!";
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public double consultarpreco(long codigodigitado)
        {
            try
            {
                selecionar(); // faz a busca do dado na base e preenche os vetores
                for (int i = 0; i < contador; i++)
                {
                    if (codigoDAO[i] == codigodigitado)
                    {
                        return precoDAO[i];
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public long consultarquantidade(long codigodigitado)
        {
            try
            {
                selecionar(); // faz a busca do dado na base e preenche os vetores
                for (int i = 0; i < contador; i++)
                {
                    if (codigoDAO[i] == codigodigitado)
                    {
                        return quantidadeDAO[i];
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void atualizarnomeproduto(string dadodigitado, long codigodigitado)
        {
            try
            {
                resultado = "update produto set nomeproduto " + " = '" + dadodigitado + "' where codigo = '" + codigodigitado + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                //mensagem
                MessageBox.Show(resultado + "nome produto atualizado");
            }
            catch (Exception e)
            {
                MessageBox.Show("erro!" + e);
            }
        }

        public void atualizartipo(string dadodigitado, long codigodigitado)
        {
            try
            {
                resultado = "update produto set tipo " + " = '" + dadodigitado + "' where codigo = '" + codigodigitado + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                //mensagem
                MessageBox.Show(resultado + "tipo atualizado");
            }
            catch (Exception e)
            {
                MessageBox.Show("erro!" + e);
            }
        }

        public void atualizarpreco(string dadodigitado, long codigodigitado)
        {
            try
            {
                resultado = "update produto set preco " + " = '" + dadodigitado + "' where codigo = '" + codigodigitado + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                //mensagem
                MessageBox.Show(resultado + "preço atualizado");
            }
            catch (Exception e)
            {
                MessageBox.Show("erro!" + e);
            }
        }

        public void atualizarquantidade(string dadodigitado, long codigodigitado)
        {
            try
            {
                resultado = "update produto set quantidade " + " = '" + dadodigitado + "' where codigo = '" + codigodigitado + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                //mensagem
                MessageBox.Show(resultado + "quantidade atualizada");
            }
            catch (Exception e)
            {
                MessageBox.Show("erro!" + e);
            }

        }

        //excluir
        public void excluir(long codigodigitado)
        {
            try
            {
                resultado = "delete from produto where codigo = '" + codigodigitado + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                //mensagem
                MessageBox.Show(resultado + "produto deletado");
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
