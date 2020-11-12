<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerAlumnosNotas.aspx.cs" Inherits="UI.Web.VerAlumnosNotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="PanelEncabezado" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Curso"></asp:Label>
        <asp:TextBox ID="txtCursoAcutual" runat="server" Enabled="False"></asp:TextBox>
    </asp:Panel>
    <asp:GridView ID="gvAlumnosCurso" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvAlumnosCurso_SelectedIndexChanged" Width="1533px" DataKeyNames="ID" CssClass="table table-striped table-bordered table-hover">
        <Columns>
            <asp:BoundField DataField="alumno" HeaderText="Nombre" />
            <asp:BoundField DataField="nota" HeaderText="Nota" />
            <asp:BoundField DataField="condicion" HeaderText="Condicion" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:Panel ID="Panel4" runat="server">
        <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" CssClass="btn btn-warning" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" CssClass="btn btn-secondary active align-content-center" />
    </asp:Panel>
    <asp:Panel ID="panelError" runat="server" Visible="False">
        Error:<br /> Debe seleccionar un alumno.</asp:Panel>
</asp:Content>
