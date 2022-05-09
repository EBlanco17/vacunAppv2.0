using System;
using System.Web;
using System.Web.UI;
using Utilitarios;
using Logica;

namespace vacunAppv2.Views
{
    public partial class verUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null && ((EPersona)Session["user"]).RolId == 1)
                {
                    Administrador admin = new Administrador();
                    ESolicitudAdministrador datosS = admin.verSolicitudAdmin(int.Parse(Request.QueryString.Get(0)));
                    Respuesta datos = admin.buscarRegistro(datosS.UsuarioId);
                    txtRem.Text = datos.User.Nombres + " " + datos.User.Apellidos;
                    txtCorreo.Text = datos.User.Correo;
                    txtFechaNac.Text = datos.User.FechaNacimiento.ToShortDateString();
                    txtGen.Text = datos.User.Genero;
                    txtDoc.Text = datos.User.Documento;
                    txtFec.Text = datosS.FechaIngreso.ToShortDateString();
                    txtMsg.Text = datosS.Mensaje;
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Views/Login.aspx");

                }
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            HttpContext.Current.Response.Redirect("../Views/Inicio.html");
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            EPersona user = new EPersona();
            Administrador admin = new Administrador();
            string asunto = "Solicitud administrador";
            string body = "";
            string correo = txtCorreo.Text;
            body += "<html>";
            body += "<head>";
            body += "<meta charset='utf-8'>";
            body += "<title>correo</title>";
            body += "</head>";
            body += "<h1>Ha sido aceptado como administrador</h1>";
            body += "<h3>Ahora tendrá acceso a funcionalidades extra</h3>";
            body += "<p>" + txtRes.Text + "</p>";
            body += "<body>";
            body += "<body>";
            body += "</body>";
            body += "</html>";
            user.Id = Convert.ToInt32(int.Parse(Request.QueryString.Get(0)));
            Respuesta resp = admin.cambiarRol(user, correo, body, asunto);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);
            
            

            
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            Administrador admin = new Administrador();
            int id = Convert.ToInt32(int.Parse(Request.QueryString.Get(0)));
            
            
            string asunto = "Solicitud administrador";
            string body = "";
            string correo = txtCorreo.Text;
            body += "<html>";
            body += "<head>";
            body += "<meta charset='utf-8'>";
            body += "<title>correo</title>";
            body += "</head>";
            body += "<h1>Ha sido rechazado como administrador</h1>";
            body += "<h3>En este momento no puede ser administrador, intentelo más adelante</h3>";
            body += "<p>" + txtRes.Text + "</p>";
            body += "<body>";
            body += "<body>";
            body += "</body>";
            body += "</html>";

            Respuesta resp = admin.rechazarSolicitud(id, correo,body,asunto);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);

        }
    }
}