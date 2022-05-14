using System;
using System.Web.UI.WebControls;
using System.Web;
using Utilitarios;
using Logica;


namespace vacunAppv2.Views
{
    public partial class RegistroVacunas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || ((EPersona)Session["user"]).RolId == 2)
            {
                HttpContext.Current.Response.Redirect("../Views/Login.aspx");
            }
            else
            {
                this.bindData();
            }
        }
        protected void bindData()
        {
            Administrador datos = new Administrador();
            tabla.DataSource = datos.verVacunas();
            tabla.DataBind();
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            HttpContext.Current.Response.Redirect("../Views/Login.aspx");
        }

        protected void tabla_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            tabla.PageIndex = e.NewPageIndex;
            this.bindData();
        }
    }
}