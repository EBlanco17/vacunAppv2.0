using System;
using System.Web;
using Utilitarios;
using Logica;
using System.Web.UI;


namespace vacunAppv2.Views
{
    public partial class InstaurarPQRS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || ((EPersona)Session["user"]).RolId == 1)
            {
                HttpContext.Current.Response.Redirect("../Views/Login.aspx");
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            HttpContext.Current.Response.Redirect("../Views/Login.aspx");
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Today;
            if (txtReport.Text.Length < 50)
            {
                HttpContext.Current.Response.Write("<script>alert('Registre una mejor descripcion')</script>");
            }
            else
            {
                ESolicitud solicitud = new ESolicitud();
                solicitud.TipoSolicitud = dropTipo.Text;
                solicitud.UsuarioId = ((EPersona)Session["user"]).Id;
                solicitud.Mensaje = txtReport.Text;
                solicitud.FechaIngreso = fecha;
                solicitud.FechaLimite = fecha.AddDays(15);
                solicitud.Estado = "SIN RESPONDER";
                Respuesta resp = new Usuario().insertarSolicitud(solicitud);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);

            }
        }
    }
}