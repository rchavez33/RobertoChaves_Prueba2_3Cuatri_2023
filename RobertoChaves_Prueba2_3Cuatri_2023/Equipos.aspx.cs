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
    public partial class Equipos : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Equipos"))
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


            int resultado = Clases.Equipos.AgregarEquipo(ttipoequipo.Text, tmodelo.Text);

            if (resultado > 0)
            {
                alertas("Equipo ingresado ha sido ingresado con exito");
                ttipoequipo.Text = string.Empty;
                tmodelo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar Equipo");

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Equipos.BorrarEquipoID(int.Parse(tequipoid.Text));

            if (resultado > 0)
            {
                alertas("Equipo indicado ha sido borrado con exito");
                tequipoid.Text = string.Empty;
                tusuarioid.Text = string.Empty;
                ttipoequipo.Text = string.Empty;
                tmodelo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al borrar Equipo");

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Equipos.ModificarEquipoID(int.Parse(tequipoid.Text), tusuarioid.Text, ttipoequipo.Text, tmodelo.Text);

            if (resultado > 0)
            {
                alertas("Equipo ingresado ha sido modificado con exito");
                tequipoid.Text = string.Empty;
                tusuarioid.Text = string.Empty;
                ttipoequipo.Text = string.Empty;
                tmodelo.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar equipo");

            }
        }

        protected void Bconsulta_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tequipoid.Text);
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipos WHERE EquipoID ='" + codigo + "'"))


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