<%@ Page Title="Index" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Profissionais.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <h3>Profissional</h3>
    <br />
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <a runat="server" href="~/Profissionais/Adicionar">Adicionar Profissional</a>
    <br />
    <br />
    <asp:Label ID="LabelPesquisar" runat="server" Text="Pesquisar"></asp:Label>
    <br />
    <br />
    <asp:RadioButton ID="rbtNome" runat="server" Text="Nome" GroupName="SelecaoBusca" Checked="True" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RadioButton ID="rbtCodigo" runat="server" Text="Código" EnableTheming="True" GroupName="SelecaoBusca" />
    <br />
    <br />
    <asp:TextBox ID="TextBoxPesquisar" runat="server" Width="350px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" Width="123px" OnClick="btnPesquisar_Click" />
    <br />
    <br />
    <br />
    <asp:GridView ID="GridViewProfissionais" runat="server" BackColor="White" BorderColor="#3366CC"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="IdPessoa" HeaderText="Código">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFormatString="Visualizar.aspx?id={0}" DataTextField="Nome"
                HeaderText="Nome" Target="_self" Text="Nome" DataNavigateUrlFields="IdPessoa">
                <ItemStyle Width="400px" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="TelefoneFixo" HeaderText="Tel Fixo">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
            </asp:BoundField>
            <asp:BoundField DataField="TelefoneCelular" HeaderText="Tel Celular">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
            </asp:BoundField>
            <asp:BoundField DataField="CPF" HeaderText="CPF">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
            </asp:BoundField>
            <asp:BoundField DataField="DataNascimento" HeaderText="Data Nasc" DataFormatString="{0:dd/MM/yyyy}">
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="140px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
    </asp:GridView>
    <br />
    <br />
</asp:Content>


