<%@ Page Title="Visualizar Prescrição de Enfermagem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VisualizarPrescricaoEnfermagem.aspx.cs" Inherits="Web.Prontuarios.VisualizarPrescricaoEnfermagem" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/Javascript" src="../Scripts/jquery.maskedinput-1.3.1.min.js"></script>
    <script type="text/Javascript" src="../Scripts/Mascara.js"></script>
    <script type="text/Javascript" src="../Scripts/MascaraValidacao.js"></script>
    <br />
    <br />
    <br />
    <div>
        <h4>Nome do Paciente: <span style="color: Red;">
            <asp:Label ID="nome" runat="server"></asp:Label></span> &nbsp;&nbsp;&nbsp;&nbsp;Leito:
            <span style="color: Red;">
                <asp:Label ID="leito" runat="server"></asp:Label></span>
        </h4>
    </div>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <br />
    <h4>Prescrições Realizadas</h4>
    <asp:GridView ID="GridViewPrescricaoEnfermagemRealizadas" runat="server" BackColor="White" BorderColor="#3366CC"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" Height="48px" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridViewPrescricaoEnfermagemRealizadas_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="Horario" DataFormatString="{0:dd/MM/yyyy HH:mm}" HeaderText="Horário">
                <ItemStyle Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="Tipo" HeaderText="Tipo">
                <ItemStyle Width="130px" />
            </asp:BoundField>
            <asp:BoundField DataField="Descricao" HeaderText="Descrição">
                <ItemStyle Width="390px" />
            </asp:BoundField>
            <asp:BoundField DataField="NomeEnfermeiro" HeaderText="Responsável">
                <ItemStyle Width="180px" />
            </asp:BoundField>
            <asp:BoundField DataField="HoraRealizacaoTarefa" HeaderText="Hora Realização">
                <ItemStyle Width="160px" HorizontalAlign="Center" VerticalAlign="Middle" />
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
    <h4>Prescrições  a serem Realizadas</h4>
    <asp:GridView ID="GridViewPrescricaoEnfermagemAFazer" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" Height="48px" AllowPaging="True" PageSize="5" OnPageIndexChanging="GridViewPrescricaoEnfermagemAFazer_PageIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="IdPrescricao" Visible="false">
                <ItemTemplate>
                    <asp:Label ID="lblIdPrescricao" runat="server" Text='<%# Eval("IdPrescricaoEnfermagem") %>'> </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
          <asp:TemplateField HeaderText="Horário">
                <ItemTemplate>
                    <asp:Label ID="lblHorario" runat="server" Text='<%# Eval("Horario", "{0:dd/MM/yyyy HH:mm}") %>'> </asp:Label>
                </ItemTemplate>
                <ItemStyle Width="150px" />
            </asp:TemplateField>
            <asp:BoundField DataField="Tipo" HeaderText="Tipo">
                <ItemStyle Width="130px" />
            </asp:BoundField>
             <asp:BoundField DataField="Descricao" HeaderText="Descrição">
                <ItemStyle Width="480px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Realizado">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBoxTarefa" runat="server" ></asp:CheckBox>
                    <itemstyle width="150px" />
                </ItemTemplate>
                <ItemStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Hora Realização">
                <ItemTemplate>
                    <asp:TextBox ID="TextBoxHoraRealizacao" MaxLength="5" onkeyup="formataHora(this,event);" Style="text-align: center" runat="server" Height="23px" Width="100px"></asp:TextBox>
                </ItemTemplate>
                <ItemStyle Width="150px" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
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
    <asp:Button runat="server" OnClientClick="return confirm('Deseja realmente salvar este registro?');" Text="Marcar Tarefa Realizada" CssClass="btn btn-primary" OnClick="MarcarTarefa_Click" />
    <asp:Button runat="server" OnClick="Voltar" Text="Voltar" CssClass="btn btn-primary" />
</asp:Content>
