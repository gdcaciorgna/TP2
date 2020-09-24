<%@ Page Language="C#" Title="Login" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


<link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css">
<link href="~/resources/css/estilos.css" rel="stylesheet" type="text/css" />
<script src="~/Scripts/jquery-1.9.0.js"></script>
<script src="~/Scripts/bootstrap.min.js"></script>


<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>


    <div class="container well contenedor">

    <div class="row">
        <div class="col-xs-12">
            <h1>Iniciar sesión</h1>
        </div>
    </div>

    <form id="form1" runat="server" class="form-horizontal">
        <div class="form-group">

            <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="control-label col-sm-2"></asp:Label>
                <div class="col-lg-10">
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
        </div>

        <div class="form-group">
            <asp:Label ID="lblClave" runat="server" Text="Clave" CssClass="control-label col-sm-2"></asp:Label>
            <div class="col-lg-10">
                <asp:TextBox ID="txtClave" runat="server" CssClass="form-control"></asp:TextBox>

            </div>
        </div>


       <div class="form-group">
            <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" CssClass="form-control btn btn-primary boton-ingresar" />
       </div>
        
        <asp:LinkButton ID="lnkRecordarClave" runat="server" Text="Olvidé mi Clave" OnClick="lnkRecordarClave_Click"></asp:LinkButton>
        
        <br />
        
        <asp:Panel ID="PanelError" runat="server" CssClass="alert alert-danger" Visible="False">
            <asp:Label ID="lbTextoError" runat="server" Text="Texto error"></asp:Label>
            
        </asp:Panel>
    </form>
    </div>
</body>
</html>
