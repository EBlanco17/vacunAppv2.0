using System;
using System.Web;
using System.Web.UI;
using Utilitarios;
using Logica;

namespace vacunAppv2.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            if (Session["user"] != null) //hay sesion abierta
            {
                int rol = ((EPersona)Session["user"]).RolId;

                if (rol == 1)
                {
                    HttpContext.Current.Response.Redirect("../Views/PerfilAdministrador.aspx");
                }
                else
                {
                    HttpContext.Current.Response.Redirect("../Views/Perfil.aspx");
                }

            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            EPersona ePersona = new EPersona();
            Respuesta resp;
            if (dropTipoUser.Text == "ADMINISTRADOR")
            {
                Administrador admin = new Administrador();
                ePersona.Correo = txtCorreo.Text.ToUpper();
                ePersona.Clave = admin.encriptarPassword(txtClave.Text);
                ePersona.RolId = 1;
                resp = admin.login(ePersona);
            }
            else
            {
                Usuario usuario = new Usuario();
                ePersona.Correo = txtCorreo.Text.ToUpper();
                ePersona.Clave = usuario.encriptarPassword(txtClave.Text);
                ePersona.RolId = 2;
                resp = usuario.login(ePersona);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);
            Session["user"] = resp.User;
        }
    }
}