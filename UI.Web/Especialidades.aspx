<%@ Page Title="Especialidades" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <br />

    <h1>Especialidades</h1>

    <asp:Panel ID="Panel1" runat="server">
        <asp:GridView ID="GridViewEspecialidades" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="GridViewEspecialidades_SelectedIndexChanged" CssClass="table table-striped table-bordered table-hover">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <asp:LinkButton ID="lbEditar" runat="server" OnClick="lbEditar_Click" CssClass="btn btn-warning">Editar</asp:LinkButton>
        <asp:LinkButton ID="lbEliminar" runat="server" OnClick="lbEliminar_Click" CssClass="btn btn-danger">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="lbNuevo" runat="server" OnClick="Nuevo_Click" CssClass="btn btn-success">Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" runat="server" Visible="False">
         <br />
    <div class="container">
        <div class="form-group">
        <asp:Label ID="Label3" runat="server" Text="Descripción"></asp:Label>
        <asp:TextBox ID="txtDescripcionEsp" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">        
        <asp:Panel ID="Panel3" runat="server">
            <asp:LinkButton ID="lbAceptar" runat="server" CssClass="btn btn-primary" OnClick="lbAceptar_Click1">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="lbCancelar" runat="server" OnClick="lbCancelar_Click" CssClass="btn btn-secondary">Cancelar</asp:LinkButton>
        </asp:Panel>
        </div>
    </div>
    </asp:Panel>
    <asp:Panel ID="ErrorPanelEspecialidad" runat="server" Visible="False">
        <div id="errores" class="container">
            <div class="alert alert-danger" role="alert">
                <asp:Label ID="labelErrorEspecialidad" runat="server" Text="Mensaje de error"></asp:Label>
            </div>
        </div>
    </asp:Panel>


</asp:Content>
