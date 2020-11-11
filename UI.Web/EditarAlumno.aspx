<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarAlumno.aspx.cs" Inherits="UI.Web.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="PanelTextbox" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Alumno:"></asp:Label>
        <asp:TextBox ID="txtAlumno" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Condicion:"></asp:Label>
        <asp:TextBox ID="txtCondicion" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Nota:"></asp:Label>
        <asp:TextBox ID="txtNota" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" CssClass="btn btn-warning"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" CssClass="btn btn-secondary active align-content-center"/>
    </asp:Panel>
    <asp:Panel ID="panelError" runat="server" Visible="False">
        <asp:Label ID="lblerror" runat="server" Text="Label"></asp:Label>
    </asp:Panel>
</asp:Content>
