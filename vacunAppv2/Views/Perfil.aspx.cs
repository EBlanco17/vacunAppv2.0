using System;
using System.Web;
using System.Web.UI;
using Utilitarios;
using Logica;

namespace vacunAppv2.Views
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null && ((EPersona)Session["user"]).RolId == 2)
                {
                    Usuario usuario = new Usuario();
                    txtId.Text = "ID: " + (((EPersona)Session["user"]).Id).ToString() + ". Cuenta Estándar";
                    txtNombre.Text = ((EPersona)Session["user"]).Nombres;
                    txtApellido.Text = ((EPersona)Session["user"]).Apellidos;
                    txtNac.Text = (((EPersona)Session["user"]).FechaNacimiento).ToShortDateString().ToString();
                    txtEdad.Text = usuario.CalcularEdad(((EPersona)Session["user"]).FechaNacimiento).ToString();
                    txtGen.Text = ((EPersona)Session["user"]).Genero;
                    txtemail.Text = ((EPersona)Session["user"]).Correo;
                    txtDoc.Text = ((EPersona)Session["user"]).Documento;
                    txtTel.Text = ((EPersona)Session["user"]).Telefono;
                }
                else
                {

                    HttpContext.Current.Response.Redirect("../Views/Login.aspx");
                }

            }
        }

        protected void lkbSolAmd_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            int id = ((EPersona)Session["user"]).Id;
            Respuesta resp = usuario.comprobarSolicitudAdmin(id);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);

        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            HttpContext.Current.Response.Redirect("../Views/Inicio.html");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            EPersona user = new EPersona();
            Usuario usuario = new Usuario();
            user.Id = ((EPersona)Session["user"]).Id;
            if (txtNombre.Text.Length < 3)
            {
                HttpContext.Current.Response.Write("<script>alert('Nombre incorrecto')</script>");
            }
            else
            {
                user.Nombres = txtNombre.Text.ToUpper();
            }
            if (txtApellido.Text.Length < 4)
            {
                HttpContext.Current.Response.Write("<script>alert('Apellido incorrecto')</script>");
            }
            else
            {
                user.Apellidos = txtApellido.Text.ToUpper();
            }
            if (txtTel.Text.Length < 10)
            {
                HttpContext.Current.Response.Write("<script>alert('Número de teléfono incorrecto...Recuerde 60+indicativo+Número para fijo')</script>");
            }
            else
            {
                user.Telefono = txtTel.Text;
            }
            if (usuario.validarEmail(txtemail.Text))
            {
                user.Correo = txtemail.Text.ToUpper();
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('Correo incorrecto')</script>");
            }

            user.FechaNacimiento = DateTime.Parse(txtNac.Text);
            user.Documento = txtDoc.Text;
            user.Genero = txtGen.Text;
            user.RolId = 2;

            Respuesta resp = usuario.actualizarPersona(user);
            Session["user"] = resp.User;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);

        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect("../Views/CambiarPassword.aspx");
        }
    }
}