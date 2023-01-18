using MySqlX.XDevAPI;
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
using System.Windows.Forms;

namespace prj_architecture_p2.View
{
    public partial class frm_cuentasXcobrar : System.Web.UI.Page
    {

        //ArrayList rucs = new ArrayList();
        ArrayList idFacturas = new ArrayList();
        ArrayList idCObra = new ArrayList();
        ArrayList idFP = new ArrayList();
        DataTable dtFactura;
        DataTable dtCobra;
        DataTable dtFP;
        DataTable dtiddetail;
        DataTable dtHeadFact;

        DAOCxc cobrador = new DAOCxc();

        public double valorTotalFact = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            String hostName = string.Empty;
            hostName = Dns.GetHostName();
            txt_server.Text = "Hostname: " + hostName;
            loadCmbNameClient();
           

        }

        private void loadCmbNameClient()
        {
            try
            {
                this.dtFactura = cobrador.getListFactura(); 
                int nRows = this.dtFactura.Rows.Count;
                for (int i = 0; i < nRows; i++)
                {
                    idFacturas.Add(this.dtFactura.Rows[i]["NUMERO_CABECERA"].ToString());
                }
                cmb_numeroFact.DataSource = idFacturas;
                cmb_numeroFact.DataBind();
            }
            catch (Exception ex) { txt_mensaje.Text = "Excepción: " + ex.Message; }

        }
        private void loadCmbNameFP()
        {
            try
            {
                this.dtFP = cobrador.getListFp();
                int nRows = this.dtFP.Rows.Count;
                for (int i = 0; i < nRows; i++)
                {
                    idFP.Add(this.dtFP.Rows[i]["NOMBRE_FORMAPAGO"].ToString());
                }
                cmb_formaPago.DataSource = idFP;
                cmb_formaPago.DataBind();
            }
            catch (Exception ex) { txt_mensaje.Text = "Excepción: " + ex.Message; }

        }
        private void loadCmbNameCObrador()
        {
            try
            {
                this.dtCobra = cobrador.getListCobrador();
                int nRows = this.dtCobra.Rows.Count;
                for (int i = 0; i < nRows; i++)
                {
                    idCObra.Add(this.dtCobra.Rows[i]["CEDULA_COBRADOR"].ToString());
                }
                cmb_cobrador.DataSource = idCObra;
                cmb_cobrador.DataBind();
            }
            catch (Exception ex) { txt_mensaje.Text = "Excepción: " + ex.Message; }

        }

        protected void btn_findClick(object sender, EventArgs e)
        {

            try
            {

                dtHeadFact = cobrador.findFactFromId(txt_id.Text);
                txt_Cliente.Text = dtHeadFact.Rows[0]["NOMBRE_CLIENTE"].ToString();
                txt_Ciudad.Text = dtHeadFact.Rows[0]["NOMBRE_CIUDAD"].ToString();
                txt_Total.Text = dtHeadFact.Rows[0]["VALOR_CABECERA"].ToString();
                txt_date_fact.Text = dtHeadFact.Rows[0]["FECHA_CABECERA"].ToString();
                //CARGAR CARRITO DE COMPRAS
                grdProducts.DataSource = cobrador.getDetailsProductsFromFact(Convert.ToInt32(txt_id.Text));
                grdProducts.DataBind();
                loadPriceTotalFact(Convert.ToInt32(txt_id.Text));
                //    loadTableFacts();
                txt_mensaje.Text = txt_Cliente.Text+ cmb_numeroFact.Text;
                loadCmbNameCObrador();
                loadCmbNameFP();

            }
            catch (Exception ex)
            {
                txt_mensaje.Text = "Excepción: " + ex.Message;
            }
        }

        protected void btn_addProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string id="0";
                int id_val = 0;
                this.dtiddetail = cobrador.getListDetailPago();
                int nRows = this.dtiddetail.Rows.Count;
                for (int i = 0; i < nRows; i++)
                {
                    id=this.dtiddetail.Rows[i]["ID_DETALLEPAGO"].ToString();
                }
                id_val = Convert.ToInt32(id)+1;
                id=Convert.ToString(id_val);
                string cobra = cmb_cobrador.Text;
                string formapay = cobrador.getIdFpFromName(cmb_formaPago.Text);
                int id_fact = Convert.ToInt32(txt_id.Text);
                string cantidad = txt_cantidad.Text;
                double sum = Convert.ToInt32(cantidad) + loadPriceTotalFact(id_fact);
                double val2 = Convert.ToInt32(txt_Total.Text); 
                if (sum > val2)
                {
                    txt_smsProduct.Text = sum+"Sobre pasa el valor de paga"+val2;
                }
                else
                {
                    txt_smsProduct.Text = cobrador.addProductToFact(id, formapay, cobra, id_fact, cantidad);

                    grdProducts.DataSource = cobrador.getDetailsProductsFromFact(Convert.ToInt32(txt_id.Text));
                    grdProducts.DataBind();
                    loadPriceTotalFact(id_fact);
                }
               
            }
            catch (Exception ex)
            {
                txt_smsProduct.Text = "Excepción: " + ex.Message;
            }
        }
        public double loadPriceTotalFact(int id_fact)
        {
            try
            {
                String priceTotalFact = Convert.ToString(cobrador.getPriceTotalFact(id_fact));
                txt_priceTotalFact.Text = priceTotalFact.ToString();
                return cobrador.getPriceTotalFact(id_fact);
            }
            catch (Exception ex)
            {

                txt_smsProduct.Text = "Excepción: " + ex.Message;
                return 0;
            }
        }

        protected void cmb_numeroFact_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_id.Text= cmb_numeroFact.Text;
        }
    }
}