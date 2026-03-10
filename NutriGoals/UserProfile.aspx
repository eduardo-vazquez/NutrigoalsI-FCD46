<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="NutriGoals.UserProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex flex-grow-1 justify-content-center align-items-start mt-5">
        <div class="card shadow-sm p-4" style="min-width: 700px; max-width: 900px; width: 100%;">
            <h2 class="text-center mb-4">Perfil del Usuario</h2>

            <!-- Primera sección: Nombre y Apellidos -->
            <div class="row mb-3">
                <div class="col-md-4">
                    <asp:Label runat="server" Text="Nombre" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="usrNombre" CssClass="form-control" />
                </div>
                <div class="col-md-4">
                    <asp:Label runat="server" Text="Apellido 1" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="usrApellido1" CssClass="form-control" />
                </div>
                <div class="col-md-4">
                    <asp:Label runat="server" Text="Apellido 2" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="usrApellido2" CssClass="form-control" />
                </div>
            </div>

            <!-- Segunda sección: Fecha de nacimiento y Sexo -->
            <div class="row mb-3">
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Fecha de Nacimiento" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="usrFechaDeNacimiento" CssClass="form-control" TextMode="Date"/>
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" Text="Sexo" CssClass="form-label" />
                    <asp:DropDownList runat="server" ID="ddlSexo" CssClass="form-select">
                        <asp:ListItem Text="-- seleccionar --" Value=""></asp:ListItem>
                        <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                        <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                        <asp:ListItem Text="Otro" Value="O"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <hr />

            <!-- Tercera sección: Altura, Peso, Nivel de actividad, Objetivo -->
            <div class="row mb-4">
                <div class="col-md-3">
                    <asp:Label runat="server" Text="Altura (cm)" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="usrAltura" CssClass="form-control" />
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" Text="Peso (kg)" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="usrPeso" CssClass="form-control" />
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" Text="Nivel de actividad" CssClass="form-label" />
                    <asp:DropDownList runat="server" ID="usrNivelDeActividad" CssClass="form-select">
                        <asp:ListItem Text="Sedentario" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Ligero" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Moderado" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Activo" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Muy activo" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:Label runat="server" Text="Objetivo de Peso" CssClass="form-label" />
                    <asp:DropDownList runat="server" ID="usrObjetivo" CssClass="form-select">
                        <asp:ListItem Text="Mantener" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Bajar" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Subir" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <hr />

            <!-- Cuarta sección: Macronutrientes con porcentaje -->
            <div class="row mb-4">
                <div class="col-md-3">
                    <asp:Label runat="server" Text="Calorías/día" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtCalorias" CssClass="form-control" />
                    <small class="text-muted">
                        Ajustado según objetivo de peso (mantener ±0%, bajar -15%, subir +15%)
                    </small>
                </div>

                <div class="col-md-3">
                    <asp:Label runat="server" Text="Proteínas" CssClass="form-label" />

                    <div class="unit-group">
                        <div class="input-unit">
                            <asp:TextBox runat="server" ID="txtProteinas" CssClass="form-control" />
                            <span class="unit">g</span>
                        </div>

                        <div class="input-unit">
                            <asp:TextBox runat="server" ID="txtProteinasPct" CssClass="form-control" />
                            <span class="unit">%</span>
                        </div>
                    </div>

                    <small class="text-muted">Proteínas: g y % del total de calorías</small>
                </div>

                <div class="col-md-3">
                    <asp:Label runat="server" Text="Carbohidratos" CssClass="form-label" />

                    <div class="unit-group">
                        <div class="input-unit">
                            <asp:TextBox runat="server" ID="txtCarbohidratos" CssClass="form-control" />
                            <span class="unit">g</span>
                        </div>

                        <div class="input-unit">
                            <asp:TextBox runat="server" ID="txtCarbohidratosPct" CssClass="form-control" />
                            <span class="unit">%</span>
                        </div>
                    </div>

                    <small class="text-muted">Carbohidratos: g y % del total de calorías</small>
                </div>

                <div class="col-md-3">
                    <asp:Label runat="server" Text="Grasas" CssClass="form-label" />

                    <div class="unit-group">
                        <div class="input-unit">
                            <asp:TextBox runat="server" ID="txtGrasas" CssClass="form-control" />
                            <span class="unit">g</span>
                        </div>

                        <div class="input-unit">
                            <asp:TextBox runat="server" ID="txtGrasasPct" CssClass="form-control" />
                            <span class="unit">%</span>
                        </div>
                    </div>

                    <small class="text-muted">Grasas: g y % del total de calorías</small>
                </div>
            </div>

            <!-- Botón Guardar -->
            <div class="d-grid">
                <asp:Button runat="server" ID="btnGuardar" Text="Guardar" CssClass="btn nutrigoals-btn" OnClick="btnGuardar_Click" CausesValidation="true" />
            </div>
            <div class="d-grid">
                <asp:Button runat="server" ID="btnCerrarSesion" Text="Cerrar Sesion" CssClass="btn btn-danger" OnClick="btnCerrar_Click" CausesValidation="true" />
            </div>
        </div>
    </div>

    <script>
        function recalcularMacros() {
            var peso = parseFloat(document.getElementById('<%= usrPeso.ClientID %>').value) || 0;
            var altura = parseFloat(document.getElementById('<%= usrAltura.ClientID %>').value) || 0;
            var fechaNacimiento = document.getElementById('<%= usrFechaDeNacimiento.ClientID %>').value;
            var sexo = document.getElementById('<%= ddlSexo.ClientID %>').value;
            var nivelActividad = parseInt(document.getElementById('<%= usrNivelDeActividad.ClientID %>').value) || 0;
            var objetivo = parseInt(document.getElementById('<%= usrObjetivo.ClientID %>').value) || 0; // 0 = Mantener, 1 = Bajar, 2 = Subir

            if (peso <= 0 || altura <= 0 || !fechaNacimiento) return;

            // Calcular edad
            var hoy = new Date();
            var nacimiento = new Date(fechaNacimiento);
            var edad = hoy.getFullYear() - nacimiento.getFullYear();
            if (hoy.getMonth() < nacimiento.getMonth() ||
                (hoy.getMonth() == nacimiento.getMonth() && hoy.getDate() < nacimiento.getDate())) {
                edad--;
            }

            // Calculo TMB
            var tmb = 0;
            if (sexo === 'M') {
                tmb = 10 * peso + 6.25 * altura - 5 * edad + 5;
            } else if (sexo === 'F') {
                tmb = 10 * peso + 6.25 * altura - 5 * edad - 161;
            }

            // Factor actividad
            var factor = [1.2, 1.375, 1.55, 1.725, 1.9][nivelActividad] || 1.2;
            var calorias = tmb * factor;

            // Ajuste según objetivo
            if (objetivo === 1) { // Bajar
                calorias *= 0.85;
            } else if (objetivo === 2) { // Subir
                calorias *= 1.15;
            }

            // Macronutrientes
            var proteinas = peso * 1.6; // g
            var grasas = calorias * 0.25 / 9; // 25% calorías de grasa
            var carbs = (calorias - (proteinas * 4 + grasas * 9)) / 4; // resto de calorías

            // Actualizar TextBox
            document.getElementById('<%= txtCalorias.ClientID %>').value = Math.round(calorias);
            document.getElementById('<%= txtProteinas.ClientID %>').value = Math.round(proteinas);
            document.getElementById('<%= txtGrasas.ClientID %>').value = Math.round(grasas);
            document.getElementById('<%= txtCarbohidratos.ClientID %>').value = Math.round(carbs);
        }

        // Asignar eventos
        document.getElementById('<%= usrPeso.ClientID %>').addEventListener('input', recalcularMacros);
        document.getElementById('<%= usrAltura.ClientID %>').addEventListener('input', recalcularMacros);
        document.getElementById('<%= usrNivelDeActividad.ClientID %>').addEventListener('change', recalcularMacros);
        document.getElementById('<%= ddlSexo.ClientID %>').addEventListener('change', recalcularMacros);
        document.getElementById('<%= usrFechaDeNacimiento.ClientID %>').addEventListener('change', recalcularMacros);
        document.getElementById('<%= usrObjetivo.ClientID %>').addEventListener('change', recalcularMacros); // <--- agregado

        // Ejecutar al cargar página
        window.addEventListener('load', recalcularMacros);

        function recalcularMacros() {
            var peso = parseFloat(document.getElementById('<%= usrPeso.ClientID %>').value) || 0;
            var altura = parseFloat(document.getElementById('<%= usrAltura.ClientID %>').value) || 0;
            var fechaNacimiento = document.getElementById('<%= usrFechaDeNacimiento.ClientID %>').value;
            var sexo = document.getElementById('<%= ddlSexo.ClientID %>').value;
            var nivelActividad = parseInt(document.getElementById('<%= usrNivelDeActividad.ClientID %>').value) || 0;
            var objetivo = parseInt(document.getElementById('<%= usrObjetivo.ClientID %>').value) || 0;

            if (peso <= 0 || altura <= 0 || !fechaNacimiento) return;

            // Edad
            var hoy = new Date();
            var nacimiento = new Date(fechaNacimiento);
            var edad = hoy.getFullYear() - nacimiento.getFullYear();
            if (hoy.getMonth() < nacimiento.getMonth() ||
                (hoy.getMonth() == nacimiento.getMonth() && hoy.getDate() < nacimiento.getDate())) edad--;

            // TMB
            var tmb = sexo === 'M' ? 10 * peso + 6.25 * altura - 5 * edad + 5 : 10 * peso + 6.25 * altura - 5 * edad - 161;

            // Factor actividad
            var factor = [1.2, 1.375, 1.55, 1.725, 1.9][nivelActividad] || 1.2;
            var calorias = tmb * factor;

            // Ajuste objetivo
            if (objetivo === 1) calorias *= 0.85;
            if (objetivo === 2) calorias *= 1.15;

            // Obtener porcentajes actuales
            var protPct = parseFloat(document.getElementById('<%= txtProteinasPct.ClientID %>').value) || 0;
            var carbPct = parseFloat(document.getElementById('<%= txtCarbohidratosPct.ClientID %>').value) || 0;
            var fatPct = parseFloat(document.getElementById('<%= txtGrasasPct.ClientID %>').value) || 0;

            var totalPct = protPct + carbPct + fatPct;
            if (totalPct > 0) {
                // Si el usuario cambió los porcentajes, recalcular gramos
                document.getElementById('<%= txtProteinas.ClientID %>').value = Math.round((protPct / 100) * calorias / 4);
                document.getElementById('<%= txtCarbohidratos.ClientID %>').value = Math.round((carbPct / 100) * calorias / 4);
                document.getElementById('<%= txtGrasas.ClientID %>').value = Math.round((fatPct / 100) * calorias / 9);
            } else {
                // Si no hay porcentaje manual, usar valores por defecto
                var proteinas = peso * 1.6;
                var grasas = calorias * 0.25 / 9;
                var carbs = (calorias - (proteinas * 4 + grasas * 9)) / 4;

                document.getElementById('<%= txtProteinas.ClientID %>').value = Math.round(proteinas);
                document.getElementById('<%= txtCarbohidratos.ClientID %>').value = Math.round(carbs);
                document.getElementById('<%= txtGrasas.ClientID %>').value = Math.round(grasas);

                document.getElementById('<%= txtProteinasPct.ClientID %>').value = Math.round(proteinas*4/calorias*100);
                document.getElementById('<%= txtCarbohidratosPct.ClientID %>').value = Math.round(carbs*4/calorias*100);
                document.getElementById('<%= txtGrasasPct.ClientID %>').value = Math.round(grasas*9/calorias*100);
            }

            // Actualizar calorías
            document.getElementById('<%= txtCalorias.ClientID %>').value = Math.round(calorias);
        }

        // Asignar eventos de manera explícita
        var campos = [
            '<%= usrPeso.ClientID %>',
            '<%= usrAltura.ClientID %>',
            '<%= usrNivelDeActividad.ClientID %>',
            '<%= ddlSexo.ClientID %>',
            '<%= usrFechaDeNacimiento.ClientID %>',
            '<%= usrObjetivo.ClientID %>',
            '<%= txtProteinas.ClientID %>',
            '<%= txtCarbohidratos.ClientID %>',
            '<%= txtGrasas.ClientID %>',
            '<%= txtProteinasPct.ClientID %>',
            '<%= txtCarbohidratosPct.ClientID %>',
                '<%= txtGrasasPct.ClientID %>'
        ];

        campos.forEach(function (campo) {
            document.getElementById(campo).addEventListener('input', recalcularMacros);
        });

        // Ejecutar al cargar página
        window.addEventListener('load', recalcularMacros);
    </script>
</asp:Content>

