<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" BackColor="Black" DataKeyNames="ID" ForeColor="White" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Panel ID="Panel1" runat="server">
            <asp:LinkButton ID="lbEditar" runat="server" OnClick="lbEditar_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="lbEliminar" runat="server" OnClick="lbEliminar_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="lbNuevo" runat="server" OnClick="lbNuevo_Click">Nuevo</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="formPanel" runat="server" Visible="False">
            <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbApellido" runat="server" Text="Apellido"></asp:Label>
            <asp:TextBox ID="tbApellido" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbHabilitado" runat="server" Text="Habilitado"></asp:Label>
            <asp:CheckBox ID="cbHabilitado" runat="server" />
            <br />
            <asp:Label ID="lbUsuario" runat="server" Text="Usuario"></asp:Label>
            <asp:TextBox ID="tbUsuario" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbClave" runat="server" Text="Clave"></asp:Label>
            <asp:TextBox ID="tbClave" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbRepetirClave" runat="server" Text="Repetir Clave"></asp:Label>
            <asp:TextBox ID="tbRepetirClave" runat="server"></asp:TextBox>
            <asp:Panel ID="Panel2" runat="server">
                <asp:LinkButton ID="lbAceptar" runat="server" OnClick="lbAceptar_Click">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="lbCancelar" runat="server" OnClick="lbCancelar_Click">Cancelar</asp:LinkButton>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="PanelError" runat="server" Visible="False">
        <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
    </asp:Panel>
</asp:Content>
