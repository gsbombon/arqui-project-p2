<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_formapago.aspx.cs" Inherits="prj_architecture_p2.View.frm_formapago" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Forma de Pago</title>
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
                                <li><a class="dropdown-item" href="#">Tipo transacción</a></li>
                                <li><a class="dropdown-item" href="#">Cuenta bancaria</a></li>
                                <li><a class="dropdown-item" href="#">Compleja </a></li>
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
        <div class="container">
            <h1 class="label label-default mt-5">FORMA PAGO</h1>
            <hr />
            <br />
            <div class="row">
                <div class="col-5">
                    <asp:Label runat="server" class="">ID</asp:Label>
                    <asp:TextBox ID="txt_id" runat="server" class="form-control" ></asp:TextBox>
                    <br />
                    <asp:Label runat="server">NOMBRE</asp:Label>
                    <asp:TextBox ID="txt_name" runat="server" class="form-control"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="btn_add" runat="server" Text="Registrar"  class="btn btn-success" OnClick="btn_add_Click"  />
                    &nbsp;
                    <asp:Button ID="btn_update" runat="server" Text="Actualizar"  class="btn btn-info" OnClick="btn_update_Click"  />
                    &nbsp;
                    <asp:Button ID="btn_delete" runat="server" Text="Eliminar"  class="btn btn-danger" OnClick="btn_delete_Click"  />
                    &nbsp;
                    <asp:Button ID="btn_find" runat="server" Text="Buscar"  class="btn btn-primary" OnClick="btn_find_Click"  />
                    &nbsp;
                    <br />
                    <br />
                    <asp:Label ID="txt_mensaje" runat="server">Esperando...</asp:Label>
                </div>
                <div class="col-7">
                    <h3>Lista de Forma de Pagos</h3>
                    <asp:GridView ID="grdFps" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                        DataKeyNames="ID_FORMAPAGO,NOMBRE_FORMAPAGO">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID_FORMAPAGO" />
                            <asp:BoundField HeaderText="Nombre" DataField="NOMBRE_FORMAPAGO" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
