<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NutriGoals.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center vh-100">
        <div class="card shadow-sm p-4" style="min-width: 350px;">
            <h3 class="text-center mb-4">Login</h3>

            <asp:Label ID="mensaje" runat="server" Text="" CssClass="text-danger d-block mb-2"></asp:Label>

            <div class="mb-3">
                <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="form-control" Placeholder="Email"></asp:TextBox>
                <asp:RegularExpressionValidator
                    runat="server"
                    ControlToValidate="TextBoxEmail"
                    ValidationExpression="^[^@]+@[^@]+\.[a-zA-Z]{2,}$"
                    ErrorMessage="Email no válido"
                    CssClass="text-danger small"
                    Display="Dynamic" />
            </div>

            <div class="mb-3">
                <asp:TextBox ID="TextBoxPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Password"></asp:TextBox>
            </div>
            <!--
            <div class="d-flex justify-content-between mb-3">
                <div class="form-check">
                    <asp:CheckBox ID="CheckBoxRemember" runat="server" CssClass="form-check-input" />
                    <label class="form-check-label" for="CheckBoxRemember">Recordar</label>
                </div>
                <a href="#">Password olvidado?</a>
            </div>
            -->
            <div class="d-grid">
                <asp:Button ID="ButtonLogin" runat="server" Text="Login" CssClass="btn nutrigoals-btn" OnClick="ButtonLogin_Click" CausesValidation="true" Style="background-color=" />
            </div>

            <div class="text-center mt-3">
                <a href="Registro">Registrarse</a>
            </div>
        </div>
    </div>
</asp:Content>



