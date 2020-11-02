<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InscribirseAMateria.aspx.cs" Inherits="UI.Web.InscribirseAMateria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:DropDownList ID="ddl_Cursos" runat="server">
    </asp:DropDownList>
    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" />
    <asp:GridView ID="dgv_InscripcionesACurso" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" DataKeyNames="ID" EmptyDataText="No hay inscripciones cargadas" OnSelectedIndexChanged="dgv_InscripcionesACurso_SelectedIndexChanged" ShowHeaderWhenEmpty="True">
        <Columns>
            <asp:BoundField DataField="IDAlumno" HeaderText="IDAlumno" />
            <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
            <asp:BoundField DataField="Nota" HeaderText="Nota" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>
