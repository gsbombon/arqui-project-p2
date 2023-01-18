<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_reporteBancos.aspx.cs" Inherits="prj_architecture_p2.View.ReporteFacturacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Reporte Facturacion</title>
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
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1 class="label label-default mb-4">REPORTE FACTURACION </h1>
            <hr />
            <div class="row">
                <form id="form2" runat="server">
                    <h2 class="text-center my-5"> Saldo X Cuenta Bancaria </h2>
                    <div class="row" >
                        <div class="col-3 text-end">
                            <asp:Label runat="server" class="">FECHAS</asp:Label>
                        </div>
                        <div class="col-6">
                            <asp:DropDownList ID="cmb_date" runat="server" class="form-control"></asp:DropDownList>
                        </div>
                        <div class="col-3">
                            <asp:Button ID="btn_find" runat="server" Text="Registrar EC" OnClick="btn_findClick" class="btn btn-success" />
                        </div>
                    </div>   
                    <br />
                    <br />
                    <asp:GridView ID="grdReporte" runat="server" AutoGenerateColumns="false" CssClass="table table-striped thead-dark"
                        DataKeyNames="CUENTA_CB,VALOR_CT, FECHA_CT">
                        <Columns>
                            <asp:BoundField HeaderText="Cuenta" DataField="CUENTA_CB" />
                            <asp:BoundField HeaderText="Saldo" DataField="VALOR_CT" />
                            <asp:BoundField HeaderText="Fecha" DataField="FECHA_CT" />
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="txt_mensaje" runat="server"></asp:Label>
                </form>
            </div>
        </div>
    </form>
</body>
</html>
