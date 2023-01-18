using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace prj_architecture_p2.DAO
{
    public class DAOBancos
    {

        // METHODS FOR TABLE "TIPO TRANSACCION"

        public String insertTransactionType(String name, String sign)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "INSERT INTO TIPOTRANSACCION(NOMBRE_TT, SIGNO_TT) VALUES ('" + name + "', '" + sign + "')";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Tipo de Transacción registrada correctamente !";
            }
            catch (Exception ex)
            {
                return "No se pudo registrar ! Error: " + ex.Message;
            }
        }

        public DataTable getListTransactionTypes()
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT * FROM TIPOTRANSACCION";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "TIPOTRANSACCION";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }

        public String deleteTransacionType(int id)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "DELETE FROM TIPOTRANSACCION WHERE ID_TT=" + id;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Tipo de Transacción eliminada correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo eliminar ! ";
            }
        }

        public String updateTransactionType(int id, String name, String sign)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "UPDATE TIPOTRANSACCION SET NOMBRE_TT = '" + name + "', SIGNO_TT = '" + sign + "' WHERE ID_TT=" + id;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Tipo de Transacción actualizada correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo actualizar ! ";
            }
        }


        public DataTable findTransactionType(int id)
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT * FROM TIPOTRANSACCION WHERE ID_TT=" + id;
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "TIPOTRANSACCION";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }

        // METHODS FOR TABLE "CUENTA BANCARIA"
        public String insertBanckAccount(String account, String name, String description)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "INSERT INTO CUENTABANCARIA(CUENTA_CB,NOMBRE_CB,DESCRIPCION_CB) VALUES ('" + account + "','" + name + "','" + description + "')";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Cuenta registrado correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo registrar ! ";
            }
        }

        public DataTable getListBanckAccounts()
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT * FROM CUENTABANCARIA";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "CUENTABANCARIA";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }

        public String deleteBanckAccount(int id)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "DELETE FROM CUENTABANCARIA WHERE ID_CB=" + id;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Cuenta eliminada correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo eliminar ! ";
            }
        }

        public String updateBackAccount(int id, String account, String name, String description)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "UPDATE CUENTABANCARIA SET CUENTA_CB = '" + account + "',NOMBRE_CB = '" + name + "',DESCRIPCION_CB = '" + description + "' WHERE ID_CB = " + id ;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Cuenta actualizada correctamente !";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar ! "+ex.Message;
            }
        }

        public DataTable findBanckAccount(int id)
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT * FROM CUENTABANCARIA WHERE ID_CB='" + id + "'";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "CUENTABANCARIA";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }

        // WEB METHODS FOR TABLE "TRANSACCION"
        public DataTable getListTransactionHeader()
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123;old guids=true"))
            {
                String sql = "SELECT ct.ID_CT, cb.CUENTA_CB, cb.NOMBRE_CB, ct.FECHA_CT, ct.DESCRIPCION_CT, ct.VALOR_CT " +
                                "FROM CABECERATRANSACCION as ct, CUENTABANCARIA as cb " +
                                    "WHERE ct.ID_CB = cb.ID_CB ORDER BY ct.ID_CT ASC";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "DETAILS-HEAD";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }

        public String insertNewTransactionHeader(int id_cb, String date, String description, String valor)
        {
            String sql = "";
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                sql = "INSERT INTO CABECERATRANSACCION(ID_CB, ID_DETALLEPAGO, FECHA_CT, DESCRIPCION_CT, VALOR_CT)VALUES(" + id_cb + ", '','" + date + "','" + description + "', '" + valor + "')";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Transaccion creada correctamente !";
            }
            catch (Exception ex)
            {
                return "No se pudo registrar el Estado de Cuenta ! Error: " + ex.Message + "sql: " + sql;
            }
        }

        public String deleteTransactionHeader(int id)
        {
            if (deleteTransactionDetailHEADER(id))
            {
                MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
                try
                {
                    myConnection.Open();
                    String sql = "DELETE FROM CABECERATRANSACCION WHERE ID_CT=" + id;
                    MySqlCommand command = new MySqlCommand(sql, myConnection);
                    MySqlDataReader dr1 = command.ExecuteReader();
                    myConnection.Close();
                    return "Transaccion eliminada correctamente !";
                }
                catch (Exception ex)
                {
                    return "No se pudo eliminar el Estado de Cuenta ! - " + ex.Message;
                }
            }
            else
            {
                return "Error al eliminar el Estado de Cuenta por las Transacciones ! ";
            }

        }

        public String updateTransactionHeader(int id_ct, int id_cb, String date, String description)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "UPDATE CABECERATRANSACCION SET ID_CB = " + id_cb + ",FECHA_CT = '" + date + "',DESCRIPCION_CT = '" + description + "' WHERE ID_CT=" + id_ct;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Estado de Cuenta actualizada correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo actualizar ! ";
            }
        }

        public bool deleteTransactionDetailHEADER(int id)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "DELETE FROM DETALLETRANSACCION WHERE ID_DT=" + id;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public String deleteTransactionDetail(int id)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "DELETE FROM DETALLETRANSACCION WHERE ID_DT=" + id;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Transaccion eliminada correctamente !";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el Estado de Cuenta ! - " + ex.Message;
            }
        }

        public DataTable findTransactionFromId(int id_ct)
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123;old guids=true"))
            {
                String sql = "SELECT ct.ID_CT, cb.CUENTA_CB, ct.FECHA_CT, ct.DESCRIPCION_CT, ct.VALOR_CT " +
                                "FROM CABECERATRANSACCION as ct, CUENTABANCARIA as cb " +
                                   "WHERE ct.ID_CB=cb.ID_CB AND ct.ID_CT=" + id_ct;
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "DETAILS-HEAD";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }

        public DataTable getListTransactionDetailForHeader(int id_ct)
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123;old guids=true"))
            {
                String sql = "SELECT dt.ID_DT, dt.ID_TT, tt.NOMBRE_TT, dt.FECHA_DT, dt.VALOR_DT " +
                                "FROM DETALLETRANSACCION as dt, TIPOTRANSACCION as tt " +
                                    "WHERE dt.ID_TT = tt.ID_TT AND dt.ID_CT =" + id_ct + " ORDER BY dt.ID_DT ASC";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "DETAILS-HEAD";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }

        public String insertNewTransactionDetail(int id_ct, int id_tt, String date, String valor)
        {
            String sql = "";
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                sql = "INSERT INTO DETALLETRANSACCION(ID_CT, ID_TT, FECHA_DT, VALOR_DT) VALUES(" + id_ct + "," + id_tt + ",'" + date + "','" + valor + "')";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Transaccion creada correctamente !";
            }
            catch (Exception ex)
            {
                return "No se pudo registrar el Estado de Cuenta ! Error: " + ex.Message + "sql: " + sql;
            }
        }

        public String updateTransactionDetail(int id_ct, int id_dt, int id_tt, String date, String valor)
        {
            String sql = "UPDATE DETALLETRANSACCION SET ID_CT = " + id_ct + ",ID_TT = " + id_tt + ",FECHA_DT = '" + date + "',VALOR_DT = '" + valor + "' WHERE ID_DT=" + id_dt;
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Transaccion actualizada correctamente !";
            }
            catch (Exception)
            {
                return sql+" No se pudo actualizar ! ";
            }
        }

        public DataTable findTransactionDetailFromId(int id_dt)
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123;old guids=true"))
            {
                String sql = "SELECT dt.ID_DT, dt.ID_CT, dt.ID_TT, tt.NOMBRE_TT, dt.FECHA_DT, dt.VALOR_DT " +
                                "FROM DETALLETRANSACCION as dt, TIPOTRANSACCION as tt " +
                                   "WHERE dt.ID_TT = tt.ID_TT AND dt.ID_DT=" + id_dt;
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "DETAILS-HEAD";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }


        // METHODS FOR EXTRACT IDS TO TABLES ESPECIFICS
        public int getIdBanckAccountFromName(String name)
        {
            int id = 0;
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "SELECT ID_CB FROM CUENTABANCARIA WHERE CUENTA_CB='" + name + "'";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                while (dr1.Read())
                {
                    id = Convert.ToInt32(dr1["ID_CB"]);
                }
                myConnection.Close();
                return id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int getIdTansactionTypeFromName(String type)
        {
            int id = 0;
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "SELECT ID_TT FROM TIPOTRANSACCION WHERE NOMBRE_TT='" + type + "'";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                while (dr1.Read())
                {
                    id = Convert.ToInt32(dr1["ID_TT"]);
                }
                myConnection.Close();
                return id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string getSignoTansactionTypeFromId(int id)
        {
            string signo = "";
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "SELECT SIGNO_TT FROM TIPOTRANSACCION WHERE ID_TT=" + id;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                while (dr1.Read())
                {
                    signo = Convert.ToString(dr1["SIGNO_TT"]);
                }
                myConnection.Close();
                return signo;
            }
            catch (Exception)
            {
                return signo;
            }
        }

        public double getTotalTransactions(int id_ct)
        {
            double priceTotal = 0;
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "SELECT SUM(CAST(VALOR_DT as DECIMAL(9,0))) as Total FROM DETALLETRANSACCION WHERE ID_CT=" + id_ct + " GROUP BY ID_CT";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                while (dr1.Read())
                {
                    priceTotal = Convert.ToDouble(dr1["Total"]);
                }
                myConnection.Close();
                return priceTotal;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public String updateTotalTransactions(string valor, int id_ct)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                //double total = 0;
                myConnection.Open();
                String sql2 = "UPDATE CABECERATRANSACCION SET VALOR_CT = '" + valor + "' WHERE ID_CT =" + id_ct;
                MySqlCommand command2 = new MySqlCommand(sql2, myConnection);
                MySqlDataReader dr2 = command2.ExecuteReader();
                myConnection.Close();
                return "valor cambiado";
            }
            catch (Exception)
            {
                return "No se pudo registart el valor ! ";
            }
        }

        public DataTable getReportOne()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
                {
                    String sql = "SELECT c2.CUENTA_CB, c.VALOR_CT, c.FECHA_CT FROM CABECERATRANSACCION c, CUENTABANCARIA c2 WHERE c.ID_CB = c2.ID_CB";
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                dt.TableName = "REPORT-ONE";
                                sda.Fill(dt);
                                return dt;
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public DataTable filterDate()
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT DISTINCT c.FECHA_CT FROM CABECERATRANSACCION c";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "FILTER";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }

        }

        public DataTable findDateReportOne(string date)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
                {
                    String sql = "SELECT c2.CUENTA_CB, c.VALOR_CT, c.FECHA_CT FROM CABECERATRANSACCION c, CUENTABANCARIA c2 WHERE c.ID_CB = c2.ID_CB AND c.FECHA_CT = " + date;
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                dt.TableName = "REPORT-ONE";
                                sda.Fill(dt);
                                return dt;
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}