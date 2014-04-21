<%@ Page Title="Prontuário do Paciente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Prontuarios.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <h3>Prontuário do Paciente</h3>
    <hr />
    <br />
    <h4>Visualizar Informações:</h4>
    <br />
    <asp:Button runat="server" OnClick="VisualizarPrescricaoMedica" Text="Prescrição Médica" CssClass="btn btn-primary" />
    <asp:Button runat="server" OnClick="VisualizarPrescricaoEnfermagem" Text="Prescrição Enfermagem" CssClass="btn btn-primary" />
    <%--<asp:Button runat="server" OnClick="VisualizarEvolucaoEnfermagem" Text="Evolução Enfermagem" CssClass="btn btn-primary" />--%>
    <%--<asp:Button runat="server" OnClick="VisualizarEvolucaoMedica" Text="Evolução Médica" CssClass="btn btn-primary" />--%>
    <br />
    <br />
    <br />
    <br />
    <h4>Dados do Paciente</h4>

    <br />
    <asp:GridView ID="GridViewPacientes" runat="server" BackColor="White" BorderColor="#3366CC"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="IdPessoa" HeaderText="Código">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="90px" />
            </asp:BoundField>
            <asp:BoundField DataField="Nome" HeaderText="Nome">
                <ItemStyle Width="350px" />
            </asp:BoundField>
            <asp:BoundField DataField="Mae" HeaderText="Mãe">
                <ItemStyle Width="350px" />
            </asp:BoundField>
            <asp:BoundField DataField="DataNascimento" HeaderText="Data Nasc" DataFormatString="{0:dd/MM/yyyy}">
                <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="Sexo" HeaderText="Sexo">
                <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
    <br />
    <br />
    <br />
    <br />
    <h4>Inserir Informações:</h4>
    <br />
    <asp:Button runat="server" OnClick="InserirPrescricaoMedica" Text="Prescrição Médica" CssClass="btn btn-primary" />
    <asp:Button runat="server" OnClick="InserirPrescricaoEnfermagem" Text="Prescrição Enfermagem" CssClass="btn btn-primary" />
    <%--<asp:Button runat="server" OnClick="InserirEvolucaoEnfermagem" Text="Evolução Enfermagem" CssClass="btn btn-primary" />--%>
    <%--<asp:Button runat="server" OnClick="InserirEvolucaoMedica" Text="Evolução Médica" CssClass="btn btn-primary" />--%>
    <asp:Button runat="server" OnClick="Voltar" Text="Voltar" CssClass="btn btn-primary" />
</asp:Content>

