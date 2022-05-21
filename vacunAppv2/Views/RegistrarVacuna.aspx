<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarVacuna.aspx.cs" Inherits="vacunAppv2.Views.RegistrarVacuna" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Assets/StyleVacuna.css" rel="stylesheet" />
    <link href="../Assets/bootstrap.min.css" rel="stylesheet" />
    
    <script src="../Assets/jquery.min.js"></script>
    <script src="../Assets/popper.js"></script>
    <script src="../Assets/bootstrap.min.js"></script>

    <link rel="shortcut icon" type="image/png" href="../Assets/imagenes/vacun33.png" />
    <title>Registrar Vacuna || VacunApp</title>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top" style="background-color: #639390;">
            <div class="container-fluid">
                <a class="navbar-brand" href="../Views/Inicio.html">
                    <img src="../Assets/imagenes/vacun33.png" width="90" height="50" class="d-inline-block align-top" alt="" />VacunApp</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarText">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/PerfilAdministrador.aspx">Perfil</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/RecepcionPQRS.aspx">Recepción PQRS</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/SolicitudesAdministrador.aspx">Verificación administradores</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" href="../Views/RegistrarVacuna.aspx">Registrar Vacunas</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/RegistroVacunas.aspx">Ver Vacunas</a>
                        </li>
                    </ul>
                    <span class="navbar-text">
                        <asp:LinkButton Text="SALIR" CssClass="nav-link botonsalir" ID="btnLogOut" OnClick="btnLogOut_Click" runat="server" />
                    </span>
                </div>
            </div>
        </nav>

        <div class="Vacunabox23">
            <h2 class="titulo">Registrar Nueva Vacuna</h2>
            <asp:Label Text="Farmaceutica:" CssClass="lbl" runat="server" />
            <asp:DropDownList ID="dropFarmaceuticas" CssClass="dropVacunas" AutoPostBack="true" runat="server"></asp:DropDownList>
            <asp:Label Text="Nombre:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtNombre" placeholder="Ingrese Nombre Vacuna" Required="true" SetFocusOnError="true" AutoComplete="off"/>
            <asp:Label Text="Lote:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtLote" placeholder="Ingrese Lote" Required="true" SetFocusOnError="true" AutoComplete="off"/>
            <asp:Label Text="Fecha de Fabricación:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtFechaFab" TextMode="Date" />
            <asp:Label Text="Fecha de Expiración:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtFechaVec" TextMode="Date" />
            <asp:Label Text="Tiempo Protección (Dias):" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtTiempo" placeholder="Ingrese Tiempo" TextMode="Number" min="1" Required="true" SetFocusOnError="true" />
            <asp:Label Text="Descripción:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtDesc" placeholder="Ingrese Descripción" Required="true" SetFocusOnError="true" AutoComplete="off"/>
            <asp:Label Text="Cantidad:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtCant" placeholder="Ingrese Cantidad" TextMode="Number" min="1" Required="true" SetFocusOnError="true" />
            <asp:Label Text="Número de Dosis:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtDosis" placeholder="Ingrese Número Dosis" TextMode="Number" min="1" Required="true" SetFocusOnError="true" />
            
            <asp:Button Text="Registrar" CssClass="btnSubmit" ID="btnGuardar" OnClick="btnGuardar_Click" runat="server" />
        </div>
    </form>
</body>
</html>
