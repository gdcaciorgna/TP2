<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Docentes.aspx.cs" Inherits="UI.Web.Docentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

     <asp:Panel ID="gridPanel" runat="server">
        

        <div class="btn-group btn-group-toggle" data-toggle="buttons">
            <asp:LinkButton ID="lbVerTodo" runat="server" OnClick="lbVerTodo_Click" CssClass="btn btn-secondary">Ver todo</asp:LinkButton>
            <asp:LinkButton ID="lbVerDocentes" runat="server" OnClick="lbVerDocentes_Click" CssClass="btn btn-secondary active align-content-center">Ver docentes</asp:LinkButton>
            <asp:LinkButton ID="lbVerAlumnos" runat="server" OnClick="lbVerAlumnos_Click" CssClass="btn btn-secondary  align-content-center">Ver alumnos</asp:LinkButton>
        </div>

         <br />

        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnSelectedIndexChanged="GridView_SelectedIndexChanged" AllowSorting="True" CssClass="table table-striped table-bordered table-hover" PageSize="6" EmptyDataText="Aún no hay docentes cargados." ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" />
                <asp:BoundField DataField="IDPlan" HeaderText="ID Plan" />
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
            <asp:Label ID="Label1" runat="server" Text="Dirección"></asp:Label>
            <asp:TextBox ID="tbDireccion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="lbEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="Label2" runat="server" Text="Teléfono"></asp:Label>
            <asp:TextBox ID="tbTelefono" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="Label5" runat="server" Text="Legajo"></asp:Label>
            <asp:TextBox ID="tbLegajo" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>


            <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="Fecha de nacimiento"></asp:Label>
                <br />
                <asp:TextBox ID="tbFechaNacimiento" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="idplanLabel" runat="server" Text="Tipo de persona"></asp:Label>
                &nbsp;<asp:DropDownList ID="ddl_tipo_persona" CssClass="form-control" runat="server">
            </asp:DropDownList>

            </div>
           

            <div class="form-group">
            <asp:Label ID="Label4" runat="server" Text="ID Plan"></asp:Label>
                &nbsp;<asp:DropDownList ID="ddl_id_plan" CssClass="form-control" runat="server">
            </asp:DropDownList>

            </div>


            
           
                <br />


            
           
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
