using System;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web;
using Utilitarios;
using Logica;
using System.Web.UI;

namespace vacunAppv2.Views
{
    public partial class SolicitudesAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null || ((EPersona)Session["user"]).RolId == 2)
            {
                HttpContext.Current.Response.Redirect("../Views/Login.aspx");
            }
            else
            {
                Administrador admin = new Administrador();
                if(admin.verRegistrosAdmin().Count() > 0)
                {
                    this.bindData();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Aún no cuenta con registros');window.location = history.back();", true);

                }

            }
        }

        protected void bindData()
        {
            Administrador datos = new Administrador();
            tabla.DataSource = datos.verRegistrosAdmin();
            tabla.DataBind();
        }
        protected void btnLogOut_Click(object sender, EventArgs e)
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