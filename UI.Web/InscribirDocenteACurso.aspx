<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InscribirDocenteACurso.aspx.cs" Inherits="UI.Web.InscribirDocenteACurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">



    <asp:DropDownList ID="ddl_Cursos" runat="server">
</asp:DropDownList>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" />
<asp:GridView ID="dgvDocentesxCurso" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" EmptyDataText="No hay docentes cargados" OnSelectedIndexChanged="dgvDocentesxCurso_SelectedIndexChanged" ShowHeaderWhenEmpty="True" DataKeyNames="ID">
    <Columns>
        <asp:BoundField DataField="Docente" HeaderText="Docente" />
        <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
        <asp:CommandField ShowSelectButton="True" />
        <asp:BoundField DataField="ID" HeaderText="ID dictado" />
    </Columns>
</asp:GridView>
<br />



    <asp:Panel ID="Panelbotones" runat="server" Visible="False">
        <asp:Panel ID="PanelCampos" runat="server" style="margin-left: 0px" Visible="False">
            <asp:Label ID="Label1" runat="server" Text="Docentes:"></asp:Label>
            <asp:DropDownList ID="ddlDocentes" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="Cargos:"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Cargo:"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="ddl_TipoCargos" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="1 - Titular"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server" Text="2 - Teoria"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label6" runat="server" Text="3 - Practica"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnAceptar" runat="server" OnClick="Button1_Click" Text="Aceptar" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
            <br />
        </asp:Panel>
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
        <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
    </asp:Panel>



</asp:Content>
