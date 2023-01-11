<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_register.aspx.cs" Inherits="prj_architecture_p2.View.frm_register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Regitrar Usuario</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet"></link>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <section class="vh-100" style="background-color: #9A616D;">
            <div class="container py-5 h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col col-xl-10">
                        <div class="card" style="border-radius: 1rem;">
                            <div class="row g-0">
                                <div class="col-md-6 col-lg-5 d-none d-md-block">
                                    <img src="https://cdn.pixabay.com/photo/2017/08/06/13/59/store-2592761_960_720.jpg"
                                         alt="login form" class="img-fluid" style="border-radius: 1rem 0 0 1rem;" />
                                </div>
                                <div class="col-md-6 col-lg-7 d-flex align-items-center">
                                    <div class="card-body p-4 p-lg-5 text-black">
                                        <form id="form1" runat="server">
                                            <div class="d-flex align-items-center mb-3 pb-1">
                                                <i class="fas fa-cubes fa-2x me-3" style="color: #ff6219;"></i>
                                                <span class="h1 fw-bold mb-0">Store</span>
                                            </div>
                                            <h5 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px;">Registrar Usuario </h5>

                                            <div class="form-outline mb-4">
                                                <asp:TextBox ID="txt_user" runat="server" class="form-control form-control-lg"></asp:TextBox>
                                                <label class="form-label"> Nuevo Usuario</label>
                                            </div>
                                            <div class="form-outline mb-4">
                                                <asp:TextBox ID="txt_pass" TextMode="Password" runat="server" class="form-control form-control-lg"></asp:TextBox>
                                                <label class="form-label"> Nueva Contraseña</label>
                                            </div>
                                            <div class="pt-1 mb-4">
                                                <asp:Button ID="btn_register" runat="server" Text="Registrarme" OnClick="btn_registerClick" class="btn btn-dark btn-lg btn-block text-white" />
                                            </div>
                                            
                                            <p class="mb-3 pb-lg-2" style="color: #393f81;">Ya tengo una cuenta |
                                                <a href="frm_login.aspx" style="color: #393f81;">Regresar</a>
                                            </p>
                                            <div class="row">
                                                <asp:Label ID="txt_mensaje" runat="server" Text="" ></asp:Label>
                                            </div>
                                            <a href="#!" class="small text-muted">Terms of use.</a>
                                            <a href="#!" class="small text-muted">Privacy policy</a>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
</body>
</html>
