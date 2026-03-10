<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recetas.aspx.cs" Inherits="NutriGoals.Recetas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h3>Recetas</h3>
        <table>
            <tr>
                <td>
                    <asp:Label ID="LabelBuscar" runat="server" Text="Buscar:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxBusca" runat="server" OnTextChanged="ButtonBuscar_Click"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Repeater runat="server" ID="listaRecetasBuscadas">
            <HeaderTemplate>
                <table>
                    <h3>Recetas encontradas</h3>
                    <tr>
                        <th></th>
                        <th>Nombre</th>
                        <th>Calorias (100gr.)</th>
                        <th>Proteinas (100gr.)</th>
                        <th>Carbohidratos (100gr.)</th>
                        <th>Grasas (100gr.)</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><a href='Recetas.aspx?id=<%#Eval("IdReceta")%>'>Ver detalle</a></td>
                    <td><%#Eval("Nombre") %></td>
                    <td><%#Eval("Calorias100") %></td>
                    <td><%#Eval("Proteinas100") %></td>
                    <td><%#Eval("Carbohidratos100") %></td>
                    <td><%#Eval("Grasas100") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <asp:Label ID="LabelReceta" runat="server" Text="" Font-Bold="true" Font-Size="30px" Visible="false"></asp:Label>
        <asp:Repeater runat="server" ID="listaAlimentosReceta" Visible="false">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>Nombre</th>
                        <th>Cantidad (gr.)</th>
                        <th>Calorias (100gr.)</th>
                        <th>Proteinas (100gr.)</th>
                        <th>Carbohidratos (100gr.)</th>
                        <th>Grasas (100gr.)</th>
                        <th>Codigo de barras</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("Nombre") %></td>
                    <td><%#Eval("CantidadGR") %></td>
                    <td><%#Eval("Calorias100") %></td>
                    <td><%#Eval("Proteinas100") %></td>
                    <td><%#Eval("Carbohidratos100") %></td>
                    <td><%#Eval("Grasas100") %></td>
                    <td><%#Eval("CodigoBarras") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="LabelCantidad" runat="server" Text="Cantidad (gr.):" Visible="false"></asp:Label>
        <asp:TextBox ID="TextBoxCantidad" runat="server" Width="100px" TextMode="Number" Visible="false" />
        <asp:Label ID="LabelFechaHora" runat="server" Text="Fecha/Hora:" Visible="false" />
        <asp:TextBox ID="TextFechaHora" runat="server" TextMode="DateTime" Visible="false" />
        <asp:Button ID="ButtonAñadirAlimentos" runat="server" Text="Registrar..." Visible="false" OnClick="ButtonAñadirAlimentos_Click" />
    </div>
</asp:Content>
