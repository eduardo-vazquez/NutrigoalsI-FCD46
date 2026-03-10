<%@ Page Title="Registrar Actividad" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarActividad.aspx.cs" Inherits="NutriGoals.RegistrarActividad" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="d-flex flex-grow-1 justify-content-center align-items-top ">
            <div class="card shadow-sm p-4 d-flex flex-row h-75 " style="min-width:700px; gap: 100px;">
                <div class="flex-fill">
                        <h3 class="text-center mb-4">Registrar nueva actividad</h3>

                        <!-- Mensaje de error o info -->
                        <asp:Label ID="mensaje" runat="server" Text="" CssClass="text-danger d-block mb-2"></asp:Label>

                        <!-- Formulario -->
                        <div class="mb-3">
                            <label for="TextBoxFechaHora" class="form-label">Fecha/Hora:</label>
                            <asp:TextBox ID="TextBoxFechaHora" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                runat="server"
                                ControlToValidate="TextBoxFechaHora"
                                ErrorMessage="Este campo es obligatorio"
                                CssClass="text-danger small"
                                Display="Dynamic" />
                        </div>

                        <div class="mb-3">
                            <label for="DropDownListEjercicios" class="form-label">Actividad:</label>
                            <asp:DropDownList ID="DropDownListEjercicios" runat="server" CssClass="form-select"
                                OnSelectedIndexChanged="DropDownListEjercicios_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:Label ID="LabelCaloriasEjercicio" runat="server" CssClass="d-block mt-1">20,00 kCal/min</asp:Label>
                        </div>

                        <div class="mb-3">
                            <label for="TextBoxDuracion" class="form-label">Duración (min):</label>
                            <asp:TextBox ID="TextBoxDuracion" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator
                                runat="server"
                                ControlToValidate="TextBoxDuracion"
                                ErrorMessage="Este campo es obligatorio"
                                CssClass="text-danger small"
                                Display="Dynamic" />
                        </div>

                        <div class="d-grid mb-4">
                            <asp:Button ID="ButtonCreaActividad" runat="server" Text="Guardar" CssClass="btn nutrigoals-btn" OnClick="ButtonCreaActividad_Click" CausesValidation="true" />
                        </div>
                    </div>

                <div class="flex-fill">
                    <!-- Últimas actividades -->
                    <h5 class="mb-2">Últimas actividades</h5>
                    <asp:Repeater runat="server" ID="ultimasActividades">
                        <HeaderTemplate>
                            <table class="table table-sm table-striped" style="text-align: center">
                                <thead class="table-light">
                                    <tr>
                                        <th>Ejercicio</th>
                                        <th>Fecha/Hora</th>
                                        <th>Duración (min)</th>
                                        <th>Calorías</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="text-align: left" ><%# Eval("Ejercicio") %></td>
                                <td><%# Eval("FechaHora") %></td>
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
</asp:Content>


<%--<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h3>Registrar nueva actividad</h3>
        <table>
            <tr>
                <td>
                    <label>Fecha/Hora:</label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxFechaHora" runat="server" TextMode="DateTime"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator
                        runat="server"
                        ControlToValidate="TextBoxDuracion"
                        ErrorMessage="Este campo es obligatorio"
                        ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td>
                    <label>Actividad:</label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListEjercicios" runat="server" Width="100px"
                        OnSelectedIndexChanged="DropDownListEjercicios_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:Label ID="LabelCaloriasEjercicio" runat="server">20,00 kCal/min</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Duracion (min):</label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxDuracion" runat="server" TextMode="Number"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator
                        runat="server"
                        ControlToValidate="TextBoxDuracion"
                        ErrorMessage="Este campo es obligatorio"
                        ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonCreaActividad" runat="server" Text="Guardar" CausesValidation="true"
                        OnClick="ButtonCreaActividad_Click" />
                </td>
            </tr>
        </table>

        <h3>Últimas actividades</h3>
        <asp:Repeater runat="server" ID="ultimasActividades">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th style="text-align: left; width: 180px">Ejercicio</th>
                        <th style="text-align: left; width: 180px">Fecha/Hora</th>
                        <th style="text-align: left; width: 130px">Duracion (min)</th>
                        <th style="text-align: left; width: 120px">Calorias Totales</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td style="width: 80px; text-align: left"><%#Eval("Ejercicio") %></td>
                    <td style="width: 80px; text-align: left"><%#Eval("FechaHora") %></td>
                    <td><%#Eval("Duracion") %></td>
                    <td><%#Eval("Calorias") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>--%>
