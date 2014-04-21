<%@ Page Title="Inserir Prescrição Médica" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InserirPrescricaoMedica.aspx.cs" Inherits="Web.Prontuarios.InserirPrescricaoMedica" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/Javascript" src="../Scripts/jquery.maskedinput-1.3.1.min.js"></script>
    <script type="text/Javascript" src="../Scripts/Mascara.js"></script>
    <script type="text/Javascript" src="../Scripts/MascaraValidacao.js"></script>
    <br />
    <br />
    <br />
    <h4>Inserir Prescrição Médica</h4>
    <br />
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div>
        <h4>Nome do Paciente: <span style="color: Red;">
            <asp:Label ID="nome" runat="server"></asp:Label></span> &nbsp;&nbsp;&nbsp;&nbsp;Leito:
            <span style="color: Red;">
                <asp:Label ID="leito" runat="server"></asp:Label></span>
        </h4>
    </div>
    <br />
    <asp:GridView ID="GridViewPrescricaoMedica" runat="server" BackColor="White" BorderColor="#3366CC"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" Height="48px" AllowPaging="True" OnPageIndexChanging="GridViewPrescricaoMedica_PageIndexChanging" PageSize="6">
        <Columns>
            <asp:BoundField DataField="DataCadastro" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Data Cadastro">
                <ItemStyle Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="Tipo" HeaderText="Tipo">
                <ItemStyle Width="130px" />
            </asp:BoundField>
            <asp:BoundField DataField="Descricao" HeaderText="Descrição">
                <ItemStyle Width="510px" />
            </asp:BoundField>
            <asp:BoundField DataField="Horario" HeaderText="Horário" DataFormatString="{0:dd/MM/yyyy HH:mm}" >
                <ItemStyle Width="150px" />
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
        <div class="col-xs-7">
            <asp:Label runat="server">Selecione o Tipo:</asp:Label>
        </div>
        <br />
        <br />
        <div class="col-xs-7">
            <asp:RadioButton ID="rbtMedicacao" runat="server" Text="Medicação" EnableTheming="True" Checked="True" GroupName="SelecaoBusca" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:RadioButton ID="rbtDadosVitais" runat="server" Text="Dados Vitais" GroupName="SelecaoBusca" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="rbtCuidados" runat="server" Text="Cuidados" EnableTheming="True" GroupName="SelecaoBusca" />
        </div>
        <br />
        <br />
        <div class="col-xs-6">
            <asp:Label runat="server">Descrição</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxDescricao" CssClass="form-control" />
        </div>
        <div class="col-xs-2">
            <asp:Label runat="server">Quantidade Dias</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxQtdDias" MaxLength="3" onkeyup="formataInteiro(this,event);" CssClass="form-control" />
        </div>
        <div class="col-xs-2">
            <asp:Label runat="server">Intervalo</asp:Label>
            <asp:DropDownList ID="DropDownListHora" class="form-control" runat="server">
                <asp:ListItem Text="1/1h" Value="1" />
                <asp:ListItem Text="2/2h" Value="2" />
                <asp:ListItem Text="3/3h" Value="3" />
                <asp:ListItem Text="4/4h" Value="4" />
                <asp:ListItem Text="5/5h" Value="5" />
                <asp:ListItem Text="6/6h" Value="6" />
                <asp:ListItem Text="7/7h" Value="7" />
                <asp:ListItem Text="8/8h" Value="8" />
                <asp:ListItem Text="9/9h" Value="9" />
                <asp:ListItem Text="10/10h" Value="10" />
                <asp:ListItem Text="11/11h" Value="11" />
                <asp:ListItem Text="12/12h" Value="12" />
            </asp:DropDownList>
        </div>
        <div class="col-xs-2">
            <asp:Label runat="server">Hora Inicial</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxHoraInicial" MaxLength="5" onkeyup="formataHora(this,event);" CssClass="form-control" />
        </div>
    </div>
    <br />
    <asp:Button runat="server" OnClick="Inserir" OnClientClick="return confirm('Deseja realmente salvar este registro?');" Text="Inserir" CssClass="btn btn-primary" />
    <asp:Button runat="server" OnClick="Voltar" Text="Voltar" CssClass="btn btn-primary" />
</asp:Content>
