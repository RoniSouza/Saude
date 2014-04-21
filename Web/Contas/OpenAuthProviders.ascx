<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenAuthProviders.ascx.cs" Inherits="Web.Contas.OpenAuthProviders" %>
<%@ Import Namespace="Microsoft.AspNet.Membership.OpenAuth" %>
<fieldset class="open-auth-providers">
    <legend>Faça logon usando outro serviço</legend>
    
    <asp:ListView runat="server" ID="providersList" ViewStateMode="Disabled">
        <ItemTemplate>
            <button type="submit" name="provider" value="<%# HttpUtility.HtmlAttributeEncode(Item<ProviderDetails>().ProviderName) %>"
                title="Faça logon usando sua <%# HttpUtility.HtmlAttributeEncode(Item<ProviderDetails>().ProviderDisplayName) %> conta.">
                <%# HttpUtility.HtmlEncode(Item<ProviderDetails>().ProviderDisplayName) %>
            </button>
        </ItemTemplate>
    
        <EmptyDataTemplate>
            <div class="message-info">
                <p>Não há serviços de autenticação externos configurados. Consulte
                     <a href="http://go.microsoft.com/fwlink/?LinkId=252803">este artigo</a> para obter detalhes sobre como configurar este aplicativo ASP.NET para suportar o registro em log por meio de serviços externos.</p>
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
</fieldset>