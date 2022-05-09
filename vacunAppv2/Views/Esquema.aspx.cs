using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilitarios;
using Logica;


namespace vacunAppv2.Views
{
    public partial class Esquema : System.Web.UI.Page
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
                    this.bindData();
                }
            }
        }

        protected void bindData()
        {
            int id = ((EPersona)Session["user"]).Id;
            Usuario datos = new Usuario();
            tabla.DataSource = datos.getVacunasAplicadas(id);
            tabla.DataBind();
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            HttpContext.Current.Response.Redirect("../Views/Inicio.html");
        }

        protected void tabla_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            tabla.PageIndex = e.NewPageIndex;
            this.bindData();
        }
    }
}