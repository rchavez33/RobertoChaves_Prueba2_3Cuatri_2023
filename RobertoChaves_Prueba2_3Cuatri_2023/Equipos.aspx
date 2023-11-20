<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="RobertoChaves_Prueba2_3Cuatri_2023.Equipos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center">
        <h1>Equipos</h1>
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
    EquipoID (Usar este espacio solo para Borrar o Consultar): <asp:TextBox ID="tequipoid" class="form-control" runat="server"></asp:TextBox>
    UsuarioID (Usar este espacio solo para Borrar o Consultar): <asp:TextBox ID="tusuarioid" class="form-control" runat="server"></asp:TextBox>
    TipoEquipo: <asp:TextBox ID="ttipoequipo" class="form-control" runat="server"></asp:TextBox>
    Modelo: <asp:TextBox ID="tmodelo" class="form-control" runat="server"></asp:TextBox>
   
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
