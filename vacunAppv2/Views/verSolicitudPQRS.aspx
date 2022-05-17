<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verSolicitudPQRS.aspx.cs" Inherits="vacunAppv2.Views.verSolicitudPQRS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <link href="../Assets/StyleVerSolicitudPqrs.css" rel="stylesheet" />
    <link href="../Assets/bootstrap.min.css" rel="stylesheet" />
    
    <script src="../Assets/jquery.min.js"></script>
    <script src="../Assets/popper.js"></script>
    <script src="../Assets/bootstrap.min.js"></script>

    <link rel="shortcut icon" type="image/png" href="../Assets/imagenes/vacun33.png" />
    <title>Ver Solicitud || VacunApp</title>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top" style="background-color: #639390;">
            <div class="container-fluid">
                <a class="navbar-brand" href="../Views/Inicio.html"><img src="../Assets/imagenes/vacun33.png" width="90" height="50"  class="d-inline-block align-top" alt=""/>VacunApp</a>
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
        <div class="boxPqrs">

            <h2>SOLICITUD</h2>

            <asp:Label Text="ID:" CssClass="lblId" runat="server" />
            <asp:TextBox runat="server" CssClass="txtId" ID="txtId" Enabled="False" />
            <asp:Label Text="Tipo:" CssClass="lbltipo" runat="server" />
            <asp:TextBox runat="server" CssClass="txtTipo" ID="txtTipo" Enabled="False" />
            <asp:Label Text="ID Usuario:" CssClass="lblIdU" runat="server" />
            <asp:TextBox runat="server" CssClass="txtIdU" ID="txtIdU" Enabled="False" />
            <asp:Label Text="Remitente:" CssClass="lblRem" runat="server" />
            <asp:TextBox runat="server" ID="txtRem" CssClass="txtRem" Enabled="False" />
            <asp:Label Text="Correo Remitente:" CssClass="lblCorreo" runat="server" />
            <asp:TextBox runat="server" ID="txtCorreo" CssClass="txtCorreo" Enabled="False" />
            <asp:Label Text="Fecha Ingreso:" CssClass="lblFec" runat="server" />
            <asp:TextBox runat="server" CssClass="txtFec" ID="txtFec" Enabled="False" />
            <asp:Label Text="Descripción:" CssClass="lblDesc" runat="server" />
            <asp:TextBox runat="server" CssClass="txtDesc" ID="txtDesc" TextMode="MultiLine" MaxLength="150" Height="120px" BackColor="WindowFrame" Columns="50" Rows="10" Enable="False"/>

            <asp:Label Text="Contestar:" CssClass="lblRes" runat="server" />
            <asp:TextBox runat="server" CssClass="txtRes" ID="txtRes" TextMode="MultiLine" MaxLength="150" Height="120px" BackColor="WindowFrame" Columns="50" Rows="10" />


            <asp:Button Text="Enviar Respuesta" CssClass="btnEnviar" ID="btnEnviar" OnClick="btnEnviar_Click" runat="server" />

        </div>
    </form>
     
</body>
</html>
