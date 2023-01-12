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
    public class DAOFacturation
    {

        // METHODS FOR TABLE "CIUDAD"
        
        public String insertCity(String nom_ciudad)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "INSERT INTO CIUDAD(NOMBRE_CIUDAD) VALUES ('" + nom_ciudad + "')";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Ciudad registrada correctamente !";
            }
            catch (Exception ex)
            {
                return "No se pudo registrar ! Error: " + ex.Message;
            }
        }

        public DataTable getListCitys()
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT * FROM CIUDAD";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "CIUDAD";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }

        public String deleteCity(int id)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "DELETE FROM CIUDAD WHERE codigo_ciudad=" + id;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Ciudad eliminada correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo eliminar ! ";
            }
        }

        public String updateCity(int id, String new_name)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "UPDATE CIUDAD SET NOMBRE_CIUDAD = '" + new_name + "' WHERE CODIGO_CIUDAD=" + id;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Ciudad actualizada correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo actualizar ! ";
            }
        }


        public DataTable findCity(int id)
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT * FROM CIUDAD WHERE codigo_ciudad=" + id;
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "CIUDAD";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }

        // METHODS FOR TABLE "CLIENTE"
        public String insertClient(String ruc, String name, String address)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "INSERT INTO CLIENTE(RUC_CLIENTE,NOMBRE_CLIENTE,DIRECCION_CLIENTE) VALUES ('" + ruc + "','" + name + "','" + address + "')";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Cliente registrado correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo registrar ! ";
            }
        }


        public DataTable getListClients()
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT * FROM CLIENTE";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "CLIENTE";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }

        public String deleteClient(int id)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "DELETE FROM CLIENTE WHERE id_cliente=" + id;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Cliente eliminada correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo eliminar ! ";
            }
        }

        public String updateClient(int id, String new_ruc, String new_name, String new_address)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "UPDATE CLIENTE SET RUC_CLIENTE = '" + new_ruc + "',NOMBRE_CLIENTE = '" + new_name + "',DIRECCION_CLIENTE = '" + new_address + "' WHERE id_cliente=" + id;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Cliente actualizado correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo actualizar ! ";
            }
        }

        public DataTable findClient(string ruc)
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT * FROM CLIENTE WHERE RUC_CLIENTE='" + ruc + "'";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "CLIENTE";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }

        // WEB METHODS FOR TABLE "FACTURACION"
        public String insertNewHeadFact(int client_id, int city_id, String date, String valorTotal)
        {
            String sql = "";
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                sql = "INSERT INTO CABECERAFACTURA(ID_CLIENTE,codigo_ciudad,FECHA_CABECERA,VALOR_CABECERA)VALUES(" + client_id + "," + city_id + ",'" + date + "','" + valorTotal + "')";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Factura creada correctamente !";
            }
            catch (Exception ex)
            {
                return "No se pudo registrar factura ! Error: " + ex.Message + "sql: " + sql;
            }
        }

        public String deleteHeadFactu(int id)
        {
            if (deleteDetailFactu(id))
            {
                MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
                try
                {
                    myConnection.Open();
                    String sql = "DELETE FROM CABECERAFACTURA WHERE NUMERO_CABECERA=" + id;
                    MySqlCommand command = new MySqlCommand(sql, myConnection);
                    MySqlDataReader dr1 = command.ExecuteReader();
                    myConnection.Close();
                    return "Factura eliminada correctamente !";
                }
                catch (Exception ex)
                {
                    return "No se pudo eliminar Factura ! - "+ex.Message;
                }
            }
            else
            {
                return "Error al eliminar factura por los productos ! ";
            }

        }

        public bool deleteDetailFactu(int id)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "DELETE FROM DETALLEFACTURA WHERE NUMERO_CABECERA=" + id;
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

        public String updateHeadFact(int idFact, int client_id, int city_id, String date, String valorTotal)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "UPDATE CABECERAFACTURA SET ID_CLIENTE = " + client_id + ",CODIGO_CIUDAD = " + city_id + ",FECHA_CABECERA = '" + date + "',VALOR_CABECERA = '" + valorTotal + "' WHERE NUMERO_CABECERA=" + idFact;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Factura actualizada correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo actualizar ! ";
            }
        }

        public DataTable findFactFromId(int fact_id)
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


        // Get data from Productos
        public DataTable getListProducts()
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT * FROM ARTICULO";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "ARTICULOS";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }

        public String addProductToFact(int product_id, int cabecera_id, int amount, string price_total)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "INSERT INTO DETALLEFACTURA(ID_ARTICULO,NUMERO_CABECERA,CANTIDAD_DETFAC,PRECIO_DETFAC) " +
                    "VALUES(" + product_id + "," + cabecera_id + "," + amount + ",'" + price_total + "')";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Producto agregado correctamente !";
            }
            catch (Exception)
            {
                return "No se pudo agregar el producto ! ";
            }
        }

        public DataTable getProductsFromFact(int fact_id)
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT * FROM DETALLEFACTURA WHERE NUMERO_CABECERA=" + fact_id;
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "ARTICULOS";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }

        public DataTable getDetailsProductsFromFact(int fact_id)
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT a.NOMBRE_ARTICULO,df.CANTIDAD_DETFAC,df.PRECIO_DETFAC FROM DETALLEFACTURA as df,ARTICULO as a WHERE df.ID_ARTICULO=a.ID_ARTICULO AND df.NUMERO_CABECERA=" + fact_id;
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "ARTICULOS";
                            sda.Fill(dt);
                            return dt;
                        }
                    }

                }
            }
        }
        // METHODS FOR EXTRACT IDS TO TABLES ESPECIFICS
        public int getIdClientFromName(String client_name)
        {
            int id = 0;
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "SELECT ID_CLIENTE FROM CLIENTE WHERE NOMBRE_CLIENTE='" + client_name + "'";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                while (dr1.Read())
                {
                    id = Convert.ToInt32(dr1["ID_CLIENTE"]);
                }
                myConnection.Close();
                return id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int getIdCityFromName(String city_name)
        {
            int id = 0;
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "SELECT CODIGO_CIUDAD FROM CIUDAD WHERE NOMBRE_CIUDAD='" + city_name + "'";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                while (dr1.Read())
                {
                    id = Convert.ToInt32(dr1["CODIGO_CIUDAD"]);
                }
                myConnection.Close();
                return id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int getIdProductFromName(String producto_name)
        {
            int id = 0;
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "SELECT ID_ARTICULO FROM ARTICULO WHERE NOMBRE_ARTICULO='" + producto_name + "'";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                while (dr1.Read())
                {
                    id = Convert.ToInt32(dr1["ID_ARTICULO"]);
                }
                myConnection.Close();
                return id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public double getPriceProductFromName(String producto_name)
        {
            double precio = 0;
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "SELECT PRECIO_ARTICULO FROM ARTICULO WHERE NOMBRE_ARTICULO='" + producto_name + "'";
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                while (dr1.Read())
                {
                    precio = Convert.ToDouble(dr1["PRECIO_ARTICULO"]);
                }
                myConnection.Close();
                return precio;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public double getPriceTotalFact(int id_fact)
        {
            double priceTotal = 0;
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "SELECT SUM(CAST(PRECIO_DETFAC as DECIMAL(9,0))) as Total_factura FROM DETALLEFACTURA WHERE NUMERO_CABECERA=" + id_fact + " GROUP BY NUMERO_CABECERA";
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

        public DataTable getListHeadFacts()
        {
            using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
            {
                String sql = "SELECT cf.NUMERO_CABECERA,cli.ID_CLIENTE,cli.NOMBRE_CLIENTE,ciu.NOMBRE_CIUDAD,cf.FECHA_CABECERA,cf.VALOR_CABECERA " +
                                "FROM CABECERAFACTURA as cf, CLIENTE as cli, CIUDAD as ciu " +
                                    "WHERE cf.ID_CLIENTE=cli.ID_CLIENTE AND cf.CODIGO_CIUDAD=ciu.CODIGO_CIUDAD ORDER BY cf.NUMERO_CABECERA";
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

        public String updatePriceTotalFact(int id_fact, String price_total)
        {
            MySqlConnection myConnection = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123");
            try
            {
                myConnection.Open();
                String sql = "UPDATE CABECERAFACTURA SET VALOR_CABECERA = '" + price_total + "' WHERE NUMERO_CABECERA=" + id_fact;
                MySqlCommand command = new MySqlCommand(sql, myConnection);
                MySqlDataReader dr1 = command.ExecuteReader();
                myConnection.Close();
                return "Compra Facturada !";
            }
            catch (Exception)
            {
                return "No se pudo realizar la compra ! ";
            }
        }

        public DataTable getReportOne()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection("server=database-2-arqui-prod.ckwn9gqw1b2k.us-east-2.rds.amazonaws.com;user=admin;database=ProjectArquiDB;port=3306;password=admin123"))
                {
                    String sql = "SELECT ciu.NOMBRE_CIUDAD , SUM(CAST(VALOR_CABECERA as DECIMAL(9,0))) AS Total_Ciudad FROM CABECERAFACTURA cf, CIUDAD ciu WHERE ciu.codigo_CIUDAD=cf.CODIGO_CIUDAD GROUP BY ciu.NOMBRE_CIUDAD";
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