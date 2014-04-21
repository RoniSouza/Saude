<%@ Page Title="Index" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Produtos.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <h3>Produto</h3>
    <br />
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <a runat="server" href="~/Produtos/Adicionar">Adicionar Produto</a>
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
    <asp:GridView ID="GridViewProdutos" runat="server" BackColor="White" BorderColor="#3366CC"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="IdProduto" HeaderText="Código">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFormatString="Visualizar.aspx?id={0}" DataTextField="Nome"
                HeaderText="Nome" Target="_self" Text="Nome" DataNavigateUrlFields="IdProduto">
                <ItemStyle Width="350px" />
            </asp:HyperLinkField>
            <asp:BoundField DataField="Descricao" HeaderText="Descrição">
                <ItemStyle Width="300px" />
            </asp:BoundField>
            <asp:BoundField DataField="Fabricante" HeaderText="Fabricante">
                <ItemStyle Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="Quantidade" HeaderText="Estoque">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
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
</asp:Content>
