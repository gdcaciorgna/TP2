<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InscribirAlumnosACursos.aspx.cs" Inherits="UI.Web.InscribirAlumnosACursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:DropDownList ID="ddl_Cursos" runat="server">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click1" />
    <asp:GridView ID="dgv_AlumnosPorCurso" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay inscripciones realizadas" ShowHeaderWhenEmpty="True" CssClass="table table-striped table-bordered table-hover" DataKeyNames="ID" OnSelectedIndexChanged="dgv_AlumnosPorCurso_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID Inscripcion" />
            <asp:BoundField DataField="Alumno" HeaderText="Alumno" />
            <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
            <asp:BoundField DataField="Nota" HeaderText="Nota" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>

        <asp:Panel ID="Panel1" runat="server">
            <asp:LinkButton ID="lbNuevo" runat="server" CssClass="btn btn-success" OnClick="lbNuevo_Click">Nuevo</asp:LinkButton>
            <asp:Button ID="btnEditar2" runat="server" CssClass="btn btn-warning" OnClick="btnEditar2_Click1" Text="Editar" />
            <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-danger" OnClick="btnEliminar2_Click">Eliminar</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="formPanel" runat="server" Visible="False">
        <br />
        <div class="container">
            <div class="form-group">
            <asp:Label ID="labelAlumno" runat="server" Text="Alumno"></asp:Label>
                <asp:DropDownList ID="ddl_Alumno" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>
           

             <div class="form-group">
            <asp:Label ID="lbCondicion" runat="server" Text="Condicion"></asp:Label>
            <asp:TextBox ID="tbCondicion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
            <asp:Label ID="lbNota" runat="server" Text="Nota"></asp:Label>
            <asp:TextBox ID="tbNota" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
            </div>

                <br />


                <asp:LinkButton ID="lbAceptar" runat="server" CssClass="btn btn-primary" OnClick="lbAceptar_Click1">Aceptar</asp:LinkButton>
                <asp:LinkButton ID="lbCancelar" runat="server"  CssClass="btn btn-secondary" OnClick="lbCancelar_Click">Cancelar</asp:LinkButton>

     
            <asp:Panel ID="Panel2" runat="server">
            </asp:Panel>
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
