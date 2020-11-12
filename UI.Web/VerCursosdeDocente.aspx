<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerCursosdeDocente.aspx.cs" Inherits="UI.Web.VerCursosdeDocente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:GridView ID="gvCursosdeDocente" runat="server" Width="1517px" AutoGenerateColumns="False" EmptyDataText="No hay cursos asignados" ShowHeaderWhenEmpty="True" DataKeyNames="ID" OnSelectedIndexChanged="gvCursosdeDocente_SelectedIndexChanged" CssClass="table table-striped table-bordered table-hover">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="Id curso" />
            <asp:BoundField DataField="materia" HeaderText="Materia" />
            <asp:BoundField DataField="comision" HeaderText="comision" />
            <asp:BoundField DataField="aniocalendario" HeaderText="Años calendario" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
</asp:GridView>
    <asp:Panel ID="Panel4" runat="server">
        <asp:Button ID="btnEditarCurso" runat="server" Text="Editar curso" OnClick="btnEditarCurso_Click" CssClass="btn btn-warning" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cancelar" CssClass="btn btn-secondary active align-content-center" />
    </asp:Panel>
    <asp:Panel ID="panelError" runat="server" Visible="False">
        Error:<br /> Debe seleccionar un curso.</asp:Panel>
</asp:Content>
