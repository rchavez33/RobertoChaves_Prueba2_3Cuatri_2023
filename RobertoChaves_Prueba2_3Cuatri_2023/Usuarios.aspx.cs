using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RobertoChaves_Prueba2_3Cuatri_2023.Clases;

namespace RobertoChaves_Prueba2_3Cuatri_2023
{
    public partial class Usuarios1 : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Usuarios"))
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


            int resultado = Clases.Usuarios.AgregarUsuario(tnombre.Text, tcorreoelectronico.Text, ttelefono.Text);

            if (resultado > 0)
            {
                alertas("Usuario ingresado ha sido ingresado con exito");
                tnombre.Text = string.Empty;
                tcorreoelectronico.Text = string.Empty;
                ttelefono.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar usuario");

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Usuarios.BorrarUsuarioID(int.Parse(tusuarioid.Text));

            if (resultado > 0)
            {
                alertas("Usuario indicado ha sido borrado con exito");
                tusuarioid.Text = string.Empty;
                tnombre.Text= string.Empty;
                tcorreoelectronico.Text= string.Empty;
                ttelefono.Text= string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al borrar usuario");

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Usuarios.ModificarUsuarioID(int.Parse(tusuarioid.Text),tnombre.Text, tcorreoelectronico.Text, ttelefono.Text);

            if (resultado > 0)
            {
                alertas("Usuario ingresado ha sido modificado con exito");
                tusuarioid.Text= string.Empty;
                tnombre.Text = string.Empty;
                tcorreoelectronico.Text = string.Empty;
                ttelefono.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al modificar usuario");

            }
        }

        protected void Bconsulta_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tusuarioid.Text);
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE UsuarioID ='" + codigo + "'"))


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