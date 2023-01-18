using prj_architecture_p2.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prj_architecture_p2.View
{
    public partial class Facturacion : System.Web.UI.Page
    {
        //ArrayList rucs = new ArrayList();
        ArrayList namesClients = new ArrayList();
        ArrayList namesCitys = new ArrayList();
        ArrayList namesProducts = new ArrayList();
        

        public double valorTotalFact = 0;

        DAOFacturation cliente = new DAOFacturation();

        DataTable dtClients;
        DataTable dtCitys;
        DataTable dtProducts;
        DataTable dtHeadFact;
        protected void Page_Load(object sender, EventArgs e)
        {
            String hostName = string.Empty;
            hostName = Dns.GetHostName();
            txt_server.Text = "Hostname: " + hostName;
            if (!IsPostBack)
            {
                loadTableFacts();
                loadCmbNameClient();
                loadCmbNameCity();
                loadCmbProducts();
                loadPriceUnit(cmb_products.Text);
                loadPriceTotalProductSelect(cmb_products.Text);
            }
        }

        private void loadTableFacts()
        {
            try
            {
                grdFacts.DataSource = cliente.getListHeadFacts();
                grdFacts.DataBind();
            }
            catch (Exception ex) { txt_mensaje.Text = "Excepción: " + ex.Message; }

        }
        private void loadCmbNameClient()
        {
            try
            {
                this.dtClients = cliente.getListClients();
                int nRows = this.dtClients.Rows.Count;
                for (int i = 0; i < nRows; i++)
                {
                    namesClients.Add(this.dtClients.Rows[i]["NOMBRE_CLIENTE"].ToString());
                }
                cmb_client.DataSource = namesClients;
                cmb_client.DataBind();
            }
            catch (Exception ex) { txt_mensaje.Text = "Excepción: " + ex.Message; }

        }

        private void loadCmbNameCity()
        {
            try
            {
                this.dtCitys = cliente.getListCitys();
                int nRows = this.dtCitys.Rows.Count;
                for (int i = 0; i < nRows; i++)
                {
                    namesCitys.Add(this.dtCitys.Rows[i]["NOMBRE_CIUDAD"].ToString());
                }
                cmb_city.DataSource = namesCitys;
                cmb_city.DataBind();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Excepción: " + ex.Message;
            }

        }

        private void loadCmbProducts()
        {
            try
            {
                this.dtProducts = cliente.getListProducts();
                int nRows = this.dtProducts.Rows.Count;
                for (int i = 0; i < nRows; i++)
                {
                    namesProducts.Add(this.dtProducts.Rows[i]["NOMBRE_ARTICULO"].ToString());
                }
                cmb_products.DataSource = namesProducts;
                cmb_products.DataBind();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Excepción: " + ex.Message;
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            loadPriceUnit(cmb_products.Text);
            loadPriceTotalProductSelect(cmb_products.Text);
        }
        protected void btn_addClick(object sender, EventArgs e)
        {
            try
            {
                int idClient = cliente.getIdClientFromName(cmb_client.Text);
                int idCiudad = cliente.getIdCityFromName(cmb_city.Text);
                string valorStr = Convert.ToString(this.valorTotalFact);
                txt_mensaje.Text = cliente.insertNewHeadFact(idClient, idCiudad, txt_date_fact.Text, valorStr);
                loadTableFacts();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Excepción: " + ex.Message;
            }
        }

        protected void btn_updateClick(object sender, EventArgs e)
        {
            try
            {
                int id_fact = Convert.ToInt32(txt_id.Text);
                int idClient = cliente.getIdClientFromName(cmb_client.Text);
                int idCiudad = cliente.getIdCityFromName(cmb_city.Text);
                string valorStr = Convert.ToString(txt_priceTotalFact.Text);
                txt_mensaje.Text = cliente.updateHeadFact(id_fact, idClient, idCiudad, txt_date_fact.Text, valorStr);
                loadTableFacts();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Excepción: " + ex.Message;
            }
        }

        protected void btn_deleteClick(object sender, EventArgs e)
        {
            try
            {
                int id_fact = Convert.ToInt32(txt_id.Text);
                txt_mensaje.Text = cliente.deleteHeadFactu(id_fact);
                loadTableFacts();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Excepción: " + ex.Message;
            }
        }

        protected void btn_findClick(object sender, EventArgs e)
        {

            try
            {
                int id_fact = Convert.ToInt32(txt_id.Text);
                dtHeadFact = cliente.findFactFromId(id_fact);
                cmb_client.Text = dtHeadFact.Rows[0]["NOMBRE_CLIENTE"].ToString();
                cmb_city.Text = dtHeadFact.Rows[0]["NOMBRE_CIUDAD"].ToString();
                txt_priceTotalFact.Text = this.valorTotalFact.ToString();
                txt_date_fact.Text = dtHeadFact.Rows[0]["FECHA_CABECERA"].ToString();
                //CARGAR CARRITO DE COMPRAS
                grdProducts.DataSource = cliente.getDetailsProductsFromFact(id_fact);
                grdProducts.DataBind();
                loadPriceTotalFact(id_fact);
                loadTableFacts();
            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Excepción: " + ex.Message;
            }
        }

        protected void btn_addProductClick(object sender, EventArgs e)
        {
            try
            {
                int prod_id = cliente.getIdProductFromName(cmb_products.Text);
                int id_fact = Convert.ToInt32(txt_id.Text);
                int amount = Convert.ToInt32(txt_cantidad.Text);
                double precioUnit = cliente.getPriceProductFromName(cmb_products.Text);
                String precioTotal = Convert.ToString(precioUnit * amount);
                txt_smsProduct.Text = cliente.addProductToFact(prod_id, id_fact, amount, precioTotal);
                grdProducts.DataSource = cliente.getDetailsProductsFromFact(id_fact);
                grdProducts.DataBind();
                loadPriceTotalFact(id_fact);
            }
            catch (Exception ex)
            {
                txt_smsProduct.Text = "Excepción: " + ex.Message;
            }
        }

        public void loadPriceUnit(String prod_name)
        {
            try
            {
                txt_unitPrice.Text = Convert.ToString(cliente.getPriceProductFromName(prod_name));
            }
            catch (Exception ex)
            {
                txt_smsProduct.Text = "Excepción: " + ex.Message;
            }

        }

        public void loadPriceTotalProductSelect(String prod_name)
        {
            try
            {
                int amount = Convert.ToInt32(txt_cantidad.Text);
                double precioUnit = cliente.getPriceProductFromName(cmb_products.Text);
                String precioTotal = Convert.ToString(precioUnit * amount);
                txt_priceTotal.Text = precioTotal.ToString();
            }
            catch (Exception ex)
            {
                txt_smsProduct.Text = "Excepción: " + ex.Message;
            }

        }

        protected void btn_sendFactClick(object sender, EventArgs e)
        {
            int id_fact = Convert.ToInt32(txt_id.Text);
            txt_mensaje.Text = cliente.updatePriceTotalFact(id_fact, txt_priceTotalFact.Text);
            loadTableFacts();
        }

        protected void cmb_products_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadPriceUnit(cmb_products.Text);
                loadPriceTotalProductSelect(cmb_products.Text);
            }
            catch (Exception ex)
            {
                txt_smsProduct.Text = "Excepción: " + ex.Message;
            }

        }

        public void loadPriceTotalFact(int id_fact)
        {
            try
            {
                String priceTotalFact = Convert.ToString(cliente.getPriceTotalFact(id_fact));
                txt_priceTotalFact.Text = priceTotalFact.ToString();
            }
            catch (Exception ex)
            {
                txt_smsProduct.Text = "Excepción: " + ex.Message;
            }
        }

     
    }
}