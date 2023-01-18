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
    public partial class frm_transaccion : System.Web.UI.Page
    {
        //ArrayList rucs = new ArrayList();
        ArrayList namesCuentas = new ArrayList();
        ArrayList namesTransactionTypes = new ArrayList();
        //ArrayList namesProducts = new ArrayList();


        public double valorTotal = 0;

        DAOBancos cliente = new DAOBancos();

        DataTable dtCuentas;
        DataTable dtTransactionTypes;

        protected void Page_Load(object sender, EventArgs e)
        {
            String hostName = string.Empty;
            hostName = Dns.GetHostName();
            txt_server.Text = "Hostname: " + hostName;
            if (!IsPostBack)
            {
                loadTableFacts();
                loadCmbCuentas();
                //loadTableDetail();
                loadCmbTT();
                /*loadCmbNameClient();
                loadCmbNameCity();
                loadCmbProducts();
                loadPriceUnit(cmb_products.Text);
                loadPriceTotalProductSelect(cmb_products.Text);*/
            }
        }

        public void loadPriceUnit(int id_ct)
        {
            try
            {
                txt_saldo.Text = Convert.ToString(cliente.getTotalTransactions(id_ct));
                txt_mensaje_ct.Text = cliente.updateTotalTransactions(txt_saldo.Text, Convert.ToInt32(txt_id_ct.Text));
            }
            catch (Exception ex)
            {
                txt_saldo.Text = "Excepción: " + ex.Message;
            }

        }

        private void loadTableFacts()
        {
            try
            {
                grdCuenta.DataSource = cliente.getListTransactionHeader();
                grdCuenta.DataBind();
            }
            catch (Exception ex) { txt_mensaje_ct.Text = "Excepción tabla fact : " + ex.Message; }

        }

        private void loadCmbCuentas()
        {
            try
            {
                this.dtCuentas = cliente.getListBanckAccounts();
                int nRows = this.dtCuentas.Rows.Count;
                for (int i = 0; i < nRows; i++)
                {
                    namesCuentas.Add(this.dtCuentas.Rows[i]["CUENTA_CB"].ToString());
                }
                cmb_cuenta.DataSource = namesCuentas;
                cmb_cuenta.DataBind();
                //txt_mensaje_ct.Text = "HOLA" + this.dtCuentas.Rows[0]["NOMBRE_CB"].ToString();
            }
            catch (Exception ex)
            {
                txt_mensaje_ct.Text = "Excepción cmb cuentas: " + ex.Message;
            }
        }

        public void cleanFormHeader()
        {
            txt_id_ct.Text = "";
            txt_date_ct.Text = "";
            txt_description_ct.Text = "";
        }

        protected void btn_addClick_ct(object sender, EventArgs e)
        {
            try
            {
                int idCuenta = cliente.getIdBanckAccountFromName(cmb_cuenta.Text);
                string valorStr = Convert.ToString(this.valorTotal);
                txt_mensaje_ct.Text = cliente.insertNewTransactionHeader(idCuenta, txt_date_ct.Text, txt_description_ct.Text, valorStr);
                this.cleanFormHeader();
                loadTableFacts();
            }
            catch (Exception ex)
            {
                txt_mensaje_ct.Text = "Excepción: " + ex.Message;
            }
        }

        protected void btn_updateClick_ct(object sender, EventArgs e)
        {
            try
            {
                int idCuenta = cliente.getIdBanckAccountFromName(cmb_cuenta.Text);
                txt_mensaje_ct.Text = cliente.updateTransactionHeader(Convert.ToInt32(txt_id_ct.Text), idCuenta, txt_date_ct.Text, txt_description_ct.Text);
                this.cleanFormHeader();
                loadTableFacts();
            }
            catch (Exception ex)
            {
                txt_mensaje_ct.Text = "Error: " + ex.Message;
            }
        }

        protected void btn_deleteClick_ct(object sender, EventArgs e)
        {
            try
            {
                txt_mensaje_ct.Text = cliente.deleteTransactionHeader(Convert.ToInt32(txt_id_ct.Text));
                this.cleanFormHeader();
                loadTableFacts();
            }
            catch (Exception ex)
            {
                txt_mensaje_ct.Text = "Error: " + ex.Message;
            }
        }

        protected void btn_findClick_ct(object sender, EventArgs e)
        {
            try
            {
                grdTransaccion.DataSource = cliente.getListTransactionDetailForHeader(Convert.ToInt32(txt_id_ct.Text));
                grdTransaccion.DataBind();
                grdCuenta.DataSource = cliente.findTransactionFromId(Convert.ToInt32(txt_id_ct.Text));
                grdCuenta.DataBind();
                DataTable dt = cliente.findTransactionFromId(Convert.ToInt32(txt_id_ct.Text));
                txt_id_ct.Text = dt.Rows[0]["ID_CT"].ToString();
                cmb_cuenta.Text = dt.Rows[0]["CUENTA_CB"].ToString();
                txt_date_ct.Text = dt.Rows[0]["FECHA_CT"].ToString();
                txt_description_ct.Text = dt.Rows[0]["DESCRIPCION_CT"].ToString();
                txt_mensaje_ct.Text = "Elemento encontrado ! ";
                loadPriceUnit(Convert.ToInt32(txt_id_ct.Text));
            }
            catch (Exception ex)
            {
                txt_mensaje_ct.Text = "Error: " + ex.Message;
            }
        }

        private void loadCmbTT()
        {
            try
            {
                this.dtTransactionTypes = cliente.getListTransactionTypes();
                int nRows = this.dtTransactionTypes.Rows.Count;
                for (int i = 0; i < nRows; i++)
                {
                    namesTransactionTypes.Add(this.dtTransactionTypes.Rows[i]["NOMBRE_TT"].ToString());
                }
                cmb_transactionType.DataSource = namesTransactionTypes;
                cmb_transactionType.DataBind();
            }
            catch (Exception ex)
            {
                txt_mensaje_ct.Text = "Excepción combo TT: " + ex.Message;
            }
        }

        public void cleanFormDetail()
        {
            txt_id_dt.Text = "";
            txt_date_dt.Text = "";
            txt_valor_dt.Text = "";
        }

        private void loadTableDetail()
        {
            try
            {
                grdTransaccion.DataSource = cliente.getListTransactionDetailForHeader(Convert.ToInt32(txt_id_ct.Text));
                grdTransaccion.DataBind();
            }
            catch (Exception ex) { txt_mensaje_dt.Text = "Excepción tabla detalle: " + ex.Message; }

        }

        protected void btn_addClick_dt(object sender, EventArgs e)
        {
            try
            {
                int idTT = cliente.getIdTansactionTypeFromName(cmb_transactionType.Text);
                string signo = cliente.getSignoTansactionTypeFromId(idTT);
                txt_mensaje_dt.Text = cliente.insertNewTransactionDetail(Convert.ToInt32(txt_id_ct.Text), idTT, txt_date_dt.Text, signo+txt_valor_dt.Text);
                loadPriceUnit(Convert.ToInt32(txt_id_ct.Text));
                this.cleanFormDetail();
                loadTableDetail();
            }
            catch (Exception ex)
            {
                txt_mensaje_dt.Text = "Excepción: " + ex.Message;
            }
        }

        protected void btn_updateClick_dt(object sender, EventArgs e)
        {
            try
            {
                int idTT = cliente.getIdTansactionTypeFromName(cmb_transactionType.Text);
                txt_mensaje_dt.Text = cliente.updateTransactionDetail(Convert.ToInt32(txt_id_ct.Text), Convert.ToInt32(txt_id_dt.Text), idTT, txt_date_dt.Text, txt_valor_dt.Text);
                loadPriceUnit(Convert.ToInt32(txt_id_ct.Text));
                this.cleanFormDetail();
                loadTableDetail();
                loadTableFacts();
            }
            catch (Exception ex)
            {
                txt_mensaje_dt.Text = "Error: " + ex.Message;
            }
        }

        protected void btn_deleteClick_dt(object sender, EventArgs e)
        {
            try
            {
                txt_mensaje_dt.Text = cliente.deleteTransactionDetail(Convert.ToInt32(txt_id_dt.Text));
                this.cleanFormDetail();
                loadTableDetail();
            }
            catch (Exception ex)
            {
                txt_mensaje_dt.Text = "Error: " + ex.Message;
            }
        }

        protected void btn_findClick_dt(object sender, EventArgs e)
        {
            try
            {
                grdTransaccion.DataSource = cliente.findTransactionDetailFromId(Convert.ToInt32(txt_id_dt.Text));
                grdTransaccion.DataBind();
                DataTable dt = cliente.findTransactionDetailFromId(Convert.ToInt32(txt_id_dt.Text));
                txt_id_ct.Text = dt.Rows[0]["ID_CT"].ToString();
                txt_id_dt.Text = dt.Rows[0]["ID_DT"].ToString();
                cmb_transactionType.Text = dt.Rows[0]["NOMBRE_TT"].ToString();
                txt_date_dt.Text = dt.Rows[0]["FECHA_DT"].ToString();
                txt_valor_dt.Text = dt.Rows[0]["VALOR_DT"].ToString();
                txt_mensaje_dt.Text = "Elemento encontrado ! ";
            }
            catch (Exception ex)
            {
                txt_mensaje_dt.Text = "Error: " + ex.Message;
            }
        }


    }
}