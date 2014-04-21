<%@ Page Title="Estoque" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estoque.aspx.cs" Inherits="Web.Produtos.Estoque" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <h3>Estoque</h3>
    <hr />
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <br />
    <asp:GridView ID="GridViewProdutos" runat="server" BackColor="White" BorderColor="#3366CC"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="IdProduto" HeaderText="Código">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
            </asp:BoundField>
            <asp:BoundField DataField="Nome" HeaderText="Nome">
                 <ItemStyle Width="350px" />
            </asp:BoundField>
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
    <br />
    <div class="row">
        <div class="col-xs-4">
            <asp:Label runat="server">Digite a Quantidade</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxQuantidade" class="form-control" />
        </div>
    </div>
    <br />
    <div>
        <asp:Button runat="server" OnClick="Entrada" Text="Entrada" CssClass="btn btn-primary" />
        <asp:Button runat="server" OnClick="Saida" Text="Saída" CssClass="btn btn-primary" />
        <asp:Button runat="server" OnClick="Voltar" Text="Voltar" CssClass="btn btn-primary" />
    </div>
</asp:Content>
