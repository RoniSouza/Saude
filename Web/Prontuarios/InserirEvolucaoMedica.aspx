<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InserirEvolucaoMedica.aspx.cs" Inherits="Web.Prontuarios.EvolucaoMedica" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <h4>Evolução Médica</h4>
    <hr />
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <br />
     <asp:GridView ID="GridViewEvolucaoMedica" runat="server" BackColor="White" BorderColor="#CCCCCC"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" Height="48px" AllowPaging="True" PageSize="8" OnPageIndexChanging="GridViewEvolucaoMedica_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="DataCadastro" HeaderText="Data Cadastro">
                <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="EvolucaoMedica" HeaderText="Evolucao Médica">
                <ItemStyle Width="500px" />
            </asp:BoundField>
            <asp:BoundField DataField="Observacoes" HeaderText="Observações">
                <ItemStyle Width="500px" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerSettings Mode="NextPreviousFirstLast" FirstPageText="" LastPageText="" NextPageText="Próxima" PreviousPageText="Voltar" NextPageImageUrl="~/Images/avancar.png" PreviousPageImageUrl="~/Images/voltar.png" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
    <br />
    <div class="row">
        <div class="col-xs-8">
            <asp:Label runat="server">Evolução Médica</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxEvolucaoMedica" CssClass="form-control" />
        </div>
        <div class="col-xs-8">
            <asp:Label runat="server">Observações</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxObservacoes" CssClass="form-control" />
        </div>
    </div>
    <br />
    <br />
    <asp:Button runat="server" OnClick="Inserir" OnClientClick="return confirm('Você realmente deseja salvar este registro?');" Text="Inserir" CssClass="btn btn-primary" />
    <asp:Button runat="server" OnClick="Voltar" Text="Voltar" CssClass="btn btn-primary" />
</asp:Content>
