
<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscaAlimento.aspx.cs" Inherits="NutriGoals.BuscaAlimento" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <h1>Buscador de Alimentos</h1>
            <p>&nbsp;</p>
            <p>Código de Alimento&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txbCodAlimento" runat="server" Width="193px"></asp:TextBox>
            </p>
            <p>Descripción Alimento&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txbDescripAlimento" runat="server" Width="191px"></asp:TextBox>
            </p>
            <p>&nbsp;</p>
            <p>
                <asp:Button ID="btnBuscaAlimento" runat="server" OnClick="btnBuscaAlimento_Click" Text="Buscar" />
            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCargaAlimento" runat="server" OnClick="btnCargaAlimento_Click" Text="Cargar en Tabla" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
            </p>
            <p>Producto encontrado</p>
            <p>
                <asp:Label ID="lblNomProducto" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblCalorias" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblProteinas" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblCarbohidratos" runat="server" Text="Label"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblGrasa" runat="server" Text="Label"></asp:Label>
            </p>
            <asp:Image ID="imgProducto" runat="server" Width="200px" />
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
        </div>
</asp:Content>
