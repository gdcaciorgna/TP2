<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridpanel" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Cursos"></asp:Label>
        <asp:GridView ID="gridview" runat="server"  AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
         <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="IDMateria" HeaderText="ID Materia" />
                <asp:BoundField DataField="IDComision" HeaderText="ID Comision" />
                <asp:BoundField DataField="Cupo" HeaderText="Cupo" />
                <asp:BoundField DataField="AnioCalendario" HeaderText="Anio Calendario" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="Panel4" runat="server">
        <asp:LinkButton ID="lbEditar" runat="server" OnClick="lbEditar_Click1">Editar</asp:LinkButton>
        <asp:LinkButton ID="lbEliminar" runat="server" OnClick="lbEliminar_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="lbNuevo" runat="server" OnClick="lbNuevo_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" runat="server" Visible="False">
        <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
        <br />
        <asp:TextBox ID="tbDescripcion" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblIDMateria" runat="server" Text="Materia"></asp:Label>
        <asp:DropDownList ID="id_Materia" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblIDComision" runat="server" Text="Comision"></asp:Label>
        <asp:DropDownList ID="id_Comision" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblCupo" runat="server" Text="Cupo"></asp:Label>
        <br />
        <asp:TextBox ID="tbCupo" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblanio_calendario" runat="server" Text="anio_calendario"></asp:Label>
        <br />
        <asp:TextBox ID="tbanio" runat="server" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:LinkButton ID="lbAceptar" runat="server" OnClick="lbAceptar_Click1">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="lbCancelar" runat="server" OnClick="lbCancelar_Click">Cancelar</asp:LinkButton>
        <br />
    </asp:Panel>
    <asp:Panel ID="PanelError" runat="server" Visible="False">
        <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
    </asp:Panel>
</asp:Content>
