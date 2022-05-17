<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Esquema.aspx.cs" Inherits="vacunAppv2.Views.Esquema" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Assets/StyleEsquema.css" rel="stylesheet" />
   <link href="../Assets/bootstrap.min.css" rel="stylesheet" />
    
    <script src="../Assets/jquery.min.js"></script>
    <script src="../Assets/popper.js"></script>
    <script src="../Assets/bootstrap.min.js"></script>

    <link rel="shortcut icon" type="image/png" href="../Assets/imagenes/vacun33.png" />
    <title>Esquema || VacunApp</title>
</head>
<body>
    <form id="form1" runat="server">
         <nav class="navbar navbar-expand-lg navbar-dark fixed-top" style="background-color: #639390;">
            <div class="container-fluid">
                <a class="navbar-brand" href="../Views/Inicio.html"><img src="../Assets/imagenes/vacun33.png" width="90" height="50" class="d-inline-block align-top" alt=""/>VacunApp</a>
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
                            <a class="nav-link active" aria-current="page" href="../Views/Esquema.aspx">Esquema</a>
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
        <div class="divtabla">
            <asp:GridView ID="tabla" runat="server" AutoGenerateColumns="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt" GridLines="None" AllowPaging="True" PageSize="6" PagerSettings-Mode="NumericFirstLast"
                OnPageIndexChanging="tabla_PageIndexChanging">
                <Columns>
                     <asp:TemplateField HeaderText="Serial No">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server"
                                Text='<%# (tabla.PageSize * tabla.PageIndex) + Container.DisplayIndex + 1 %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="fechaAplicacion" HeaderText="FECHA" DataFormatString="{0:d}"/>
                    <asp:BoundField DataField="lugarAplicacion" HeaderText="LUGAR APLICACION" />
                    <asp:BoundField DataField="farmaceutica" HeaderText="FARMACEUTICA" />
                    <asp:BoundField DataField="vacuna" HeaderText="VACUNA" />
                    <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCION"/>
                    <asp:BoundField DataField="noDosis" HeaderText="DOSIS APLICADA"/>
                    <asp:BoundField DataField="noDosisTotales" HeaderText="DOSIS TOTALES"/>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
