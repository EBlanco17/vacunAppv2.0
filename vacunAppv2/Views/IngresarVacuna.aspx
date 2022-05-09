<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresarVacuna.aspx.cs" Inherits="vacunAppv2.Views.IngresarVacuna" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <link href="../Assets/StyleVacuna.css" rel="stylesheet" />
    <link href="../Assets/bootstrap.min.css" rel="stylesheet" />
    
    <script src="../Assets/jquery.min.js"></script>
    <script src="../Assets/popper.js"></script>
    <script src="../Assets/bootstrap.min.js"></script>

    <link rel="shortcut icon" type="image/png" href="../Assets/imagenes/logo1.png" />
    <title>Ingresar Vacuna || VacunApp</title>
</head>
<body>

    <form runat="server">
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
                            <a class="nav-link active" href="../Views/IngresarVacuna.aspx">Registrar Vacunas</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" aria-current="page" href="../Views/Esquema.aspx">Esquema</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../Views/InstaurarPQRS.aspx">PQRS</a>
                        </li>
                        
                        
                    </ul>
                    <span class="navbar-text">
                        <asp:LinkButton Text="SALIR" CssClass="nav-link botonsalir" ID="btnLogOut" OnClick="btnLogOut_Click" runat="server" />
                    </span>
                    
                </div>
            </div>

        </nav>
        <div class="Vacunabox">
            <h2>Ingresar Vacuna</h2>
            <asp:Label Text="Seleccione Farmaceutica:" CssClass="lbl" runat="server"/>
            <asp:DropDownList ID="dropFarmaceutica" CssClass="dropVacunas" AutoPostBack="true" OnSelectedIndexChanged="dropFarmaceutica_SelectedIndexChanged" runat="server"></asp:DropDownList>
            <asp:Label Text="Seleccione Vacuna:" CssClass="lbl" runat="server"/>
            <asp:DropDownList ID="dropVacunas" CssClass="dropVacunas" AutoPostBack="true" runat="server"></asp:DropDownList>
            <asp:Label Text="Seleccione Vacuna:" CssClass="lbl" runat="server"/>
            <asp:Label Text="Fecha de Aplicación:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtFechaApl" TextMode="Date" />
            <asp:Label Text="Número de Dosis:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtDosis" placeholder="Ingrese Numero Dosis" TextMode="Number" min="1" Required="true" SetFocusOnError="true" />
            <asp:Label Text="Lugar Aplicación:" CssClass="lbl" runat="server" />
            <asp:TextBox runat="server" CssClass="txt" ID="txtLugar" placeholder="Ingrese Lugar" Required="true" SetFocusOnError="true" />
            
            <asp:Button Text="Registrar" CssClass="btnSubmit" ID="btnGuardar" OnClick="btnGuardar_Click" runat="server" />
        
        </div>
    </form>
</body>
</html>
