<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="GridPanelDatos" runat="server">
    <asp:GridView ID="GridMaterias" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridMaterias_SelectedIndexChanged" DataKeyNames="ID" EmptyDataText="Aún no hay materias cargadas." ShowHeaderWhenEmpty="True">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID materia" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion Materia" />
            <asp:BoundField DataField="HSSemanales" HeaderText="Horas semanales" />
            <asp:BoundField DataField="HSTotales" HeaderText="Horas total" />
            <asp:BoundField DataField="IDPlan" HeaderText="ID Plan" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Panel>
<asp:Panel ID="PanelCampos" runat="server" Visible="False">
    Horas semanales<asp:TextBox ID="txbHsSemanales" runat="server"></asp:TextBox>
    <br />
    <asp:Label runat="server" Text="Descripcion materia"></asp:Label>
    <asp:TextBox ID="txbDescripcionmaterias" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblHsTotales" runat="server" Text="Horas total"></asp:Label>
    <asp:TextBox ID="txbHorasTotales" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Id Plan"></asp:Label>
    <asp:DropDownList ID="DplIDPlan" runat="server">
    </asp:DropDownList>
    &nbsp;<br />
    <asp:Button ID="BtnAceptar" runat="server" OnClick="BtnAceptar_Click" Text="Aceptar" />
    <asp:Button ID="BtnCancelar" runat="server" OnClick="BtnCancelar_Click" Text="Cancelar" />
</asp:Panel>
<asp:Panel ID="PanelBotones" runat="server">
    <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" OnClick="BtnNuevo_Click" />
    <asp:Button ID="BtnEditar" runat="server" OnClick="BtnEditar_Click" Text="Editar" />
    <asp:Button ID="BtnEliminar" runat="server" OnClick="BtnEliminar_Click" Text="Eliminar" />
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
