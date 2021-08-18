var municipios = [];
var estados = [];
var regioes = [];

$(function () {
    debugger;
    if (localStorage.getItem('regioes') == null) {
        CarregarRegioes();
    }
    else {
        var temp = localStorage.getItem('regioes');
        regioes = JSON.parse(temp);
    }

    EventosdaPagina();
    PreencherSelectRegioes();
});

function EventosdaPagina() {
    debugger;
    $('#cmbRegioes').change(function () {
        LimparDados();
        var estadoid = $('#cmbRegioes').val();
        CarregarUnidadesFederacoes(estadoid);
        PreencherSelectEstados();
    });
    $('#cmbEstados').change(function () {
        var munid = $('#cmbEstados').val();
        CarregarMunicipios(munid);
        PreencherTabelaMunicipios();
    });
}

function CarregarUnidadesFederacoes(estadoid) {
    debugger;
    estados = [];
    var urlServico = 'http://localhost:37806/api/geografico/regiao/' + estadoid + '/unidadesfederacao';
    $.ajax({
        url: urlServico,
        method: 'GET',
        async: false,
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                var item = data[i];

                var estado = {
                    ufid: item.ufid,
                    descricao: item.descricao,
                    siglaUF: item.siglaUF,
                    regiaoID: item.regiaoID,
                    dataInclusao: item.dataInclusao
                };

                estados.push(estado);
                localStorage.setItem('estados', JSON.stringify(estados));
            }
        }
    });
}

function CarregarMunicipios(munid) {
    debugger;
    municipios=[];
    var urlServico = 'http://localhost:37806/api/geografico/unidadesfederacao/' + munid + '/municipio';
    $.ajax({
        url: urlServico,
        method: 'GET',
        async: false,
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                var item = data[i];

                var municipio = {
                    municipioID: item.municipioID,
                    ibgE6: item.ibgE6,
                    ibgE7: item.ibgE7,
                    descricao: item.descricao,
                    mesoregiaoID: item.mesoregiaoID,
                    microregiaoID: item.microregiaoID,
                    ufid: item.ufid,
                    populacao: item.populacao,
                    cep: item.cep,
                    siglaUF: item.siglaUF
                };

                municipios.push(municipio);
            }
            localStorage.setItem('municipios', JSON.stringify(municipios));
        }
    });
}

function CarregarRegioes() {
    debugger;
    var urlServico = 'http://localhost:37806/api/geografico/regiao';
    $.ajax({
        url: urlServico,
        method: 'GET',
        async: false,
        success: function (data) {

            for (var i = 0; i < data.length; i++) {

                var item = data[i];

                var regiao = {

                    regiaoID: item.regiaoID,
                    descricao: item.descricao,
                    siglaRegiao: item.siglaRegiao,
                    dataInclusao: item.dataInclusao

                };

                regioes.push(regiao);
            }

            localStorage.setItem('regioes', JSON.stringify(regioes));
        }


    });
}

function PreencherSelectRegioes() {
    debugger;
    if ((regioes == null) || (regioes.length == 0)) {
        alert("Aviso - Os dados de Categorias não foram carregados.");
        return;
    }
    else {
        $('#cmbRegioes').empty();
        $('#cmbRegioes').append($('<option>', { value: 0, text: 'Selecione uma Regiao' }));
        for (var i = 0; i < regioes.length; i++) {
            var item = regioes[i];
            $('#cmbRegioes').append($('<option>', { value: item.regiaoID, text: item.descricao }));
        }
    }
}

function PreencherSelectEstados() {
    debugger;
    if ((estados == null) || (estados.length == 0)) {
        alert("Aviso - Os dados de Estados não foram carregados.");
        return;
    }
    else {
        $('#cmbEstados').empty();
        $('#cmbEstados').append($('<option>', { value: 0, text: "Selecione um Estado." }));
        for (var i = 0; i < estados.length; i++) {
            var item = estados[i];
            $('#cmbEstados').append($('<option>', { value: item.ufid, text: item.descricao }));
        }
    }
}

function PreencherTabelaMunicipios() {
    debugger;
    $('#tblMunicipio tbody').empty();
    if ((municipios == null) || (municipios.length == 0)) {
        alert("Aviso - Os dados de Municipios não foram carregados.");
        return;
    }
    else {
        for (var i = 0; i < municipios.length; i++) {
            var item = municipios[i];

            var inicio = '<tr>';
            var coluna1 = '<td>' + item.municipioID + '</td>';
            var coluna2 = '<td>' + item.ibgE6 + '</td>';
            var coluna3 = '<td>' + item.ibgE7 + '</td>';
            var coluna4 = '<td>' + item.descricao + '</td>';
            var coluna5 = '<td>' + item.mesoregiaoID + '</td>';
            var coluna6 = '<td>' + item.microregiaoID + '</td>';
            var coluna7 = '<td>' + item.ufid + '</td>';
            var coluna8 = '<td>' + item.populacao + '</td>';
            var coluna9 = '<td>' + item.cep + '</td>';
            var coluna10 = '<td>' + item.siglaUF + '</td>';
            var coluna11 = '<td><input type="button" id="btnDetalhes" value="Detalhes"  onclick="ExibirDetalhes(\'' + item.municipioID + '\'); return false;"/></td>';
            var final = '</tr>';

            var conteudo = inicio + coluna1 + coluna2 + coluna3 + coluna4 + coluna5 + coluna6 + coluna7 + coluna8 + coluna9 + coluna10 + coluna11 + final;
            $('#tblMunicipio tbody').append(conteudo);
        }
    }
}

function LimparDados() {
    debugger;
    $('#cmbEstados').empty();
    $('#tblMunicipio tbody').empty();
}

function ExibirDetalhes(municipioID) {
    localStorage.setItem('municipioID', municipioID);
    window.open('municipiosdetalhes.html', '_blank');
}