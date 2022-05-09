using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web;
using Utilitarios;
using Logica;

namespace vacunAppv2.Views
{
    public partial class verSolicitudPQRS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["user"] != null && ((EPersona)Session["user"]).RolId == 1)
                {
                    Administrador admin = new Administrador();
                    ESolicitud datos = admin.verSolicitud(int.Parse(Request.QueryString.Get(0)));
                    txtId.Text = Convert.ToString(datos.Id);
                    txtIdU.Text = Convert.ToString(datos.UsuarioId);
                    Respuesta datosU = admin.buscarRegistro(Convert.ToInt32(txtIdU.Text));
                    txtTipo.Text = datos.TipoSolicitud;
                    txtFec.Text = (datos.FechaIngreso).ToShortDateString().ToString();
                    txtDesc.Text = datos.Mensaje;
                    txtRem.Text = datosU.User.Nombres + " " + datosU.User.Apellidos;
                    txtCorreo.Text = datosU.User.Correo;

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

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Administrador admin = new Administrador();
            ESolicitud solicitud = new ESolicitud();
            solicitud.TipoSolicitud = txtTipo.Text;
            solicitud.FechaIngreso = Convert.ToDateTime(txtFec.Text);
            solicitud.FechaLimite = Convert.ToDateTime(txtFec.Text);
            solicitud.Estado = "ENVIADO";
            solicitud.Id = Convert.ToInt32(txtId.Text);
            solicitud.Mensaje = txtDesc.Text;
            solicitud.UsuarioId = Convert.ToInt32(txtIdU.Text);
            solicitud.FechaRespuesta = Convert.ToDateTime(DateTime.Today.ToShortDateString());
            solicitud.Respuesta = txtRes.Text;
            string asunto = "Respuesta PQRS";
            string mensaje = txtRes.Text;
            string correo = txtCorreo.Text;
            string body = @"<!doctype html>";
            body += "<html>";
            body += "<head>";
            body += "<meta charset='utf-8'>";
            body += "<title>Correo</title>";
            body += "</head>";
            body += "<h3><strong>Respuesta a</strong> " + txtTipo.Text + " <strong>tramitado en la fecha</strong> " + txtFec.Text + "</h3>";
            body += "<p><strong>Cordial Saludo: </strong>" + txtRem.Text + "</p>";
            body += "<p>Con respecto a su solicitud...</p>";
            body += "</p>" + mensaje + "</p>";
            body += "<p><strong>Atentamente: </strong>" + ((EPersona)Session["user"]).Nombres + " " + ((EPersona)Session["user"]).Apellidos + "</p>";
            body += "<p><strong>Correo:</strong> " + ((EPersona)Session["user"]).Correo + "</p>";
            body += "</body>";
            body += "</body>";
            body += "</html>";

            Respuesta resp = admin.respuestaSolicitud(solicitud, correo,body,asunto);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);


        }
    }
}