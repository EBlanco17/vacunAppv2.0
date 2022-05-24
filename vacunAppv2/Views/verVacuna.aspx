<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verVacuna.aspx.cs" Inherits="vacunAppv2.Views.verVacuna" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <link href="../Assets/bootstrap.min.css" rel="stylesheet" />
    
    <script src="../Assets/jquery.min.js"></script>
    <script src="../Assets/popper.js"></script>
    <link href="../Assets/StyleVerVacuna.css" rel="stylesheet" />
    <script src="../Assets/bootstrap.min.js"></script>

    <link rel="shortcut icon" type="image/png" href="../Assets/imagenes/vacun33.png" />
    <title>Ver Vacuna || VacunApp</title>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top" style="background-color: #639390;">
            <div class="container-fluid">
                <a class="navbar-brand" href="../Views/Inicio.html"><img src="../Assets/imagenes/vacun33.png" width="90" height="50" class="d-inline-block align-top" alt=""/>VacunApp</a>
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
                            <a class="nav-link" href="../Views/RegistrarVacuna.aspx">Registrar Vacunas</a>
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
        <div class="boxVacuna">

            <h2 class="h2vacun">Editar Vacuna</h2>

            <asp:Label Text="ID:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtId" Enabled="False" />
            <asp:Label Text="Farmaceutica:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtFarm" Enabled="False" />
            <asp:Label Text="Nombre:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtNombre" AutoCompleteType="None" />
            <asp:Label Text="Lote:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" ID="txtLote" CssClass="txt" Enabled="False" />
            <asp:Label Text="Fecha Fabricación:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" ID="txtFecFab" CssClass="txt" Enabled="False" />
            <asp:Label Text="Fecha Expiración:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtFecExp" Enabled="False" />
            <asp:Label Text="Tiempo Protección (días):" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtTiem" Enabled="False" />
            <asp:Label Text="Descripción:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txtDesc" ID="txtDesc" TextMode="MultiLine" MaxLength="150" Height="120px" width="100%" BackColor="WindowFrame" Columns="50" Rows="10" color="black" font-size="20px" font-family="Montserrat, sans-serif"/>
            <asp:Label Text="Número de Dosis:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtDosis" />
            <asp:Label Text="Cantidad (und):" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtCant" Enabled="False"/>
            <asp:Label Text="Nueva Cantidad (und):" CssClass="lbl" runat="server"/>
            <asp:TextBox runat="server" TextMode="Number" CssClass="txt" ID="txtNuevas"/>

            <asp:Button Text="Actualizar Vacuna" CssClass="btnSubmit" ID="btnSubmit" OnClick="btnSubmit_Click" OnClientClick="return confirm('¿Deseas Continuar con el Cambio?')" runat="server" />

        </div>
    </form>
</body>
</html>
