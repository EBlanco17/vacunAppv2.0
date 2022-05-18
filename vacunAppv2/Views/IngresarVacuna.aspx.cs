using System;
using System.Web.UI;
using System.Web;
using Utilitarios;
using Logica;
using System.Web.UI.WebControls;

namespace vacunAppv2.Views
{
    public partial class IngresarVacuna : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["user"] == null || ((EPersona)Session["user"]).RolId == 1)
                {
                    HttpContext.Current.Response.Redirect("../Views/Login.aspx");
                }
                else
                {
                    llenarDropFarmaceuticas();
                }
            }
        }

        public void llenarDropFarmaceuticas()
        {
            Usuario datos = new Usuario();
            dropFarmaceutica.DataSource = datos.listarFarmaceuticas();
            dropFarmaceutica.DataTextField = "nombre";
            dropFarmaceutica.DataValueField = "id";
            dropFarmaceutica.DataBind();
            dropFarmaceutica.Items.Insert(0, new ListItem("Seleccionar", "0"));
            dropVacunas.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            HttpContext.Current.Response.Redirect("../Views/Inicio.html");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            EVacunasAplicadas eVacuna = new EVacunasAplicadas();
            DateTime fecha;
            eVacuna.UsuarioId = ((EPersona)Session["user"]).Id;
            eVacuna.VacunaId = dropVacunas.SelectedIndex;
            
            if ((!DateTime.TryParse(txtFechaApl.Text, out fecha)) || DateTime.Parse(txtFechaApl.Text) > DateTime.Today)
            {
                HttpContext.Current.Response.Write("<script>alert('Fecha de Aplicación Incorrecta')</script>");

            }
            else
            {
                DateTime fechaVec = Convert.ToDateTime(txtFechaApl.Text);
                eVacuna.FechaAplicacion = Convert.ToDateTime(fechaVec.ToShortDateString());
            }

            if (txtLugar.Text.Length < 3)
            {
                HttpContext.Current.Response.Write("<script>alert('Lugar de Aplicación Incorrecto!!!')</script>");
            }
            else
            {
                eVacuna.LugarAplicacion = txtLugar.Text;
            }
            eVacuna.NoDosis = Convert.ToInt32(txtDosis.Text);
            if (eVacuna.UsuarioId != 0
                && eVacuna.VacunaId != 0
                && eVacuna.FechaAplicacion != null
                && eVacuna.LugarAplicacion != null
                )
            {
                Respuesta resp = usuario.ingresarVacuna(eVacuna);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);

            }
            
        }

        protected void dropFarmaceutica_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idFarmaceutica = Convert.ToInt32(dropFarmaceutica.SelectedValue);
            Usuario datos = new Usuario();
            dropVacunas.DataSource = datos.getVacunas(idFarmaceutica);
            dropVacunas.DataTextField = "nombre";
            dropVacunas.DataValueField = "id";
            dropVacunas.DataBind();
            dropVacunas.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }
    }
}