<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DesempenhoServidor.aspx.cs" Inherits="Web.Administrador.DesempenhoServidor" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <div>
        <h2>Status do Sistema +Saúde</h2>
        <i>Estatísticas geradas em <%=DateTime.Now.ToLongDateString() %> at <%=DateTime.Now.ToLongTimeString()%></i>
        <br />
        <br />
        <b>Disponível: </b><asp:Label ID="Label1" runat="server" Width="251px"></asp:Label>
        <br />
        <b>
            <br />
            Total de Processos: </b>
        <asp:Label ID="Label2" runat="server" Width="247px"></asp:Label>
        <br />
        <br />
        <b>Total de Threding: </b><asp:Label ID="Label3" runat="server" Width="254px"></asp:Label>
        <br />
        <br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Height="300px" Width="900px"></asp:ListBox><br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>
