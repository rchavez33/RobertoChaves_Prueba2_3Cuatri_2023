<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="RobertoChaves_Prueba2_3Cuatri_2023.Tecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container text-center">
         <h1>Tecnicos</h1>
         
    </div>
        <div>
    <br />
    <br />
    <asp:GridView runat="server" ID="datagrid" PageSize="10" HorizontalAlign="Center"
        CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
        RowStyle-CssClass="rows" AllowPaging="True" />

    <br />
    <br />
    <br />

</div>
<div class="container text-center">
    TecnicoID (Usar este espacio solo para Borrar o Consultar): <asp:TextBox ID="ttecnicoid" class="form-control" runat="server"></asp:TextBox>
    Nombre: <asp:TextBox ID="tnombre" class="form-control" runat="server"></asp:TextBox>
    Especialidad: <asp:TextBox ID="tespecialidad" class="form-control" runat="server"></asp:TextBox>
</div>
   <br />
   <br />
<div class="container text-center">

    <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Agregar" OnClick="Button1_Click" BorderStyle="Solid" />
    <asp:Button ID="Button2" class="btn btn-outline-danger" runat="server" Text="Borrar" OnClick="Button2_Click" BorderStyle="Solid" />
    <asp:Button ID="Button3" runat="server" class="btn btn-outline-warning" Text="Modificar" OnClick="Button3_Click" BorderStyle="Solid" />
    <asp:Button ID="Bconsulta" runat="server" class="btn btn-outline-info" Text="Consultar" OnClick="Bconsulta_Click" BorderStyle="Solid" />
    

</div>

   <br />
   <br />

   <footer class="container text-center">
       Roberto Chaves // Segunda Prueba // Tercer Cuatrimetre // 2023
   </footer>
</asp:Content>
