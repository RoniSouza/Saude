<%@ Page Title="Registro de Usuário" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Web.Contas.Registrar" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <br />
    <br />
    <br />
    <h3>Registro de Usuário</h3>
    <hr />
    <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser">
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
            <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
        </LayoutTemplate>
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">
                <ContentTemplate>
                    <p class="message-info">
                        As novas senhas devem ter, no mínimo, <%: Membership.MinRequiredPasswordLength %> caracteres.
                    </p>
                    <br />
                    <p class="validation-summary-errors">
                        <asp:Literal runat="server" ID="ErrorMessage" />
                    </p>
                    <fieldset>
                            <div>
                                <asp:Label runat="server" AssociatedControlID="UserName">Nome de usuário</asp:Label>&nbsp;&nbsp;&nbsp;
                                <asp:TextBox runat="server" ID="UserName" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName"
                                    CssClass="field-validation-error" ErrorMessage="O campo nome de usuário é obrigatório." />
                            </div>
                         <br />
                            <div>
                                <asp:Label runat="server" AssociatedControlID="Email">Endereço de email</asp:Label>
                                <asp:TextBox runat="server" ID="Email" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                    CssClass="field-validation-error" ErrorMessage="O campo endereço de email é obrigatório." />
                            </div>
                         <br />
                            <div>
                                <asp:Label runat="server" AssociatedControlID="Password">Senha</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                    CssClass="field-validation-error" ErrorMessage="O campo de senha é obrigatório." />
                            </div>
                         <br />
                            <div>
                                <asp:Label runat="server" AssociatedControlID="ConfirmPassword">Confirmar senha</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="O campo para confirmar senha é obrigatório." />
                                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                     CssClass="field-validation-error" Display="Dynamic" ErrorMessage="A senha e a senha de confirmação não coincidem." />
                            </div>
                        <br />
                        <asp:Button runat="server" CommandName="MoveNext" Text="Registrar" CssClass="btn btn-primary"/>
                    </fieldset>
                </ContentTemplate>
                <CustomNavigationTemplate />
            </asp:CreateUserWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
</asp:Content>