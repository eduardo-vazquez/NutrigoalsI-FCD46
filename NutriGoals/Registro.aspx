<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="NutriGoals.Registro" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center vh-100">
        <div class="card shadow-sm p-4" style="min-width: 350px;">
            <h3 class="text-center mb-4">Registro</h3>

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
                <asp:TextBox ID="TextBoxPassword1" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Password"></asp:TextBox>
            </div>

            <div class="mb-3">
                <asp:TextBox ID="TextBoxPassword2" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Repetir Password"></asp:TextBox>
                <asp:CompareValidator
                    runat="server"
                    ControlToValidate="TextBoxPassword1"
                    ControlToCompare="TextBoxPassword2"
                    ErrorMessage="Las contraseñas no coinciden"
                    CssClass="text-danger small"
                    Display="Dynamic" />
            </div>

            <div class="d-grid">
                <asp:Button ID="ButtonRegister" runat="server" Text="Registro" CssClass="btn nutrigoals-btn" OnClick="ButtonRegister_Click" CausesValidation="true" />
            </div>

            <div class="text-center mt-3">
                <a href="Login">Login</a>
            </div>
        </div>
    </div>
</asp:Content>


<%--<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h3>Registro</h3>
        <table>
            <tr>
                <td><a href="Login">Login</a></td>
                <td>Registro</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="TextBoxEmail" runat="server" Text="email"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator
                        runat="server"
                        ControlToValidate="TextBoxEmail"
                        ValidationExpression="^[^@]+@[^@]+\.[a-zA-Z]{2,}$"
                        ErrorMessage="Email no válido"
                        ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="TextBoxPassword1" runat="server" Text="password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="TextBoxPassword2" runat="server" Text="repetir password"></asp:TextBox>
                </td>
                <td>
                    <asp:CompareValidator
                        runat="server"
                        ControlToValidate="TextBoxPassword1"
                        ControlToCompare="TextBoxPassword2"
                        ErrorMessage="Las contraseñas no coinciden"
                        ForeColor="Red" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="ButtonRegister" runat="server" Text="Registro" OnClick="ButtonRegister_Click" CausesValidation="true" />
                </td>
            </tr>
            <tr>
                <asp:Label ID="mensaje" runat="server" Text=""></asp:Label>
            </tr>

        </table>
    </div>
</asp:Content>--%>
