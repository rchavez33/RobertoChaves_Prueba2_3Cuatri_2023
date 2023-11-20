using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RobertoChaves_Prueba2_3Cuatri_2023
{
    public partial class Tecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Tecnicos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {


            int resultado = Clases.Tecnicos.AgregarTecnico(tnombre.Text, tespecialidad.Text);

            if (resultado > 0)
            {
                alertas("Tecnico ingresado ha sido ingresado con exito");
                tnombre.Text = string.Empty;
                tespecialidad.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar Tecnico");

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Tecnicos.BorrarTecnicoID(int.Parse(ttecnicoid.Text));

            if (resultado > 0)
            {
                alertas("Tecnico indicado ha sido borrado con exito");
                ttecnicoid.Text = string.Empty;
                tnombre.Text = string.Empty;
                tespecialidad.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al borrar tecnico");

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Tecnicos.ModificarTecnicoID(int.Parse(ttecnicoid.Text), tnombre.Text, tespecialidad.Text);

            if (resultado > 0)
            {
                alertas("Tecnico ingresado ha sido modificado con exito");
                ttecnicoid.Text = string.Empty;
                tnombre.Text = string.Empty;
                tespecialidad.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar tecnico");

            }
        }

        protected void Bconsulta_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(ttecnicoid.Text);
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Tecnicos WHERE TecnicoID ='" + codigo + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        datagrid.DataSource = dt;
                        datagrid.DataBind();  // actualizar el grid view
                    }
                }
            }
        }
    }
}