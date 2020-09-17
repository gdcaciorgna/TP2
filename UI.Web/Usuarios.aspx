<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        
        <br />

        <h1>Usuarios</h1>
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="GridView_SelectedIndexChanged" AllowSorting="True" CssClass="table table-striped table-bordered table-hover" PageSize="6">
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
            <asp:LinkButton ID="lbEditar" runat="server" OnClick="lbEditar_Click" CssClass="btn btn-warning">Editar</asp:LinkButton>
            <asp:LinkButton ID="lbEliminar" runat="server" OnClick="lbEliminar_Click" CssClass="btn btn-danger">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="lbNuevo" runat="server" OnClick="lbNuevo_Click" CssClass="btn btn-success">Nuevo</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="formPanel" runat="server" Visible="False">
        <br />
        <div class="container">
            <div class="form-group">
            <asp:Label ID="lbNombre" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="tbNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="lbApellido" runat="server" Text="Apellido"></asp:Label>
            <asp:TextBox ID="tbApellido" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="lbEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
            </div>

            <div class="form-check form-group">
                <asp:CheckBox ID="cbHabilitado" runat="server" CssClass="form-check-input" />
                <asp:Label ID="lbHabilitado" runat="server" Text="Habilitado" CssClass="form-check-label"></asp:Label>
            </div>
            
            <div class="form-group">
                <asp:Label ID="lbUsuario" runat="server" Text="Usuario"></asp:Label>
                <asp:TextBox ID="tbUsuario" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lbClave" runat="server" Text="Clave"></asp:Label>
                <asp:TextBox ID="tbClave" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lbRepetirClave" runat="server" Text="Repetir Clave"></asp:Label>
                <asp:TextBox ID="tbRepetirClave" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            
           
                <asp:LinkButton ID="lbAceptar" runat="server" OnClick="lbAceptar_Click" CssClass="btn btn-primary">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="lbCancelar" runat="server" OnClick="lbCancelar_Click" CssClass="btn btn-secondary">Cancelar</asp:LinkButton>

     
            <asp:Panel ID="Panel2" runat="server">
            </asp:Panel>
        </div>
        </asp:Panel>
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
