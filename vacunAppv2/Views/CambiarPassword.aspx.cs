using System;
using System.Web;
using Utilitarios;
using Logica;
using System.Web.UI;

namespace vacunAppv2.Views
{
    public partial class CambiarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                HttpContext.Current.Response.Redirect("../Views/Login.aspx");
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            HttpContext.Current.Response.Redirect("../Views/Inicio.html");
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            if (txtNueva.Text.Length > 6)
            {

                if ((persona.encriptarPassword(txtActual.Text) == ((EPersona)Session["user"]).Clave) && (txtNueva.Text == txtCnueva.Text))
                {
                    EPersona user = new EPersona();
                    user.Id = ((EPersona)Session["user"]).Id;
                    user.Clave = persona.encriptarPassword(txtNueva.Text);
                    Respuesta resp = persona.actualizarPassword(user);
                    Session["user"] = resp.User;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);
                }
                else
                {
                    string strMsg = "Datos Incorrectos";
                    HttpContext.Current.Response.Write("<script>alert('" + strMsg + "')</script>");
                }
            }
            else
            {
                string strMsg = "La nueva contraseña debe tener una longitud de mínimo 6 caracteres";
                HttpContext.Current.Response.Write("<script>alert('" + strMsg + "')</script>");
            }
        }
    }
}