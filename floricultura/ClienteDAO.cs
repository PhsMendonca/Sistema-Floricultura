using MySql.Data.MySqlClient;//ligand
using System;
using System.Windows.Forms;

namespace floricultura
{

    class ClienteDAO
    {
        public string valor, resultado;
        private MySqlConnection conexao;// defini uma variavel para abertura e fechamento da conexão
        public string[] rgDAO;
        public string[] nomeDAO;
        public string[] telefoneDAO;
        public string[] enderecoDAO;
        public int contador;


        public ClienteDAO()
        {
            conexao = new MySqlConnection("server=127.0.0.1;port=3306;User Id=root;database=floricultura;password=; SSL Mode=none");
            //var connection = new MySqlConnection("Data Source=127.0.0.1;Database=MyDb1;User Id=root;Password=blabla;SSL Mode=Required");
            try
            {
                conexao.Open();
                //MessageBox.Show("conexão efetuada com sucesso");
           
            }
            catch (Exception e)
            {
                MessageBox.Show("erro!" + e);
                conexao.Close();
            }
        }

        public void inserir(string rg, string nome, string telefone, string endereco)
        {
            try
            {
                //montando a sentença para inserção no banco
                valor = "'" + rg + "','" + nome + "','" + telefone + "','" + endereco + "'";
                resultado = "insert into cliente(rg,nome,telefone,endereco) values(" + valor + ")";
                //mandar executar a inserção
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();//resultado da operação
                                                       //mostrar essa mensagem em tela
                MessageBox.Show(resultado + "cliente cadastrado com sucesso!");
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
                string query = "select * from cliente";//query que coleta todos os dados de cliente
                rgDAO = new string[20];
                nomeDAO = new string[20];
                telefoneDAO = new string[20];
                enderecoDAO = new string[20];

                //popular o vetor - preencher o vetor com valores inicias
                for (int i = 0; i < 20; i++)
                {
                    rgDAO[i] = "";
                    nomeDAO[i] = "";
                    telefoneDAO[i] = "";
                    enderecoDAO[i] = "";
                }

                //criar o comando do banco de dados
                MySqlCommand sql = new MySqlCommand(query, conexao);

                //utilizar um elemento para leitura de uma grande qntd de dados de um banco
                MySqlDataReader leitura = sql.ExecuteReader();

                contador = 0;
                while (leitura.Read())
                {
                    rgDAO[contador] = leitura["rg"] + "";
                    nomeDAO[contador] = leitura["nome"] + "";
                    telefoneDAO[contador] = leitura["telefone"] + "";
                    enderecoDAO[contador] = leitura["endereco"] + "";
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

        public void FiltrarCliente(string rg)
        {
            try
            {
                string query = "select * from cliente where rg = '" + rg + "'";

                //string query = @"select * from cliente";//query que coleta todos os dados de cliente
                rgDAO = new string[20];
                nomeDAO = new string[20];
                telefoneDAO = new string[20];
                enderecoDAO = new string[20];

                //popular o vetor - preencher o vetor com valores inicias
                for (int i = 0; i < 20; i++)
                {
                    rgDAO[i] = "";
                    nomeDAO[i] = "";
                    telefoneDAO[i] = "";
                    enderecoDAO[i] = "";
                }

                //criar o comando do banco de dados
                MySqlCommand sql = new MySqlCommand(query, conexao);

                //utilizar um elemento para leitura de uma grande qntd de dados de um banco
                MySqlDataReader leitura = sql.ExecuteReader();

                contador = 0;
                while (leitura.Read())
                {
                    rgDAO[contador] = leitura["rg"] + "";
                    nomeDAO[contador] = leitura["nome"] + "";
                    telefoneDAO[contador] = leitura["telefone"] + "";
                    enderecoDAO[contador] = leitura["endereco"] + "";
                    contador++;
                }

                //ao termino é necessario encerrar o datareader
                leitura.Close();

                string msg = "";
                for (int i = 0; i < contador; i++)
                {
                    msg += "\nrg: " + rgDAO[i] +
                            "\nnome:" + nomeDAO[i] +
                            "\ntelefone: " + telefoneDAO[i] +
                            "\nendereco:" + enderecoDAO[i];
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

        //mostrar o resultado da consulta em tela
        public void consultartudo()
        {
            try
            {
                selecionar(); //preencher o vetor com os dados do banco de dados
                string msg = "";
                for (int i = 0; i < contador; i++)
                {
                    msg +=  "\nrg: " + rgDAO[i] +
                            "\nnome:" + nomeDAO[i] +
                            "\ntelefone: " + telefoneDAO[i] +
                            "\nendereco:" + enderecoDAO[i];
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

        //buscar nome
        public string consultarnome(string rgdigitado)
        {
            try
            {
                selecionar(); // faz a busca do dado na base e preenche os vetores
                for (int i = 0; i < contador; i++)
                {
                    if (rgDAO[i] == rgdigitado)
                    {
                        return nomeDAO[i];
                    }
                }
                return "não encontrado!";
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public string consultartelefone(string rgdigitado)
        {
            try
            {
                selecionar(); // faz a busca do dado na base e preenche os vetores
                for (int i = 0; i < contador; i++)
                {
                    if (rgDAO[i] == rgdigitado)
                    {
                        return telefoneDAO[i];
                    }
                }
                return "não encontrado!";
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public string consultarendereco(string rgdigitado)
        {
            try
            {
                selecionar(); // faz a busca do dado na base e preenche os vetores
                for (int i = 0; i < contador; i++)
                {
                    if (rgDAO[i] == rgdigitado)
                    {
                        return enderecoDAO[i];
                    }
                }
                return "não encontrado!";
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void atualizarnome(string dadodigitado, string rgdigitado)
        {
            try
            {

                resultado = "update cliente set nome " + " = '" + dadodigitado + "' where rg = '" + rgdigitado + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                //mensagem
                MessageBox.Show(resultado + "nome atualizado");
            }
            catch (Exception e)
            {
                MessageBox.Show("erro!" + e);
            }
        }

        public void atualizartelefone(string dadodigitado, string rgdigitado)
        {
            try
            {

                resultado = "update cliente set telefone " + " = '" + dadodigitado + "' where rg = '" + rgdigitado + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                //mensagem
                MessageBox.Show(resultado + "telefone atualizado");
            }
            catch (Exception e)
            {
                MessageBox.Show("erro!" + e);
            }
        }

        public void atualizarendereco(string dadodigitado, string rgdigitado)
        {
            try
            {
                resultado = "update cliente set endereco " + " = '" + dadodigitado + "' where rg = '" + rgdigitado + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                //mensagem
                MessageBox.Show(resultado + "endereço atualizado");
            }
            catch (Exception e)
            {
                MessageBox.Show("erro!" + e);
            }
        }

        //excluir
        public void excluir(string rgdigitado)
        {
            try
            {
                resultado = "delete from cliente where rg = '" + rgdigitado + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                //mensagem
                MessageBox.Show(resultado + "cliente deletado");
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
