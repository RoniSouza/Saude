<%@ Page Title="Index" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Web.Pacientes.Index" EnableEventValidation="false" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <h3>Paciente</h3>
    <br />
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <a runat="server" href="~/Pacientes/Adicionar">Adicionar Paciente</a>
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
    <asp:GridView ID="GridViewPacientes" runat="server" BackColor="White" BorderColor="#3366CC"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridViewPacientes_PageIndexChanging" PageSize="5">
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
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="130px" />
            </asp:BoundField>
            <asp:BoundField DataField="DataNascimento" HeaderText="Data Nasc" DataFormatString="{0:dd/MM/yyyy}">
                <ItemStyle Width="120px" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerSettings FirstPageText="" LastPageText="" NextPageText="" PreviousPageText="" NextPageImageUrl="~/Images/avancar.png" PreviousPageImageUrl="~/Images/voltar.png" Mode="NextPreviousFirstLast" />
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
</asp:Content>
