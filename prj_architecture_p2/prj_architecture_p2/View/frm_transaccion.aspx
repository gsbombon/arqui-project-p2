<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_transaccion.aspx.cs" Inherits="prj_architecture_p2.View.frm_transaccion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Transacciones</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.min.js" integrity="sha384-cuYeSxntonz0PPNlHhBs68uyIAVpIIOZZ5JqeqvYYIcEL727kskC66kF92t6Xl2V" crossorigin="anonymous"></script>
</head>
<body>
    <div id="menu">
        <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
            <div class="container-fluid">
                <a class="navbar-brand" href="frm_main.aspx">Architecture Software</a>
                <div class="collapse navbar-collapse" id="collapsibleNavbar">
                    <ul class="navbar-nav">
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown">Facturacion</a>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="frm_cliente.aspx">Cliente</a></li>
                                <li><a class="dropdown-item" href="frm_ciudad.aspx">Ciudad</a></li>
                                <li><a class="dropdown-item" href="frm_facturacion.aspx">Facturacion </a></li>
                                <li><a class="dropdown-item" href="frm_reporteFacturacion.aspx">Reporte </a></li>
                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown">Cuentas por Cobrar</a>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="frm_cobrador.aspx">Cobrador</a></li>
                                <li><a class="dropdown-item" href="frm_formapago.aspx">Forma de Pago</a></li>
                                <li><a class="dropdown-item" href="frm_cuentasXcobrar.aspx">Forma de Pago</a></li>
                                <li><a class="dropdown-item" href="frm_reporteCxc">Compleja </a></li>
                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown">Bancos</a>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="frm_tipoTransaccion.aspx">Tipo transacción</a></li>
                                <li><a class="dropdown-item" href="frm_cuentaBancaria.aspx">Cuenta bancaria</a></li>
                                <li><a class="dropdown-item" href="frm_transaccion.aspx">Transacción </a></li>
                                <li><a class="dropdown-item" href="frm_reporteBancos.aspx">Compleja </a></li>
                            </ul>
                        </li>
                    </ul>
                    <ul class="navbar-nav ms-auto py-4 py-lg-0">
                        <asp:Label ID="txt_server" runat="server" class="nav-link px-lg-3 py-3 py-lg-4"></asp:Label>
                    </ul>
                </div>
            </div>
        </nav>
    </div>
    
    
    <div class="container">
        <form id="form2" runat="server">
            <h1 class="label label-default mt-5">TRANSACCIÓN COMPLEJA </h1>
            <hr />
            <div class="row">
                <h2 class="label label-default mt-5">ESTADOS DE CUENTAS </h2>
                <hr />
                <div class="col">
                    <asp:Label runat="server" class=""># ESTADO DE CUENTA</asp:Label>
                        <asp:TextBox ID="txt_id_ct" runat="server" class="form-control"></asp:TextBox>
                        <br />
                        <asp:Label runat="server" class="">CUENTA</asp:Label>
                        <asp:DropDownList ID="cmb_cuenta" runat="server" class="form-control"></asp:DropDownList>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="FECHA" class="form-label"></asp:Label>
                        <asp:TextBox ID="txt_date_ct" runat="server" class="form-control" placeholder="dd/mm/yyyy"></asp:TextBox>
                        <br />
                        <asp:Label runat="server" class="">Descripción</asp:Label>
                        <asp:TextBox ID="txt_description_ct" runat="server" class="form-control"></asp:TextBox>
                        <br />
                        <div class="row" >
                            <div class="col">
                                <asp:Button ID="btn_add_ct" runat="server" Text="Registrar EC" OnClick="btn_addClick_ct" class="btn btn-success" />
                            </div>
                            <div class="col">
                                <asp:Button ID="btn_update_ct" runat="server" Text="Actualizar EC" OnClick="btn_updateClick_ct" class="btn btn-info" />
                            </div>
                            <div class="col">
                                <asp:Button ID="btn_delete_ct" runat="server" Text="Eliminar EC" OnClick="btn_deleteClick_ct" class="btn btn-danger" />
                            </div>
                            <div class="col">
                                <asp:Button ID="btn_find_ct" runat="server" Text="Buscar EC" OnClick="btn_findClick_ct" class="btn btn-primary" />
                            </div>
                        </div>
                        <br />
                        <br />
                        <asp:Label ID="txt_mensaje_ct" runat="server" CssClass="h4" ></asp:Label>
                </div>
                <div class="col">
                    <div class="row text-center">
                        <h2>ESTADOS DE CUENTA</h2>
                    </div>
                    <div class="row mt-3">
                        <asp:GridView ID="grdCuenta" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                            DataKeyNames="ID_CT,CUENTA_CB,FECHA_CT,DESCRIPCION_CT,VALOR_CT">
                            <Columns>
                                <asp:BoundField HeaderText="# ESTADO DE CUENTA" DataField="ID_CT" />
                                <asp:BoundField HeaderText="CUENTA BANCARIA" DataField="CUENTA_CB" />
                                <asp:BoundField HeaderText="FECHA" DataField="FECHA_CT" />
                                <asp:BoundField HeaderText="DESCRIPCIÓN" DataField="DESCRIPCION_CT" />
                                <asp:BoundField HeaderText="SALDO" DataField="VALOR_CT" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        
            <div class="row">
                <h2 class="label label-default mt-5">TRANSACCIONES </h2>
                <hr />
                <div class="col">
                    <asp:Label runat="server" class="">CODIGO DE TRANSACCION</asp:Label>
                        <asp:TextBox ID="txt_id_dt" runat="server" class="form-control"></asp:TextBox>
                        <br />
                        <asp:Label runat="server" class="">TIPO DE TRANSACCION</asp:Label>
                        <asp:DropDownList ID="cmb_transactionType" runat="server" class="form-control"></asp:DropDownList>
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="FECHA" class="form-label"></asp:Label>
                        <asp:TextBox ID="txt_date_dt" runat="server" class="form-control" placeholder="dd/mm/yyyy"></asp:TextBox>
                        <br />
                        <asp:Label runat="server" class="">VALOR</asp:Label>
                        <asp:TextBox ID="txt_valor_dt" runat="server" class="form-control"></asp:TextBox>
                        <br />
                        <div class="row" >
                            <div class="col">
                                <asp:Button ID="btn_add_dt" runat="server" Text="Registrar Transacción" OnClick="btn_addClick_dt" class="btn btn-success" />
                            </div>
                            <div class="col">
                                <asp:Button ID="btn_update_dt" runat="server" Text="Actualizar Transacción" OnClick="btn_updateClick_dt" class="btn btn-info" />
                            </div>
                            <div class="col">
                                <asp:Button ID="btn_delete_dt" runat="server" Text="Eliminar Transacción" OnClick="btn_deleteClick_dt" class="btn btn-danger" />
                            </div>
                            <div class="col">
                                <asp:Button ID="btn_find_dt" runat="server" Text="Buscar Transacción" OnClick="btn_findClick_dt" class="btn btn-primary" />
                            </div>
                        </div>
                        <br />
                        <br />
                        <asp:Label ID="txt_mensaje_dt" runat="server" CssClass="h4" ></asp:Label>
                </div>
                <div class="col">
                    <div class="row mt-3">
                        <asp:GridView ID="grdTransaccion" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                            DataKeyNames="ID_DT,NOMBRE_TT,FECHA_DT,VALOR_DT">
                            <Columns>
                                <asp:BoundField HeaderText="CODIGO DE TRANSACCIÓN" DataField="ID_DT" />
                                <asp:BoundField HeaderText="TIPO DE TRANSACCIÓN" DataField="NOMBRE_TT" />
                                <asp:BoundField HeaderText="FECHA" DataField="FECHA_DT" />
                                <asp:BoundField HeaderText="VALOR" DataField="VALOR_DT" />
                            </Columns>
                        </asp:GridView>
                        <asp:Label class="h4" ID="txt_saldo" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </form>
    </div>
    
</body>
</html>
