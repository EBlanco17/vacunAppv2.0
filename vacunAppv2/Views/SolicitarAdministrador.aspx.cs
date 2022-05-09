using System;
using System.Web;
using System.Web.UI;
using Utilitarios;
using Logica;

namespace vacunAppv2.Views
{
    public partial class SolicitarAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || ((EPersona)Session["user"]).RolId == 1)
            {
                Response.Redirect("../Views/Login.aspx");
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            HttpContext.Current.Response.Redirect("../Views/Inicio.html");
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Today;
            ESolicitudAdministrador solAdmin = new ESolicitudAdministrador();

            solAdmin.UsuarioId = ((EPersona)Session["user"]).Id;
            solAdmin.FechaIngreso = fecha;
            solAdmin.Mensaje = txtReport.Text;
            Respuesta resp = new Usuario().solicitarAdmin(solAdmin);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);

        }
    }
}