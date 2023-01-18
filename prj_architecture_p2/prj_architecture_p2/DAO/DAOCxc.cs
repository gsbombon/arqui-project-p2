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
                DAOCxc fp = new DAOCxc();
              
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


        public DataTable getListFactura()
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT * FROM CABECERAFACTURA";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "CABECERAF";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }



        public DataTable findFactFromId(String fact_id)
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT cf.numero_cabecera,cli.NOMBRE_CLIENTE,ciu.NOMBRE_CIUDAD,cf.FECHA_CABECERA,cf.VALOR_CABECERA  " +
                                "FROM CABECERAFACTURA as cf, CLIENTE as cli, CIUDAD as ciu " +
                                   "WHERE cf.ID_CLIENTE=cli.ID_CLIENTE AND cf.CODIGO_CIUDAD=ciu.CODIGO_CIUDAD AND cf.NUMERO_CABECERA=" + fact_id;
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "CABECERA";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }

        public String addTransaccionCami(string id_detalle, string valor)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "INSERT INTO DETALLETRANSACCION (ID_TT , ID_DETALLEPAGO, VALOR_DT) " +
                    "VALUES(2,'" + valor + "', '" + valor + "')";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Pago agregado correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo agregar el producto ! ";
            }
        }
        public String addProductToFact(string detailpay_id, string fp_id, string cobrador_id, int cabecera_id, string price_total)
        {
            String val = "";
            String val2 = "";
            DateTime thisDay = DateTime.Today;
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                val2 = thisDay.ToString("d");
                myConnection.Open();
                String sql = "INSERT INTO DETALLEPAGO(ID_DETALLEPAGO, ID_FORMAPAGO, CEDULA_COBRADOR, NUMERO_CABECERA, FECHA_DETALLEPAGO, VALOR_DETALLEPAGO) " +
                    "VALUES('" + detailpay_id + "','" + fp_id + "','" + cobrador_id + "'," + cabecera_id + ",'" + val2 + "','" + price_total + "')";
                val = sql;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                addTransaccionCami(detailpay_id, price_total);
                return "Pago agregado correctamente !";
            }
            catch (Exception)
            {
                return val+ "No se pudo agregar el producto ! ";
            }
        }

        public DataTable getListDetailPago()
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT * FROM DETALLEPAGO";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "DETALLEPAGO";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }
        public string getIdFpFromName(String producto_name)
        {
            string id = "";
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "SELECT ID_FORMAPAGO FROM FORMAPAGO WHERE NOMBRE_FORMAPAGO='" + producto_name + "'";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                while (dr1.Read())
                {
                    id = Convert.ToString(dr1["ID_FORMAPAGO"]);
                }
                myConnection.Close();
                return id;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public DataTable getDetailsProductsFromFact(int fact_id)
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT dp.CEDULA_COBRADOR, fp.NOMBRE_FORMAPAGO, dp.FECHA_DETALLEPAGO, dp.VALOR_DETALLEPAGO FROM DETALLEPAGO as dp,FORMAPAGO as fp  WHERE fp.ID_FORMAPAGO = dp.ID_FORMAPAGO AND dp.NUMERO_CABECERA=" + fact_id;
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "PAGOS";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }

        public double getPriceTotalFact(int id_fact)
        {
            double priceTotal = 0;
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "SELECT SUM(CAST(VALOR_DETALLEPAGO as DECIMAL(9,0))) as Total_factura FROM DETALLEPAGO WHERE NUMERO_CABECERA=" + id_fact + " GROUP BY NUMERO_CABECERA";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                while (dr1.Read())
                {
                    priceTotal = Convert.ToDouble(dr1["Total_factura"]);
                }
                myConnection.Close();
                return priceTotal;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public DataTable getReportOne()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
                {

                    String sql = "SELECT cf.NUMERO_CABECERA, cf.VALOR_CABECERA ,SUM(CAST(VALOR_DETALLEPAGO as DECIMAL(9,0))) AS TOTAL, CAST(cf.VALOR_CABECERA as DECIMAL(9,0)) - SUM(CAST(VALOR_DETALLEPAGO as DECIMAL(9,0))) AS RESTA FROM CABECERAFACTURA cf, DETALLEPAGO dp WHERE  dp.NUMERO_CABECERA=cf.NUMERO_CABECERA GROUP BY NUMERO_CABECERA";

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