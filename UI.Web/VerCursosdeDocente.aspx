<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerCursosdeDocente.aspx.cs" Inherits="UI.Web.VerCursosdeDocente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:GridView ID="gvCursosdeDocente" runat="server" Width="1517px" AutoGenerateColumns="False" EmptyDataText="No hay cursos asignados" ShowHeaderWhenEmpty="True">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="Id Curso" />
        <asp:BoundField DataField="Materia" HeaderText="Materia" />
        <asp:BoundField DataField="Comision" HeaderText="Comision" />
        <asp:CommandField ShowSelectButton="True" />
    </Columns>
</asp:GridView>
    <asp:Panel ID="Panel4" runat="server">
    </asp:Panel>
</asp:Content>
