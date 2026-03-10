<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarAlimento.aspx.cs" Inherits="NutriGoals.RegistrarAlimento" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   
        <div>
            <h1>Resgistrar Alimentos Consumidos</h1>
            <p>&nbsp;</p>
            <p>Alimento&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txbCodigoAlimento" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
                <asp:Button ID="btnBuscaAlimento" runat="server" OnClick="btnBuscaAlimento_Click" Text="Buscar" />
            </p>
            <p>
               <h5> <asp:Label ID="lblNomProducto" runat="server" Text="Nombre"></asp:Label> 
            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMarca" runat="server" Text=""></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Código:
                <asp:Label ID="lblCodigoOFF" runat="server" Text=""></asp:Label></h5>
            </p>
            <p>
                <asp:Label ID="lblCalorias" runat="server" Text="Calorías"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblProteinas" runat="server" Text="Proteínas"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblCarbohidratos" runat="server" Text="Carbohidratos"></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblGrasa" runat="server" Text="Grasa"></asp:Label>
            </p>
            <p>
                <asp:Image ID="imgProducto" runat="server" Width="200px"/>
            </p>
            <p>Cantidad (gramos)&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txbCantidad" runat="server" Width="63px" OnTextChanged="txbCantidad_TextChanged"></asp:TextBox>
            &nbsp;
            </p>
            <p>Fecha/Hora&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:TextBox ID="txbFechaHora" runat="server" TextMode="DateTime"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnRegistraAlim" runat="server" OnClick="btnRegistraAlim_Click" Text="Registrar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMensajeError" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMensajeError2" runat="server" Text="Label"></asp:Label>
            </p>
            <p>&nbsp;</p>
        </div>

     <div class="flex-fill">
     <!-- Últimas actividades -->
     <h5 class="mb-2">Últimos alimentos registrados</h5>
     <asp:Repeater runat="server" ID="ultimosIngeridos">
         <HeaderTemplate>
             <table class="table table-sm table-striped">
                 <thead class="table-light">
                     <tr>
                         <th>Alimento</th>
                         <th>Fecha/Hora</th>
                         <th>Cantidad (gramos)</th>
                         <th>Calorías</th>
                          <th>Código Barras</th>
                     </tr>
                 </thead>
                 <tbody>
         </HeaderTemplate>
         <ItemTemplate>
             <tr>
                 <td><%# Eval("Alimento") %></td>
                 <td><%# Eval("FechaHora") %></td>
                 <td><%# Eval("Cantidad") %></td>
                 <td><%# Eval("Calorias") %></td>
                 <td><%# Eval("Codigo") %></td>
             </tr>
         </ItemTemplate>
         <FooterTemplate>
                 </tbody>
             </table>
         </FooterTemplate>
     </asp:Repeater>
 </div>
 
</asp:Content>


