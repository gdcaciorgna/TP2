<%@ Page Title="Especialidades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">


    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="GridViewEspecialidades" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="GridViewEspecialidades_SelectedIndexChanged" style="height: 133px">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <asp:LinkButton ID="lbEditar" runat="server" OnClick="lbEditar_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="lbEliminar" runat="server" OnClick="lbEliminar_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="lbNuevo" runat="server" OnClick="Nuevo_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" runat="server" Visible="False">
        <asp:Label ID="Label3" runat="server" Text="Descripción"></asp:Label>
        <asp:TextBox ID="txtDescripcionEsp" runat="server"></asp:TextBox>
        
        <asp:Panel ID="Panel3" runat="server">
            <asp:LinkButton ID="lbAceptar" runat="server" OnClick="lbAceptar_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="lbCancelar" runat="server" OnClick="lbCancelar_Click">Cancelar</asp:LinkButton>
        </asp:Panel>

    </asp:Panel>
    <asp:Panel ID="ErrorPanelEspecialidad" runat="server" Visible="False">
        <asp:Label ID="Label1" runat="server" Text="Mensaje de error"></asp:Label>
    </asp:Panel>


</asp:Content>
