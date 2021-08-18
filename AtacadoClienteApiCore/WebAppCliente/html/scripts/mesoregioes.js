var estados = [];
var regioes = [];
var mesoregioes = [];

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
        var mesoid = $('#cmbEstados').val();
        CarregarMesoregioes(mesoid);
        PreencherTabelaMesoregioes();
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

function CarregarMesoregioes(mesoid) {
    mesoregioes = [];
    var urlServico = 'http://localhost:37806/api/geografico/unidadesfederacao/'+mesoid +'/mesoreigao'
    $.ajax({
        url: urlServico,
        async: false,
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                var item = data[i];
                var mesorregiao = {
                    mesoregiaoID: item.mesoregiaoID,
                    descricao: item.descricao,
                    ufid: item.ufid,
                    dataInclusao: item.dataInclusao
                };
                mesorregioes.push(mesorregiao);

            }
            localStorage.setItem('mesorregioes', JSON.stringify(mesorregioes));
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

function PreencherTabelaMesoregioes() {
    debugger;
    $('#tblMesoregioes tbody').empty();
    if ((mesoregioes == null) || (mesoregioes.length == 0)) {
        alert("Aviso - Os dados de Mesoregioes não foram carregados.");
        return;
    }
    else {
        for (var i = 0; i < mesoregioes.length; i++) {
            var item = mesoregioes[i];

            var inicio = '<tr>';
            var coluna1 = '<td>' + item.mesoregiaoID + '</td>';
            var coluna2 = '<td>' + item.descricao + '</td>';
            var coluna3 = '<td>' + item.ufid + '</td>';
            var coluna4 = '<td>' + item.dataInclusao + '</td>';
            var coluna5 = '<td><input type="button" id="btnDetalhes" value="Detalhes" onclick="ExibirDetalhes(\'' + item.mesoregiaoID + '\'); return false;" /></td>';
            var final = '</tr>';

            var conteudo = inicio + coluna1 + coluna2 + coluna3 + coluna4 + coluna5 + final;

            $('#tblMesoregioes tbody').append(conteudo);
        }
    }
}

function LimparDados() {
    debugger;
    $('#cmbEstados').empty();
    $('#tblMesoregioes tbody').empty();
}