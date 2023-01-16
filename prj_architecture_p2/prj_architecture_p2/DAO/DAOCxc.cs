using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace prj_architecture_p2.DAO
{
    public class DAOCxc
    {
        // METHODS FOR TABLE "COBRADOR"
        public String insertCobrador(String ruc, String name, String address)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "INSERT INTO COBRADOR(CEDULA_COBRADOR,NOMBRE_COBRADOR,DIRECCION_COBRADOR) VALUES ('" + ruc + "','" + name + "','" + address + "')";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "COBRADOR registrado correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo registrar ! ";
            }
        }


        public DataTable getListCobrador()
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT * FROM COBRADOR";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "COBRADOR";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }

        public String deleteCobrador(String id)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "DELETE FROM COBRADOR WHERE CEDULA_COBRADOR=" + id;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Cobrador eliminada correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo eliminar ! ";
            }
        }

        public String updateCobrador(String id,  String new_name, String new_address)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "UPDATE COBRADOR SET NOMBRE_COBRADOR = '" + new_name + "',DIRECCION_COBRADOR = '" + new_address + "' WHERE CEDULA_COBRADOR=" + id;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Cobrador actualizado correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo actualizar ! ";
            }
        }

        public DataTable findCobrador(string ruc)
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT * FROM COBRADOR WHERE CEDULA_COBRADOR='" + ruc + "'";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "COBRADOR";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }


        // METHODS FOR TABLE "FORMA DE PAGO"
        public String insertFp(String id, String name)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "INSERT INTO FORMAPAGO(ID_FORMAPAGO,NOMBRE_FORMAPAGO) VALUES ('" + id + "','" + name + "')";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Forma Pago registrado correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo registrar ! ";
            }
        }


        public DataTable getListFp()
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT * FROM FORMAPAGO";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "FORMAPAGO";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }

        public String deleteFp(String id)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "DELETE FROM FORMAPAGO WHERE ID_FORMAPAGO=" + id;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Forma Pago eliminada correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo eliminar ! ";
            }
        }

        public String updateFp(String id, String new_name)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "UPDATE FORMAPAGO SET NOMBRE_FORMAPAGO = '" + new_name   + "' WHERE ID_FORMAPAGO=" + id;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Forma Pago actualizado correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo actualizar ! ";
            }
        }

        public DataTable findFp(string ruc)
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT * FROM FORMAPAGO WHERE ID_FORMAPAGO='" + ruc + "'";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "FORMAPAGO";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }
    }
}