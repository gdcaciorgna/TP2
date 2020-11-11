<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridpanel" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Cursos"></asp:Label>
        <br />
        <asp:GridView ID="dgv_Cursos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="dgv_Cursos_SelectedIndexChanged" DataKeyNames="ID" EmptyDataText="Aún no hay cursos cargados." ShowHeaderWhenEmpty="True" CssClass="table table-striped table-bordered table-hover">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Materia" HeaderText="Materia" />
                <asp:BoundField DataField="IDComision" HeaderText="Comision" />
                <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
                <asp:BoundField DataField="AnioCalendario" HeaderText="Año calendario" />
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="Panel4" runat="server">
        <asp:LinkButton ID="lbNuevo" runat="server" OnClick="lbNuevo_Click" CssClass="btn btn-success">Nuevo</asp:LinkButton>
        <asp:LinkButton ID="lbEditar" runat="server" OnClick="lbEditar_Click1" CssClass="btn btn-warning">Editar</asp:LinkButton>
        <asp:LinkButton ID="lbEliminar" runat="server" OnClick="lbEliminar_Click" CssClass="btn btn-danger">Eliminar</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" runat="server" Visible="False">
        <div class="container">
            <br />
            <div class="form-group">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
                <asp:TextBox ID="tbDescripcion" runat="server" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="form-group">
                <asp:Label ID="lblIDMateria" runat="server" Text="Materia"></asp:Label>
                <asp:DropDownList ID="ddl_Materia" runat="server" CssClass="form-control"></asp:DropDownList>

            </div>

            <div class="form-group">
                <asp:Label ID="lblIDComision" runat="server" Text="Comision"></asp:Label>
                <asp:DropDownList ID="ddl_Comision" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label ID="lblCupo" runat="server" Text="Cupo"></asp:Label>
                <asp:TextBox ID="tbCupo" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblanio_calendario" runat="server" Text="Año calendario"></asp:Label>
                <asp:TextBox ID="tbanio" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            
    
            <asp:LinkButton ID="lbAceptar" runat="server" OnClick="lbAceptar_Click1" CssClass="btn btn-primary">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="lbCancelar" runat="server" OnClick="lbCancelar_Click" CssClass="btn btn-secondary">Cancelar</asp:LinkButton>
        </div>
    </asp:Panel>
    <asp:Panel ID="PanelError" runat="server" Visible="False">
        <div id="errores" class="container">
            <div class="alert alert-danger" role="alert">
            <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
            </div>
        </div>

    </asp:Panel>
</asp:Content>
