<%@ Page Title="Visualizar Evolução Médica" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VisualizarEvolucaoMedica.aspx.cs" Inherits="Web.Prontuarios.VisualizarEvolucaoMedica" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <h4>Visualizar Evolução Médica</h4>
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
   <asp:Button runat="server" OnClick="Voltar" Text="Voltar" CssClass="btn btn-primary" />
</asp:Content>
