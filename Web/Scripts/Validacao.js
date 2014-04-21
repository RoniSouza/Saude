function HaCampoVazio() {
    var falta_um = false;
    var frmFLD = FCadastro.elements;
    for (var i = 0; i < frmFLD.length; i++) {
        if ((frmFLD[i].value == "") && (frmFLD[i].getAttribute("obrigatorio") == "sim")){
            frmFLD[i].style.backgroundColor = "coral";
            falta_um = true;
        }
        else {
            frmFLD[i].style.backgroundColor = "none";
        }
    }
    if (falta_um == true) {
        window.alert("Os campos destacados devem ser preenchidos");
    }
    return falta_um;
}

function ValidaCPF(strCPF) {

    //Origem: SRFB

    strCPF = strCPF.replace(/[.]/g, "");
    strCPF = strCPF.replace(/[-]/g, "");
    var Soma;
    var Resto;
    Soma = 0;
    if (strCPF == "00000000000") {
        window.alert("O CPF informado é inválido");
        return false;
    }
    for (i=1; i<=9; i++) Soma = Soma + parseInt(strCPF.substring(i-1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;
     
    if ((Resto == 10) || (Resto == 11))  Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10))) {
        window.alert("O CPF informado é inválido");
        return false;
    }
    Soma = 0;
    for (i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i-1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;
     
    if ((Resto == 10) || (Resto == 11))  Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11))) {
        window.alert("O CPF informado é inválido");
        return false;
    }
    return true;
}