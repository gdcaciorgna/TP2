<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="PanelGrid" runat="server">
        <asp:GridView ID="GridViewComisiones" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="GridViewComisiones_SelectedIndexChanged" EmptyDataText="Aún no hay comisiones cargadas." ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID comisiones" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion comisiones" />
                <asp:BoundField DataField="IDPlan" HeaderText="ID plan" />
                <asp:BoundField DataField="AnioEspecialidad" HeaderText="Año especialidad" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="PanelCampos" runat="server" Visible="False">
        <asp:Label ID="LblDescripcion" runat="server" Text="Descripcion"></asp:Label>
        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblAnioEspecialidad" runat="server" Text="Año especialidad"></asp:Label>
        <asp:TextBox ID="txtAnioEspecialidad" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lvlIDPlan" runat="server" Text="ID plan"></asp:Label>
        <asp:DropDownList ID="ddlIDPlan" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
        &nbsp;&nbsp;
        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
    </asp:Panel>
    <asp:Panel ID="PanelBotones" runat="server">
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEditar" runat="server" OnClick="btnEditar_Click" Text="Editar" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
    </asp:Panel>

<br />
<asp:Panel ID="PanelError" runat="server" Visible="False">
    <div id="errores" class="container">
        <div class="alert alert-danger" role="alert">
            <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
</asp:Panel>
</asp:Content>
