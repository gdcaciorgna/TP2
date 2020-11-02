<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <br />

        <h1>Planes</h1>

        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-striped table-bordered table-hover" EmptyDataText="Aún no hay planes cargados." ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="IdPlan" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion plan" />
                <asp:BoundField DataField="IDEspecialidad" HeaderText="Id Especialidad" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    
    <asp:Panel ID="fomrPanel" runat="server" style="margin-bottom: 0px" Visible="False">
     <br />
       <div class="container">
        <asp:Label ID="desc_planLabel" runat="server" Text="Descripcion Plan"></asp:Label>
        <asp:TextBox ID="Desc_PlanTextBox" CssClass="form-control" runat="server"></asp:TextBox>
        <asp:Label ID="IdespecialidadLabel" runat="server" Text="Id Especialidad"></asp:Label>
        <asp:DropDownList ID="Id_Especialidaddrownlist" CssClass="form-control" runat="server" OnSelectedIndexChanged="Id_EspecialidadcheckBox_SelectedIndexChanged">
        </asp:DropDownList>

        <asp:Panel ID="formActionPanel" runat="server">
            <br />
            <asp:Button ID="btnaceptarPlan" runat="server" OnClick="btnaceptarPlan_Click" CssClass="btn btn-primary" Text="Aceptar" />
            <asp:Button ID="btnCancelarPlan" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelarPlan_Click" />
        </asp:Panel>
       </div>
    </asp:Panel>
    <asp:Panel ID="gridAcccionesPanel" runat="server">
        <br />
        <asp:LinkButton ID="AgregarPlanLink" runat="server" CssClass="btn btn-success" OnClick="AgregarPlanLink_Click">Nuevo</asp:LinkButton>
        <asp:LinkButton ID="EliminarPlanLink" runat="server" CssClass="btn btn-danger" OnClick="EliminarPlanLink_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="EditarPlanLink" runat="server" CssClass="btn btn-warning" OnClick="EditarPlanLink_Click">Editar</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="panelerror" runat="server" Visible="False">
        <br />
        <div id="errores" class="container">
            <div class="alert alert-danger" role="alert">
        <asp:Label ID="lblerror" runat="server" Text="Label"></asp:Label>
        </div>
            </div>
    </asp:Panel>
</asp:Content>
