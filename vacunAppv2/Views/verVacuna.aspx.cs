using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web;
using Utilitarios;
using Logica;

namespace vacunAppv2.Views
{
    public partial class verVacuna : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["user"] != null && ((EPersona)Session["user"]).RolId == 1)
                {
                    Administrador admin = new Administrador();
                    EVacuna datos = admin.verVacunaXId(int.Parse(Request.QueryString.Get(0)));
                    txtId.Text = Convert.ToString(datos.Id);
                    txtFarm.Text = datos.Nombre_farmaceutica;
                    txtNombre.Text = datos.Nombre;
                    txtLote.Text = datos.Lote;
                    txtFecFab.Text = (datos.FechaFabricacion).ToShortDateString().ToString();
                    txtFecExp.Text = (datos.FechaExpiracion).ToShortDateString().ToString();
                    txtTiem.Text = Convert.ToString(datos.TiempoProteccion);
                    txtDesc.Text = datos.Descripcion;
                    txtDosis.Text = Convert.ToString(datos.NoDosis);
                    txtCant.Text = Convert.ToString(datos.Cantidad);
                    txtNuevas.Text = "0";
                }
                else
                {

                    HttpContext.Current.Response.Redirect("../Views/Login.aspx");

                }
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            HttpContext.Current.Response.Redirect("../Views/Login.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Administrador admin = new Administrador();
            EVacuna vacuna = new EVacuna();
            vacuna.Id = Convert.ToInt32(txtId.Text);
            vacuna.Nombre = txtNombre.Text;
            vacuna.Lote = txtLote.Text;
            vacuna.FechaFabricacion = DateTime.Parse(txtFecFab.Text);
            vacuna.FechaExpiracion = DateTime.Parse(txtFecExp.Text);
            vacuna.Descripcion = txtDesc.Text;
            vacuna.NoDosis = Convert.ToInt32(txtDosis.Text);
            int cantidad = Convert.ToInt32(txtCant.Text) + Convert.ToInt32(txtNuevas.Text);
            if (cantidad < 0)
            {
                HttpContext.Current.Response.Write("<script>alert('Error... no hay ese total de vacunas para descontar')</script>");
            }
            else
            {
                vacuna.Cantidad = cantidad;
                string fabricante = txtFarm.Text;

                Respuesta resp = admin.actualizarVacuna(vacuna, fabricante);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('" + resp.Mensaje + "');window.location ='" + resp.Url + "';", true);

            }

        }
    }
}