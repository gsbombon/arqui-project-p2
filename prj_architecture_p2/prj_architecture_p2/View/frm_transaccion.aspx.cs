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
        DataTable dtProducts;
        DataTable dtHeadFact;

        protected void btn_addClick(object sender, EventArgs e)
        {

        }

        protected void btn_updateClick(object sender, EventArgs e)
        {

        }

        protected void btn_deleteClick(object sender, EventArgs e)
        {

        }

        protected void btn_findClick(object sender, EventArgs e)
        {

        }
        /*
protected void Page_Load(object sender, EventArgs e)
{
// comentario random
String hostName = string.Empty;
hostName = Dns.GetHostName();
txt_server.Text = "Hostname: " + hostName;
if (!IsPostBack)
{
loadTableTransactionsHeader();
loadCmbNameCuenta();
loadCmbNameTipoTransaccion();
loadPriceUnit(cmb_cuenta.Text);
loadPriceTotalProductSelect(cmb_cuenta.Text);
}
}

private void loadTableTransactionsHeader()
{
try
{
grdFacts.DataSource = cliente.getListTransactionHeader();
grdFacts.DataBind();
}
catch (Exception ex) { txt_mensaje.Text = "Excepción: " + ex.Message; }

}
private void loadCmbNameCuenta()
{
try
{
this.dtCuentas = cliente.getListBanckAccounts();
int nRows = this.dtCuentas.Rows.Count;
for (int i = 0; i < nRows; i++)
{
namesCuentas.Add(this.dtCuentas.Rows[i]["NOMBRE_CB"].ToString());
}
cmb_cuenta.DataSource = namesCuentas;
cmb_cuenta.DataBind();
}
catch (Exception ex) { txt_mensaje.Text = "Excepción: " + ex.Message; }

}

private void loadCmbNameTipoTransaccion()
{
try
{
this.dtTransactionTypes = cliente.getListTransactionTypes();
int nRows = this.dtTransactionTypes.Rows.Count;
for (int i = 0; i < nRows; i++)
{
namesTransactionTypes.Add(this.dtTransactionTypes.Rows[i]["NOMBRE_TT"].ToString());
}
cmb_transactions_type.DataSource = namesTransactionTypes;
cmb_transactions_type.DataBind();
}
catch (Exception ex)
{
txt_mensaje.Text = "Excepción: " + ex.Message;
}

}

protected void OnSelectedIndexChanged(object sender, EventArgs e)
{
loadPriceUnit(cmb_PROD.Text);
loadPriceTotalProductSelect(cmb_PROD.Text);
}
protected void btn_addClick(object sender, EventArgs e)
{
try
{
int idCuenta = cliente.getIdBanckAccountFromName(cmb_cuenta.Text);
string valorStr = Convert.ToString(this.valorTotal);
txt_mensaje.Text = cliente.insertNewTransactionHeader(idCuenta, txt_date_ct.Text, txt_description.Text, valorStr);
loadTableTransactionsHeader();
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
int id_ct = Convert.ToInt32(txt_id.Text);
int idCuenta = cliente.getIdBanckAccountFromName(cmb_cuenta.Text);
string valorStr = Convert.ToString(txt_priceTotal.Text);
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
int prod_id = cliente.getIdProductFromName(cmb_cuenta.Text);
int id_fact = Convert.ToInt32(txt_id.Text);
int amount = Convert.ToInt32(txt_cantidad.Text);
double precioUnit = cliente.getPriceProductFromName(cmb_cuenta.Text);
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
double precioUnit = cliente.getPriceProductFromName(cmb_cuenta.Text);
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

protected void cmb_cuentas_SelectedIndexChanged(object sender, EventArgs e)
{
try
{
loadPriceUnit(cmb_cuenta.Text);
loadPriceTotalProductSelect(cmb_cuenta.Text);
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
}*/


    }
}