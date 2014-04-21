<%@ Page Title="Visualizar Evolução Enfermagem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VisualizarEvolucaoEnfermagem.aspx.cs" Inherits="Web.Prontuarios.VisualizarEvolucaoEnfermagem" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
<h4>Visualizar Evolução de Enfermagem</h4>
    <asp:GridView ID="GridViewEvolucaoEnfermagem" runat="server" BackColor="White" BorderColor="#CCCCCC"
        BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" Height="48px" AllowPaging="True" PageSize="8" OnPageIndexChanging="GridViewEvolucaoEnfermagem_PageIndexChanging">
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
      <asp:Button runat="server" OnClick="Voltar" Text="Voltar" CssClass="btn btn-primary" />
</asp:Content>
