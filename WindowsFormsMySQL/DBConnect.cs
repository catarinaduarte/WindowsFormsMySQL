using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsMySQL
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string port;

        public DBConnect()
        {
            Initialize();
        }
        private void Initialize()
        {
            server =  "grandeporto.ddns.net"; // "192.168.1.80"; //"144.64.133.106";
            database = "formandos_prog07";
            uid = "prog07";  
            password = "1234";
            port = "3306";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" +
                "PASSWORD=" + password + ";" + "PORT=" + port + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public int Count()
        {
            string query = "select count(*) from formando;";

            int count = -1;

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                count = int.Parse(cmd.ExecuteScalar().ToString());

                CloseConnection();
            }

            return count;
        }

        public void Insert()
        {
            string query = "Insert into formando values (1, 'Pinto da Costa', 'Rua do Porto', NULL, 'PT5000000','m', '1950-06-22')";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    //CloseConnection();
                }

            }
            catch (MySqlException ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            
        }

        public bool Insert(string id, string nome, string morada, string contacto, string iban, char genero, string data_Nascimento, string id_nacionalidade)
        {
            bool flag = true;

            string query = "insert into formando (id_formando, nome, morada, contacto, iban, sexo, data_nascimento, id_nacionalidade) " +
                "values(" + id + ",'" + nome + "','" + morada + "','" + contacto + "','" +
                iban + "','" + genero + "','" + data_Nascimento + "', " + id_nacionalidade + ")";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public int DevolveUltimoID()
        {
            int ultimoID = 0;
            string query = "SELECT max(id_formando) FROM formando";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //ultimoID = Convert.ToInt32(cmd.ExecuteScalar());
                    int.TryParse(cmd.ExecuteScalar().ToString(), out ultimoID);
                    ultimoID++;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return ultimoID;
        }

        public bool PesquisaFormando(string idpesquisa, ref string nome, ref string morada, 
            ref string contacto, ref string iban, ref char genero, ref string data_Nascimento)
        {
            //string query = "select * from formando where id_formando = " + idpesquisa;
            string query = "select nome, morada, contacto, iban, sexo, data_nascimento from formando where id_formando = " + idpesquisa;


            bool flag = false;

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        nome = dataReader[0].ToString();
                        morada = dataReader["morada"].ToString();
                        contacto = dataReader[2].ToString();
                        iban = dataReader[3].ToString();
                        genero = dataReader[4].ToString()[0];
                        data_Nascimento = dataReader[5].ToString();
                        flag = true;
                    }
                    dataReader.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public bool Delete(string id)
        {
            bool flag = true;

            string query = "delete from formando where id_formando = " + id;

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public void PreencherComboNacionalidade(ref ComboBox combo)
        {
            string query = "select id_nacionalidade, alf2, nacionalidade from " +
                "Nacionalidade order by nacionalidade;";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        combo.Items.Add(dr[2].ToString() + " - " +
                            dr["alf2"].ToString() + " - " + dr[0].ToString());
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool PesquisaNacionalidade(string id_nacionalidade, ref string alf2, ref string nacionalidade)
        {
            bool flag = false;
            string query = "select alf2, nacionalidade from " +
                "Nacionalidade where id_nacionalidade = " + id_nacionalidade;
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        alf2 = dr[0].ToString();
                        nacionalidade = dr[1].ToString();
                        flag = true;
                    }
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return flag;
        }

        public bool DeleteNacionalidade(string id_nacionalidade)
        {
            bool flag = true;

            string query = "Delete from Nacionalidade where id_nacionalidade = " + id_nacionalidade;

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            CloseConnection();
            return flag;
        }

        public bool InsertNacionalidade(string iso2, string nacionalidade)
        {
            bool flag = true;

            string query = "insert into Nacionalidade values (0, '" + iso2 + "', '" + nacionalidade + "')";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            CloseConnection();
            return flag;
        }

        public bool UpdateNacionalidade(string id_nacionalidade, string iso2, string nacionalidade)
        {
            bool flag = true;

            string query = "update Nacionalidade set alf2 = '" + iso2 + "', nacionalidade = '" + nacionalidade + "' " +
                 " where id_nacionalidade =  " + id_nacionalidade;
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                flag = false;
            }
            CloseConnection();
            return flag;

        }

        public void PreencherDataGridViewNacionalidade(ref DataGridView dgv)
        {
            string query = "select id_nacionalidade, alf2, nacionalidade " +
                "from Nacionalidade order by Nacionalidade";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    int idxLinha = 0;
                    while (dr.Read())
                    {
                        dgv.Rows.Add();
                        dgv.Rows[idxLinha].Cells[0].Value = dr[0].ToString();
                        dgv.Rows[idxLinha].Cells[1].Value = dr["alf2"].ToString();
                        dgv.Rows[idxLinha].Cells["nacionalidade"].Value = dr[2].ToString();
                        idxLinha++;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void PreencherDataGridViewFormandoFiltro(ref DataGridView dgv, 
            string id_nacionalidade, char genero, string nome)
        {
            string query = "select id_formando, nome, nacionalidade, sexo, iban " +
                "from formando F, Nacionalidade N where F.id_nacionalidade = N.id_nacionalidade ";

            if (id_nacionalidade.Length > 0)
            {
                query = query + "and F.id_nacionalidade = '" + id_nacionalidade + "' ";
            }

            if (genero != 'T' && genero != ' ')
            {
                query = query + "and sexo = '" + genero + "' ";
            }

            if (nome.Length > 0)
            {
                query = query + "and nome Like '%" + nome + "%' ";
            }


            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    int idxLinha = 0;
                    while (dr.Read())
                    {
                        if (dr["nome"].ToString() != "")
                        {
                            dgv.Rows.Add();
                            dgv.Rows[idxLinha].Cells[0].Value = dr[0].ToString();
                            dgv.Rows[idxLinha].Cells[1].Value = dr["nome"].ToString();
                            dgv.Rows[idxLinha].Cells["Iban"].Value = dr["iban"].ToString();
                            dgv.Rows[idxLinha].Cells["nacionalidade"].Value = dr[2].ToString();
                            dgv.Rows[idxLinha].Cells["genero"].Value = dr["sexo"].ToString().ToUpper();
                            idxLinha++;
                        }
                        
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool ValidateUser(string userName, string passWord, ref string id_user)
        {
            bool flag = false;

            try
            {
                string query = "select id_utilizador, nome_utilizador from utilizador " +
                    "where binary nome_utilizador = '" + userName + "' and palavra_passe = sha2('" +
                    passWord + "',0) and estado = 'A';";

                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        id_user = reader.GetString(0);
                        flag = true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
                //
            }

            return flag;
        }


    }
}
