using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prj_architecture_p2.DAO
{
    public class DAOLogin
    {
        // METHODS FOR LOGIN AND REGISTER NEW USERS
        public int loginIn(String user, String pass)
        {
            int i = 0;
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "SELECT * FROM usuarios WHERE usuario='" + user + "' AND pass='" + pass + "'";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader reader;
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    i++;
                }
                if (i > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public String singUp(String user, String pass)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "INSERT INTO usuarios(usuario,pass) VALUES ('" + user + "','" + pass + "')";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Usuario registrado correctamente !";
            }
            catch (Exception ex)
            {
                return "No se pudo registrar ! \n Error: " + ex.Message;
            }
        }
    }
}