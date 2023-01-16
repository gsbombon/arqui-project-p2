<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_transaccion.aspx.cs" Inherits="prj_architecture_p2.View.Facturacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Ciudad</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.min.js" integrity="sha384-cuYeSxntonz0PPNlHhBs68uyIAVpIIOZZ5JqeqvYYIcEL727kskC66kF92t6Xl2V" crossorigin="anonymous"></script>
</head>
<body>
    <div id="menu">
        <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Architecture Software</a>
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
                                <li><a class="dropdown-item" href="#">Compleja </a></li>
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
        <h1 class="label label-default mt-5">TRANSACCIÓN COMPLEJA </h1>
        <hr />
        <div class="row">
            <h2 class="label label-default mt-5">CUENTAS </h2>
            <hr />
            <div class="col">
                <form id="form2" runat="server">
                    <asp:Label runat="server" class=""># ESTADO DE CUENTA</asp:Label>
                        <asp:TextBox ID="id_ct" runat="server" class="form-control"></asp:TextBox>
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
                                <asp:Button ID="Button1" runat="server" Text="Registrar EC" OnClick="btn_addClick" class="btn btn-success" />
                            </div>
                            <div class="col">
                                <asp:Button ID="Button2" runat="server" Text="Actualizar EC" OnClick="btn_updateClick" class="btn btn-info" />
                            </div>
                            <div class="col">
                                <asp:Button ID="Button3" runat="server" Text="Eliminar EC" OnClick="btn_deleteClick" class="btn btn-danger" />
                            </div>
                            <div class="col">
                                <asp:Button ID="Button4" runat="server" Text="Buscar EC" OnClick="btn_findClick" class="btn btn-primary" />
                            </div>
                        </div>
                        <br />
                        <br />
                        <asp:Label ID="Label3" runat="server" CssClass="h4" ></asp:Label>
                </form>
            </div>
            <div class="col">
                <div class="row text-center">
                    <h2>ESTADOS DE CUENTA</h2>
                </div>
                <div class="row mt-3">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                        DataKeyNames="ID_CT,ID_CB,FECHA_CB,DESCRIPCION_CT,VALOR_CT">
                        <Columns>
                            <asp:BoundField HeaderText="# ESTADO DE CUENTA" DataField="ID_CT" />
                            <asp:BoundField HeaderText="CUENTA BANCARIA" DataField="ID_CB" />
                            <asp:BoundField HeaderText="FECHA" DataField="FECHA_CB" />
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
                <form id="form3" runat="server">
                    <asp:Label runat="server" class="">CODIGO DE TRANSACCION</asp:Label>
                        <asp:TextBox ID="id_dt" runat="server" class="form-control"></asp:TextBox>
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
                                <asp:Button ID="Button5" runat="server" Text="Registrar Transacción" OnClick="btn_addClick" class="btn btn-success" />
                            </div>
                            <div class="col">
                                <asp:Button ID="Button6" runat="server" Text="Actualizar Transacción" OnClick="btn_updateClick" class="btn btn-info" />
                            </div>
                            <div class="col">
                                <asp:Button ID="Button7" runat="server" Text="Eliminar Transacción" OnClick="btn_deleteClick" class="btn btn-danger" />
                            </div>
                            <div class="col">
                                <asp:Button ID="Button8" runat="server" Text="Buscar Transacción" OnClick="btn_findClick" class="btn btn-primary" />
                            </div>
                        </div>
                        <br />
                        <br />
                        <asp:Label ID="Label5" runat="server" CssClass="h4" ></asp:Label>
                </form>
            </div>
            <div class="col">
                <div class="row mt-3">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                        DataKeyNames="ID_DT,ID_TT,FECHA_DT,VALOR_DT">
                        <Columns>
                            <asp:BoundField HeaderText="CODIGO DE TRANSACCIÓN" DataField="ID_DT" />
                            <asp:BoundField HeaderText="TIPO DE TRANSACCIÓN" DataField="ID_TT" />
                            <asp:BoundField HeaderText="FECHA" DataField="FECHA_DT" />
                            <asp:BoundField HeaderText="VALOR" DataField="VALOR_DT" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    
</body>
</html>
