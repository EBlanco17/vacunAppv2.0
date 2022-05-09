<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="vacunAppv2.Views.Formulario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <link href="../Assets/StyleFormulario.css" rel="stylesheet" />
    <link href="../Assets/bootstrap.min.css" rel="stylesheet" />
    
    <script src="../Assets/jquery.min.js"></script>
    <script src="../Assets/popper.js"></script>
    <script src="../Assets/bootstrap.min.js"></script>

    <link rel="shortcut icon" type="image/png" href="../Assets/imagenes/logo1.png" />
    <title>Formulario|| VacunApp</title>
</head>
<body>
    <form id="form1" runat="server">
         <nav class="navbar navbar-expand-lg navbar-dark fixed-top" style="background-color:cornflowerblue;">
            <div class="container-fluid">
                <a class="navbar-brand" href="../Views/Inicio.html"><img src="../Assets/imagenes/Logo1.png" width="45" height="45" class="d-inline-block align-top" alt=""/>VacunApp</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarText">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link" aria-current="page" href="../Views/Perfil.aspx">Perfil</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/IngresarVacuna.aspx">Registrar Vacunas</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" aria-current="page" href="../Views/Esquema.aspx">Esquema</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" href="../Views/InstaurarPQRS.aspx">PQRS</a>
                        </li>
                    </ul>
                    <span class="navbar-text">
                        <asp:LinkButton Text="SALIR" CssClass="nav-link botonsalir" ID="btnLogOut" OnClick="btnLogOut_Click" runat="server" />
                    </span>
                </div>
            </div>

        </nav>
        <div class="formbox">
            <h2>Datos Básicos</h2>
            <asp:Label Text="Localidad:" CssClass="lbl" runat="server" />
            <asp:DropDownList  ID="dropLocal" CssClass="dropLoc"  AutoPostBack="true" OnSelectedIndexChanged="dropLocal_SelectedIndexChanged" runat="server">
            </asp:DropDownList><br />
            <asp:Label Text="Sector:" CssClass="lbl" runat="server" />
            <asp:DropDownList ID="dropBarrio" CssClass="dropBar" AutoPostBack="true" runat="server">
            </asp:DropDownList><br />
            <asp:Label Text="EPS:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtEps" placeholder="Ingrese EPS" Required="true" SetFocusOnError="true"/><br />
            <asp:Label Text="Dirección:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtDireccion" placeholder="Ingrese Direccion" Required="true" SetFocusOnError="true"/><br />

            <asp:Button Text="Guardar" CssClass="btnSubmit" ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" />

        </div>
    </form>
</body>
</html>
