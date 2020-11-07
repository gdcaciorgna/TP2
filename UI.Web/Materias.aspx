<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="GridPanelDatos" runat="server">

    <br />

    <h1>Materias</h1>

    <asp:GridView ID="GridMaterias" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridMaterias_SelectedIndexChanged" DataKeyNames="ID" EmptyDataText="Aún no hay materias cargadas." ShowHeaderWhenEmpty="True" AllowSorting="True" CssClass="table table-striped table-bordered table-hover">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID materia" />
            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion Materia" />
            <asp:BoundField DataField="HSSemanales" HeaderText="Horas semanales" />
            <asp:BoundField DataField="HSTotales" HeaderText="Horas total" />
            <asp:BoundField DataField="DescPlan" HeaderText="Plan" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Panel>

<asp:Panel ID="PanelBotones" runat="server">
    <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" OnClick="BtnNuevo_Click" CssClass="btn btn-success" />
    <asp:Button ID="BtnEditar" runat="server" OnClick="BtnEditar_Click" Text="Editar" CssClass="btn btn-warning" />
    <asp:Button ID="BtnEliminar" runat="server" OnClick="BtnEliminar_Click" Text="Eliminar"  CssClass="btn btn-danger" />
</asp:Panel>

<asp:Panel ID="PanelCampos" runat="server" Visible="False">
    <br />
    <div class="container">
        <div class="form-group">
             <asp:Label runat="server" Text="Horas semanales"></asp:Label>
             <asp:TextBox ID="txbHsSemanales" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label runat="server" Text="Descripcion materia"></asp:Label>
            <asp:TextBox ID="txbDescripcionmaterias" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="lblHsTotales" runat="server" Text="Horas total"></asp:Label>
            <asp:TextBox ID="txbHorasTotales" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Id Plan"></asp:Label>
            <asp:DropDownList ID="DplIDPlan" runat="server" CssClass="form-control">
            </asp:DropDownList>
        </div>
    
        
        <asp:Button ID="BtnAceptar" runat="server" OnClick="BtnAceptar_Click" Text="Aceptar" CssClass="btn btn-primary" />
        <asp:Button ID="BtnCancelar" runat="server" OnClick="BtnCancelar_Click" Text="Cancelar" CssClass="btn btn-secondary" />
    </div>

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
