<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InserirEvolucaoEnfermagem.aspx.cs" Inherits="Web.Prontuarios.EvolucaoEnfermagem" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <h4>Evolução Enfermagem</h4>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <br />
    <asp:GridView ID="GridViewEvolucaoEnfermagem" runat="server" BackColor="White" BorderColor="#CCCCCC"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" Height="48px" AllowPaging="True" PageSize="7" OnPageIndexChanging="GridViewEvolucaoEnfermagem_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="DataCadastro" HeaderText="Data Cadastro">
                <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="FrequenciaCardiaca" HeaderText="Frequência Cardiaca">
                <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="PressaoArterial" HeaderText="Pressão Arterial">
                <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="Respiracao" HeaderText="Respiração">
                <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="Temperatura" HeaderText="Temperatura">
                <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="Observacoes" HeaderText="Observações">
                <ItemStyle Width="200px" />
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
        <div class="col-xs-5">
            <asp:Label runat="server">Frequência Cardiaca</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxFrequenciaCardiaca" CssClass="form-control" />
        </div>
        <div class="col-xs-5">
            <asp:Label runat="server">Pressão Arterial</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxPressaoArterial" CssClass="form-control" />
        </div>
        <div class="col-xs-5">
            <asp:Label runat="server">Respiração</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxRespiracao" CssClass="form-control" />
        </div>
        <div class="col-xs-5">
            <asp:Label runat="server">Temperatura</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxTemperatura" CssClass="form-control" />
        </div>
        <div class="col-xs-10">
            <asp:Label runat="server">Observações</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxObservacoes" CssClass="form-control" />
        </div>
    </div>
    <br />
    <br />
    <asp:Button runat="server" OnClick="Inserir" OnClientClick="return confirm('Você realmente deseja salvar este registro?');" Text="Inserir" CssClass="btn btn-primary" />
    <asp:Button runat="server" OnClick="Voltar" Text="Voltar" CssClass="btn btn-primary" />
</asp:Content>
