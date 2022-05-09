using System;
using System.Web;
using Utilitarios;
using Logica;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace vacunAppv2.Views
{
    public partial class Formulario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            if (!IsPostBack)
            {
                if (Session["user"] == null || ((EPersona)Session["user"]).RolId == 1)
                {
                    HttpContext.Current.Response.Redirect("../Views/Login.aspx");
                }
                else
                {
                    Usuario usuario = new Usuario();
                    EFormulario formulario = usuario.comprobarFormulario(((EPersona)Session["user"]).Id);
                    if (formulario == null)
                    {

                        IniciarLlenadoDropDown();
                    }
                    else
                    {
                        btnGuardar.Enabled = false;
                        btnGuardar.Visible = false;
                        IniciarLlenadoDropDown();
                        dropLocal.SelectedIndex = formulario.LocalidadId;
                        dropBarrio.SelectedIndex = formulario.BarrioId;
                        txtEps.Text = formulario.Eps;
                        txtDireccion.Text = formulario.Direccion;
                    }
                }
            }
        }
        public void IniciarLlenadoDropDown()
        {
            Usuario datos = new Usuario();
            dropLocal.DataSource = datos.listarLocalidades();
            dropLocal.DataTextField = "nombre";
            dropLocal.DataValueField = "id";
            dropLocal.DataBind();
            dropLocal.Items.Insert(0, new ListItem("Seleccionar", "0"));
            dropBarrio.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }
        protected void dropLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idLocal = Convert.ToInt32(dropLocal.SelectedValue);
            Usuario datos = new Usuario();
            dropBarrio.DataSource = datos.listarBarrios(idLocal);
            dropBarrio.DataTextField = "nombre";
            dropBarrio.DataValueField = "id";
            dropBarrio.DataBind();
            dropBarrio.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EFormulario formulario = new EFormulario();
            Usuario user = new Usuario();
            Respuesta resp = new Respuesta();
            formulario.UsuarioId = ((EPersona)Session["user"]).Id;
            formulario.FechaRegistro = DateTime.Today;
            formulario.LocalidadId = dropLocal.SelectedIndex;
            formulario.BarrioId = dropBarrio.SelectedIndex;
            formulario.Eps = txtEps.Text;
            formulario.Direccion = txtDireccion.Text;

            resp = user.guardarFormulario(formulario);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);


        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            HttpContext.Current.Response.Redirect("../Views/Inicio.html");
        }
    }
}