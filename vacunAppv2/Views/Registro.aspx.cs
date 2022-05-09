using System;
using System.Web;
using System.Web.UI;
using System.Globalization;
using Utilitarios;
using Logica;

namespace vacunAppv2.Controllers
{
    public partial class WebForm1 : System.Web.UI.Page
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

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            DateTime fecha;
            EPersona persona = new EPersona();
            Usuario usuario = new Usuario();

            if (txtNombre.Text.Length < 3)
            {
                HttpContext.Current.Response.Write("<script>alert('Nombre incorrecto')</script>");
            }
            else
            {
                persona.Nombres = txtNombre.Text.ToUpper();
            }
            if (txtApellido.Text.Length < 4)
            {
                HttpContext.Current.Response.Write("<script>alert('Apellido incorrecto')</script>");
            }
            else
            {
                persona.Apellidos = txtApellido.Text.ToUpper();
            }


            if ((!DateTime.TryParse(txtNac.Text, out fecha)) || DateTime.Parse(txtNac.Text) >= DateTime.Today)
            {

                HttpContext.Current.Response.Write("<script>alert('Fecha de Nacimiento incorrecta')</script>");
            }
            else
            {
                DateTime fechaNacimiento = Convert.ToDateTime(txtNac.Text);
                persona.FechaNacimiento = Convert.ToDateTime(fechaNacimiento.ToShortDateString());
            }

            if (txtDoc.Text.Length < 8)
            {
                HttpContext.Current.Response.Write("<script>alert('Número de documento incorrecto')</script>");
            }
            else
            {
                persona.Documento = txtDoc.Text;
            }
            if (txtTel.Text.Length < 10)
            {
                HttpContext.Current.Response.Write("<script>alert('Número de teléfono incorrecto...Recuerde 60+indicativo+Número para fijo')</script>");
            }
            else
            {
                persona.Telefono = txtTel.Text;
            }

            if (txtClave.Text.Length < 6)
            {
                HttpContext.Current.Response.Write("<script>alert('Clave incorrecta, mínimo 6 caracteres - máximo 14')</script>");
            }
            else
            {
                 
                persona.Clave = usuario.encriptarPassword(txtClave.Text);
            }

            if (usuario.validarEmail(Txtemail.Text))
            {
                persona.Correo = Txtemail.Text.ToUpper();
            }
            else
            {
                HttpContext.Current.Response.Write("<script>alert('Correo incorrecto')</script>");
            }

            persona.Genero = dropGenero.Text.ToUpper();
            persona.RolId = 2;


            if (persona.Nombres != null
                 && persona.Apellidos != null
                 && persona.FechaNacimiento != null
                 && persona.Documento != null
                 && persona.Correo != null
                 && persona.Telefono != null
                 && persona.Clave != null)
            {
                Respuesta resp = usuario.crearPersona(persona);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);

            }
        }
    }
}