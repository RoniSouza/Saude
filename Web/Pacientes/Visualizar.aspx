<%@ Page Title="Informações do Paciente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Visualizar.aspx.cs" Inherits="Web.Pacientes.Visualizar" %>

<asp:Content ID="Visualizar" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/Javascript" src="../Scripts/jquery.maskedinput-1.3.1.min.js"></script>
    <script type="text/Javascript" src="../Scripts/mascara.js"></script>
    <br />
    <br />
    <br />
    <h3>Informações do Paciente</h3>
    <hr />
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="row">
        <div class="col-xs-2">
            <asp:Label runat="server">Código</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxCodigo" ReadOnly="True" class="form-control" />
        </div>
    </div>
    <div class="row">
        <div class="col-xs-4">
            <asp:Label runat="server">Nome</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxNome" required="true" class="form-control" />
        </div>
        <div class="col-xs-4">
            <asp:Label runat="server">Pai</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxPai" class="form-control" />
        </div>
        <div class="col-xs-4">
            <asp:Label runat="server">Mãe</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxMae" class="form-control" />
        </div>
        <div class="col-xs-5">
            <asp:Label runat="server">Endereço</asp:Label>

            <asp:TextBox runat="server" ID="TextBoxEndereco" required="true" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Número</asp:Label>

            <asp:TextBox runat="server" ID="TextBoxNumero" required="true" class="form-control" />
        </div>
        <div class="col-xs-4">
            <asp:Label runat="server">Bairro</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxBairro" required="true" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Cidade</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxCidade" required="true" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Estado</asp:Label>
            <asp:DropDownList ID="DropDownListEstado" class="form-control" runat="server">
                <asp:ListItem Text="Acre" Value="Acre" />
                <asp:ListItem Text="Alagoas" Value="Alagoas" />
                <asp:ListItem Text="Amazonas" Value="Amazonas" />
                <asp:ListItem Text="Amapá" Value="Amapá" />
                <asp:ListItem Text="Bahia" Value="Bahia" />
                <asp:ListItem Text="Ceará" Value="Ceará" />
                <asp:ListItem Text="Distrito Federal" Value="Distrito Federal" />
                <asp:ListItem Text="Espírito Santo" Value="Espírito Santo" />
                <asp:ListItem Text="Goiás" Value="Goiás" />
                <asp:ListItem Text="Maranhão" Value="Maranhão" />
                <asp:ListItem Text="Mato Grosso" Value="Mato Grosso" />
                <asp:ListItem Text="Mato Grosso do Sul" Value="Mato Grosso do Sul" />
                <asp:ListItem Text="Minas Gerais" Value="Minas Gerais" />
                <asp:ListItem Text="Pará" Value="Pará" />
                <asp:ListItem Text="Paraíba" Value="Paraíba" />
                <asp:ListItem Text="Paraná" Value="Paraná" />
                <asp:ListItem Text="Pernambuco" Value="Pernambuco" />
                <asp:ListItem Text="Piauí" Value="Piauí" />
                <asp:ListItem Text="Rio de Janeiro" Value="Rio de Janeiro" />
                <asp:ListItem Text="Rio Grande do Norte" Value="Rio Grande do Norte" />
                <asp:ListItem Text="Rondônia" Value="Rondônia" />
                <asp:ListItem Text="Roraima" Value="Roraima" />
                <asp:ListItem Text="Rio Grande do Sul" Value="Rio Grande do Sul" />
                <asp:ListItem Text="Santa Catarina" Value="Santa Catarina" />
                <asp:ListItem Text="São Paulo" Value="São Paulo" />
                <asp:ListItem Text="Sergipe" Value="Sergipe" />
                <asp:ListItem Text="Tocantins" Value="Tocantins" />
            </asp:DropDownList>
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">CEP</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxCEP" MaxLength="9" onkeyup="formataCEP(this,event);" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Naturalidade</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxNaturalidade" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Nacionalidade</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxNacionalidade" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">RG</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxRG" required="true" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Orgão Emissor</asp:Label>
            <asp:DropDownList ID="DropDownListOrgaoEmissor" class="form-control" runat="server">
                <asp:ListItem Text="SSP" Value="SSP" />
                <asp:ListItem Text="Detran" Value="Detran" />
                <asp:ListItem Text="Polícia Federal" Value="Polícia Federal" />
            </asp:DropDownList>
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">UF</asp:Label>
            <asp:DropDownList ID="DropDownListUF" class="form-control" runat="server">
                <asp:ListItem Text="Acre" Value="Acre" />
                <asp:ListItem Text="Alagoas" Value="Alagoas" />
                <asp:ListItem Text="Amazonas" Value="Amazonas" />
                <asp:ListItem Text="Amapá" Value="Amapá" />
                <asp:ListItem Text="Bahia" Value="Bahia" />
                <asp:ListItem Text="Ceará" Value="Ceará" />
                <asp:ListItem Text="Distrito Federal" Value="Distrito Federal" />
                <asp:ListItem Text="Espírito Santo" Value="Espírito Santo" />
                <asp:ListItem Text="Goiás" Value="Goiás" />
                <asp:ListItem Text="Maranhão" Value="Maranhão" />
                <asp:ListItem Text="Mato Grosso" Value="Mato Grosso" />
                <asp:ListItem Text="Mato Grosso do Sul" Value="Mato Grosso do Sul" />
                <asp:ListItem Text="Minas Gerais" Value="Minas Gerais" />
                <asp:ListItem Text="Pará" Value="Pará" />
                <asp:ListItem Text="Paraíba" Value="Paraíba" />
                <asp:ListItem Text="Paraná" Value="Paraná" />
                <asp:ListItem Text="Pernambuco" Value="Pernambuco" />
                <asp:ListItem Text="Piauí" Value="Piauí" />
                <asp:ListItem Text="Rio de Janeiro" Value="Rio de Janeiro" />
                <asp:ListItem Text="Rio Grande do Norte" Value="Rio Grande do Norte" />
                <asp:ListItem Text="Rondônia" Value="Rondônia" />
                <asp:ListItem Text="Roraima" Value="Roraima" />
                <asp:ListItem Text="Rio Grande do Sul" Value="Rio Grande do Sul" />
                <asp:ListItem Text="Santa Catarina" Value="Santa Catarina" />
                <asp:ListItem Text="São Paulo" Value="São Paulo" />
                <asp:ListItem Text="Sergipe" Value="Sergipe" />
                <asp:ListItem Text="Tocantins" Value="Tocantins" />
            </asp:DropDownList>
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">CPF</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxCPF" MaxLength="14" onkeyup="formataCPF(this,event);" required="true" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Cor/Raça</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxCorRaca" required="true" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Tel Fixo</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxTelFixo" MaxLength="14" onkeyup="formataTelefone(this,event);" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Tel Celular</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxTelCel" MaxLength="14" onkeyup="formataTelefone(this,event);" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Data Nascimento</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxDataNasc" MaxLength="10" onkeyup="formataData(this,event);" class="form-control" required="true" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">E-mail</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxEmail" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Sexo</asp:Label>
            <asp:DropDownList ID="DropDownListSexo" class="form-control" runat="server">
                <asp:ListItem Text="Masculino" Value="Masculino" />
                <asp:ListItem Text="Feminino" Value="Feminino" />
            </asp:DropDownList>
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Data Cadastro</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxDataCadastro" DataFormatString="{0:dd/MM/yyyy HH:mm}" ReadOnly="True" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Data Modificação</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxDataModificacao" DataFormatString="{0:dd/MM/yyyy HH:mm}" ReadOnly="True" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Cadastrado Por</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxCadastradoPor" ReadOnly="True" class="form-control" />
        </div>
    </div>
    <br />
    <h3>Informações do Convênio</h3>
    <br />
    <div class="row">
        <div class="col-xs-3">
            <asp:Label runat="server">Convênio</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxConvenio" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Número Inscrição</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxNumeroInscricao" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Validade</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxValidadeCartao" MaxLength="10" onkeyup="formataData(this,event);" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Tipo Plano</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxTipoPlano" class="form-control" />
        </div>
    </div>
    <br />
    <h3>Informações da Internação</h3>
    <br />
    <div class="row">
        <div class="col-xs-5">
            <asp:Label runat="server">Responsável</asp:Label>
            <asp:TextBox runat="server" ID="TextBoxResponsavel" class="form-control" />
        </div>
        <div class="col-xs-3">
            <asp:Label runat="server">Leito</asp:Label>
            <asp:DropDownList ID="DropDownListLeito" class="form-control" runat="server">
                <asp:ListItem Text="" Value="" />
                <asp:ListItem Text="101" Value="101" />
                <asp:ListItem Text="102" Value="102" />
                <asp:ListItem Text="103" Value="103" />
                <asp:ListItem Text="104" Value="104" />
                <asp:ListItem Text="201" Value="201" />
                <asp:ListItem Text="202" Value="202" />
                <asp:ListItem Text="203" Value="203" />
                <asp:ListItem Text="204" Value="204" />
                <asp:ListItem Text="301" Value="301" />
                <asp:ListItem Text="302" Value="302" />
                <asp:ListItem Text="303" Value="303" />
                <asp:ListItem Text="304" Value="304" />
            </asp:DropDownList>
        </div>
    </div>
    <br />
    <br />
    <div>
        <asp:Button runat="server" OnClick="Alterar" Text="Alterar" OnClientClick="return confirm('Você tem certeza que deseja alterar este registro?');" CssClass="btn btn-primary" />
        <asp:Button runat="server" OnClick="Excluir" Text="Excluir" OnClientClick="return confirm('Você tem certeza que deseja excluir este registro?');" CssClass="btn btn-primary" />
        <asp:Button runat="server" OnClick="ImprimirQRCode" Text="Gerar QRCode" CssClass="btn btn-primary" />
        <asp:Button runat="server" OnClick="VerProntuario" Text="Prontuário" CssClass="btn btn-primary" />
       <asp:Button runat="server" OnClick="Voltar" Text="Voltar" CssClass="btn btn-primary" />
    </div>
     <br />
    <br />
</asp:Content>

