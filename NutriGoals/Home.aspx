<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NutriGoals.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">

        <!-- RESUMEN -->
        <div class="card mb-4">
            <div class="card-header fw-bold">
                Resumen diario
            </div>
            <div class="card-body">

                <div class="row mb-2 text-muted fw-bold">
                    <div class="col-md-3"></div>
                    <div class="col-md-3">Consumido</div>
                    <div class="col-md-3">Objetivo</div>
                    <div class="col-md-3">Ejercicio</div>
                </div>

                <div class="row mb-3">
                    <div class="col-md-3 fw-bold">Calorías (kcal)</div>
                    <div class="col-md-3">
                        <asp:Label ID="LabCaloriasTotales" runat="server" />
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="LabCaloriasObjetivo" runat="server" />
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="LabCaloriasEjercicios" runat="server" />
                    </div>
                </div>

                <div class="row mb-2">
                    <div class="col-md-3 fw-bold">Proteínas (g)</div>
                    <div class="col-md-3">
                        <asp:Label ID="LabProteinasTotales" runat="server" />
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="LabProteinasObjetivo" runat="server" />
                    </div>
                </div>

                <div class="row mb-2">
                    <div class="col-md-3 fw-bold">Carbohidratos (g)</div>
                    <div class="col-md-3">
                        <asp:Label ID="LabCarbohidratosTotales" runat="server" />
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="LabCarbohidratosObjetivo" runat="server" />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-3 fw-bold">Grasas (g)</div>
                    <div class="col-md-3">
                        <asp:Label ID="LabGrasasTotales" runat="server" />
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="LabGrasasObjetivo" runat="server" />
                    </div>
                </div>
            </div>
        </div>

        <!-- LISTAS -->
        <div class="row">

            <!-- CONSUMO -->
            <div class="col-md-6 mb-4">
                <div class="card h-100">
                    <div class="card-header fw-bold">
                        Consumo de hoy
                    </div>
                    <div class="card-body p-0">
                        <asp:Repeater runat="server" ID="listaConsumidoHoy">
                            <HeaderTemplate>
                                <table class="table table-sm table-striped mb-0">
                                    <thead>
                                        <tr>
                                            <th>Hora</th>
                                            <th>Cantidad</th>
                                            <th>Alimento</th>
                                            <th>Cal</th>
                                            <th>Prot</th>
                                            <th>Carb</th>
                                            <th>Grasa</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>

                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Hora") %></td>
                                    <td><%# Eval("Cantidad") %></td>
                                    <td><%# Eval("Alimento") %></td>
                                    <td><%# Eval("Calorias") %></td>
                                    <td><%# Eval("Proteinas") %></td>
                                    <td><%# Eval("Carbohidratos") %></td>
                                    <td><%# Eval("Grasas") %></td>
                                </tr>
                            </ItemTemplate>

                            <FooterTemplate>
                                    </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>

            <!-- EJERCICIO -->
            <div class="col-md-6 mb-4">
                <div class="card h-100">
                    <div class="card-header fw-bold">
                        Ejercicio de hoy
                    </div>
                    <div class="card-body p-0">
                        <asp:Repeater runat="server" ID="listaActividadesHoy">
                            <HeaderTemplate>
                                <table class="table table-sm table-striped mb-0">
                                    <thead>
                                        <tr>
                                            <th>Hora</th>
                                            <th>Ejercicio</th>
                                            <th>Duración</th>
                                            <th>Calorías</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>

                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Hora") %></td>
                                    <td><%# Eval("Ejercicio") %></td>
                                    <td><%# Eval("Duracion") %></td>
                                    <td><%# Eval("Calorias") %></td>
                                </tr>
                            </ItemTemplate>

                            <FooterTemplate>
                                    </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>




<%--<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="NutriGoals.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div>
        <h3>Home</h3>
        <table>
            <tr>
                <td style="text-align: left; width: 120px">Calorias:</td>
                <td style="text-align: left; width: 100px">
                    <asp:Label ID="LabCaloriasTotales" runat="server" Text=""></asp:Label></td>
                <td>
                    <asp:Label ID="LabCaloriasObjetivo" runat="server" Text=""></asp:Label></td>
                <td>
                    <asp:Label ID="LabCaloriasEjercicios" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="text-align: left; width: 120px">Proteinas:</td>
                <td style="text-align: left; width: 100px">
                    <asp:Label ID="LabProteinasTotales" runat="server" Text=""></asp:Label></td>
                <td>
                    <asp:Label ID="LabProteinasObjetivo" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align: left; width: 120px">Carbohidratos:</td>
                <td style="text-align: left; width: 100px">
                    <asp:Label ID="LabCarbohidratosTotales" runat="server" Text=""></asp:Label></td>
                <td>
                    <asp:Label ID="LabCarbohidratosObjetivo" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align: left; width: 120px">Grasas:</td>
                <td style="text-align: left; width: 100px">
                    <asp:Label ID="LabGrasasTotales" runat="server" Text=""></asp:Label></td>
                <td>
                    <asp:Label ID="LabGrasasObjetivo" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        <br />
        <div style="display: flex; gap:20px">
            <div>
                <h3>Consumo de hoy</h3>
                <asp:Repeater runat="server" ID="listaConsumidoHoy">
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <th>Hora</th>
                                <th>Cantidad (gr.)</th>
                                <th>Alimento</th>
                                <th>Calorias</th>
                                <th>Proteinas</th>
                                <th>Carbohidratos</th>
                                <th>Grasas</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("Hora") %></td>
                            <td><%#Eval("Cantidad") %></td>
                            <td><%#Eval("Alimento") %></td>
                            <td><%#Eval("Calorias") %></td>
                            <td><%#Eval("Proteinas") %></td>
                            <td><%#Eval("Carbohidratos") %></td>
                            <td><%#Eval("Grasas") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div>
                <h3>Ejercicio de hoy</h3>
                <asp:Repeater runat="server" ID="listaActividadesHoy">
                    <HeaderTemplate>
                        <table>
                            <tr>
                                <th>Hora</th>
                                <th>Ejercicio</th>
                                <th>Duracion</th>
                                <th>Calorias</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("Hora") %></td>
                            <td><%#Eval("Ejercicio") %></td>
                            <td><%#Eval("Duracion") %></td>
                            <td><%#Eval("Calorias") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>--%>
