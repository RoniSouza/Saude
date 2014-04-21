<%@ Page Title="Cadastro de Produto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Adicionar.aspx.cs" Inherits="Web.Produtos.Adicionar" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/Javascript" src="../Scripts/jquery.maskedinput-1.3.1.min.js"></script>
    <script type="text/Javascript" src="../Scripts/Mascara.js"></script>
    <br />
    <br />
    <br />
    <h3>Cadastro de Produto</h3>
    <hr />
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="row">
        <div class="col-xs-4">
            <asp:Label runat="server">Nome</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxNome" required="true" class="form-control" />
        </div>
        <div class="col-xs-6">
            <asp:Label runat="server">Descrição</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxDescricao" required="true" class="form-control" />
        </div>
        <div class="col-xs-4">
            <asp:Label runat="server">Fabricante</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxFabricante" required="true" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Preço</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxPreco" required="true" onkeyup="formataValor(this,event);" Style="text-align: right" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Lote</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxLote" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Data Fabricação</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxDataFabricacao" MaxLength="7" onkeyup="formataMesAno(this,event);" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Data Vencimento</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxDataValidade" MaxLength="7" onkeyup="formataMesAno(this,event);" class="form-control" />
        </div>
    </div>
    <br />
    <div>
        <asp:Button runat="server" OnClick="Inserir" Text="Cadastrar" CssClass="btn btn-primary" />
        <asp:Button runat="server" onClientClick="history.back(-1); return false;" Text="Voltar" CssClass="btn btn-primary" />
    </div>
</asp:Content>
