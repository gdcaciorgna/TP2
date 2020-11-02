<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InscribirDocenteACurso.aspx.cs" Inherits="UI.Web.InscribirDocenteACurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">



    <asp:DropDownList ID="ddl_Cursos" runat="server">
</asp:DropDownList>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" />
<asp:GridView ID="dgvDocentesxCurso" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" EmptyDataText="No hay docentes cargados" OnSelectedIndexChanged="dgvDocentesxCurso_SelectedIndexChanged" ShowHeaderWhenEmpty="True" DataKeyNames="ID">
    <Columns>
        <asp:BoundField DataField="IDDocente" HeaderText="Docente" />
        <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
        <asp:CommandField ShowSelectButton="True" />
    </Columns>
</asp:GridView>
<br />



</asp:Content>
