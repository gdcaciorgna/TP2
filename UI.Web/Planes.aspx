<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="IdPlan" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion plan" />
                <asp:BoundField DataField="IDEspecialidad" HeaderText="Id Especialidad" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="fomrPanel" runat="server" style="margin-bottom: 0px" Visible="False">
        <asp:Label ID="desc_planLabel" runat="server" Text="Descripcion Plan"></asp:Label>
        <asp:TextBox ID="Desc_PlanTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="IdespecialidadLabel" runat="server" Text="Id Especialidad"></asp:Label>
        &nbsp;<asp:DropDownList ID="Id_Especialidaddrownlist" runat="server" OnSelectedIndexChanged="Id_EspecialidadcheckBox_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Panel ID="formActionPanel" runat="server">
            <asp:Button ID="btnaceptarPlan" runat="server" OnClick="btnaceptarPlan_Click" Text="Aceptar" />
            <asp:Button ID="btnCancelarPlan" runat="server" Text="Cancelar" OnClick="btnCancelarPlan_Click" />
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="gridAcccionesPanel" runat="server">
        <asp:LinkButton ID="AgregarPlanLink" runat="server" OnClick="AgregarPlanLink_Click">Nuevo</asp:LinkButton>
        <asp:LinkButton ID="EliminarPlanLink" runat="server" OnClick="EliminarPlanLink_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="EditarPlanLink" runat="server" OnClick="EditarPlanLink_Click">Editar</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="panelerror" runat="server" Visible="False">
        <asp:Label ID="lblerror" runat="server" Text="Label"></asp:Label>
    </asp:Panel>
</asp:Content>
