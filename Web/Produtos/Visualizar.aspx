<%@ Page Title="Informações do Produto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Visualizar.aspx.cs" Inherits="Web.Produtos.Visualizar" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/Javascript" src="../Scripts/jquery.maskedinput-1.3.1.min.js"></script>
    <script type="text/Javascript" src="../Scripts/Mascara.js"></script>
    <br />
    <br />
    <br />
    <h3>Informações do Produto</h3>
    <hr />
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="row">
        <div class="col-xs-2">
            <asp:Label runat="server">Código</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxCodigo" ReadOnly="true" required="true" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-xs-4">
            <asp:Label runat="server">Nome</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxNome" required="true" class="form-control" />
        </div>
        <div class="col-xs-4">
            <asp:Label runat="server">Descrição</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxDescricao" class="form-control" />
        </div>
        <div class="col-xs-4">
            <asp:Label runat="server">Fabricante</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxFabricante" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Preço</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxPreco" onkeyup="formataValor(this,event);" Style="text-align: right" required="true" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Lote</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxLote" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Data Fabricação</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxDataFabricacao" required="true"  MaxLength="7" onkeyup="formataMesAno(this,event);" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Data Validade</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxDataValidade" required="true"  MaxLength="7" onkeyup="formataMesAno(this,event);" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Quantidade</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxQuantidade" ReadOnly="True" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Data Cadastro</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxDataCadastro" ReadOnly="True" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Data Modificação</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxDataModificacao" ReadOnly="True" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Cadastrado Por</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxCadastradoPor" ReadOnly="True" class="form-control" />
        </div>
    </div>
    <br />
    <div>
        <asp:Button runat="server" OnClick="Alterar" Text="Alterar" CssClass="btn btn-primary" />
        <asp:Button runat="server" ID="BtnExcluir" OnClick="Excluir" OnClientClick="return confirm('Você tem certeza que deseja excluir este registro?');" Text="Excluir" CssClass="btn btn-primary" />
        <asp:Button runat="server" OnClick="Estoque" Text="Estoque" CssClass="btn btn-primary" />
        <asp:Button runat="server" OnClick="Voltar" Text="Voltar" CssClass="btn btn-primary" />
    </div>
</asp:Content>
