using System;
using System.Web.UI;
using System.Web;
using Utilitarios;
using Logica;
using System.Web.UI.WebControls;

namespace vacunAppv2.Views
{
    public partial class RegistrarVacuna : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["user"] == null || ((EPersona)Session["user"]).RolId == 2)
                {
                    HttpContext.Current.Response.Redirect("../Views/Login.aspx");
                }
                else
                {
                    llenarDrop();
                }
            }
        }
        public void llenarDrop()
        {
            Administrador datos =new Administrador();
            dropFarmaceuticas.DataSource = datos.listarFarmaceuticas();
            dropFarmaceuticas.DataTextField = "nombre";
            dropFarmaceuticas.DataValueField = "id";
            dropFarmaceuticas.DataBind();
            dropFarmaceuticas.Items.Insert(0, new ListItem("Seleccionar", "0"));
        }
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            HttpContext.Current.Response.Redirect("../Views/Inicio.html");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            DateTime fecha;
            EVacuna vacuna = new EVacuna();
            Administrador admin = new Administrador();
            string farmaceutica = dropFarmaceuticas.SelectedItem.Text;
            
            vacuna.Nombre = txtNombre.Text;
            vacuna.Lote = txtLote.Text;
            if ((!DateTime.TryParse(txtFechaFab.Text, out fecha)) || DateTime.Parse(txtFechaFab.Text) > DateTime.Today)
            {
                HttpContext.Current.Response.Write("<script>alert('Fecha de Fabricación Incorrecta')</script>");
            }
            else
            {
                DateTime fechaFab = Convert.ToDateTime(txtFechaFab.Text);
                vacuna.FechaFabricacion = Convert.ToDateTime(fechaFab.ToShortDateString());
            }
            if ((!DateTime.TryParse(txtFechaVec.Text, out fecha)) || DateTime.Parse(txtFechaVec.Text) <= DateTime.Today)
            {
                HttpContext.Current.Response.Write("<script>alert('Fecha de Expiración Incorrecta')</script>");
            }
            else
            {
                DateTime fechaVec = Convert.ToDateTime(txtFechaVec.Text);
                vacuna.FechaExpiracion = Convert.ToDateTime(fechaVec.ToShortDateString());
            }
            vacuna.TiempoProteccion = Convert.ToInt32(txtTiempo.Text);
            vacuna.Descripcion = txtDesc.Text;
            vacuna.Cantidad = Convert.ToInt32(txtCant.Text);
            vacuna.NoDosis = Convert.ToInt32(txtDosis.Text);

            admin.agregarVacunas(vacuna, farmaceutica);
        }
    }
}