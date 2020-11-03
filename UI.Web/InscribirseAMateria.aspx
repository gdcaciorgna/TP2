<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InscribirseAMateria.aspx.cs" Inherits="UI.Web.InscribirseAMateria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <br />
    <h1>Mis inscripciones</h1>
    <asp:DropDownList ID="ddl_anioCalendario" runat="server">
    </asp:DropDownList>
    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
    <asp:GridView ID="dgv_InscripcionesACurso" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" DataKeyNames="ID" EmptyDataText="No hay inscripciones cargadas" OnSelectedIndexChanged="dgv_InscripcionesACurso_SelectedIndexChanged" ShowHeaderWhenEmpty="True">
        <Columns>
            <asp:BoundField DataField="DescCurso" HeaderText="Curso" />
            <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
            <asp:BoundField DataField="Nota" HeaderText="Nota" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>

    <asp:Panel ID="Panel1" runat="server">
    <asp:LinkButton ID="lbNuevo" runat="server" CssClass="btn btn-success" OnClick="lbNuevo_Click"> Nuevo</asp:LinkButton>
    <asp:Button ID="btnEditar2" runat="server" CssClass="btn btn-warning" Text="Editar" OnClick="btnEditar2_Click" />
    <asp:LinkButton ID="btnEliminar" runat="server" CssClass="btn btn-danger" OnClick="btnEliminar_Click">Eliminar</asp:LinkButton>
    </asp:Panel>

        <asp:Panel ID="formPanel" runat="server" Visible="False">
        <br />


        <div class="container">

            <div class="form-group">
            <asp:Label ID="label1" runat="server" Text="Materia"></asp:Label>
                <asp:DropDownList ID="ddl_Materia" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>

            <div class="form-group">
            <asp:Label ID="labelAnio" runat="server" Text="Año calendario"></asp:Label>
                <asp:DropDownList ID="ddl_Anio" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>


            <div class="form-group">
            <asp:Label ID="labelCurso" runat="server" Text="Comision"></asp:Label>
                <asp:DropDownList ID="ddl_Comision" runat="server" CssClass="form-control">
                </asp:DropDownList>
            </div>
           
            <div class="form-group">
            <asp:Label ID="label2" runat="server" Text="Curso"></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Enabled="False">
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


                <asp:LinkButton ID="lbAceptar" runat="server" CssClass="btn btn-primary" OnClick="lbAceptar_Click" >Aceptar</asp:LinkButton>
                <asp:LinkButton ID="lbCancelar" runat="server"  CssClass="btn btn-secondary" OnClick="lbCancelar_Click" >Cancelar</asp:LinkButton>

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
