<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Mobile.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Mobile.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <h3>Login </h3>
    <hr />
    <br />
    <br />
    <section id="loginForm">
        <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false">
            <LayoutTemplate>
                <p class="validation-summary-errors">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
                <fieldset>
                    <div>
                        <asp:Label runat="server" AssociatedControlID="UserName">Usuário</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox runat="server" ID="UserName" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="O campo nome de usuário é obrigatório." />
                    </div>
                    <br />
                    <div>
                        <asp:Label runat="server" AssociatedControlID="Password">Senha</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="O campo de senha é obrigatório." />
                    </div>
                    <br />
                    <div>
                        <asp:Label runat="server" AssociatedControlID="RememberMe">Lembrar-me?</asp:Label>
                        <asp:CheckBox runat="server" ID="RememberMe" />
                    </div>
                    <br />
                    <asp:Button runat="server" CommandName="Login" Text="Entrar" CssClass="btn btn-primary" />
                </fieldset>
            </LayoutTemplate>
        </asp:Login>
        <br />
        <br />
    </section>
</asp:Content>
