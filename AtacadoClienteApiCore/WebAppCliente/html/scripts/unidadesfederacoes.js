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
    PreencherSelectRegioes();
    EventosdaPagina();
});

function EventosdaPagina() {
    debugger;
    $('#cmbRegioes').change(function () {
        var regiaoid = $('#cmbRegioes').val();
        CarregarUnidadesFederacoes(regiaoid);
        PreencherTabelaEstados();
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

function CarregarUnidadesFederacoes(regiaoid) {
    debugger;
    estados = [];
    var urlServico = 'http://localhost:37806/api/geografico/regiao/' + regiaoid + '/unidadesfederacao';
    $.ajax({
        url: urlServico,
        method: 'GET',
        async: false,
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                var item = data[i];

                var estado = {
                    ufid : item.ufid,
                    descricao : item.descricao,
                    siglaUF: item.siglaUF,
                    regiaoID: item.regiaoID,
                    dataInclusao : item.dataInclusao
                }

                estados.push(estado);
                localStorage.setItem('estados', JSON.stringify(estados));
            }
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

function PreencherTabelaEstados() {
    debugger;
    $('#tblEstados tbody').empty();
    if ((estados == null) || (estados.length == 0)) {
        alert("Aviso - Os dados de UnidadesFederacao não foram carregados.");
        return;
    }
    else {
        for (var i = 0; i < estados.length; i++) {
            var item = estados[i];

            var inicio = '<tr>';
            var coluna1 = '<td>' + item.ufid + '</td>';
            var coluna2 = '<td>' + item.descricao + '</td>';
            var coluna3 = '<td>' + item.siglaUF + '</td>';
            var coluna4 = '<td>' + item.regiaoID + '</td>';
            var coluna5 = '<td>' + item.dataInclusao + '</td>';
            var coluna6 = '<td><input type="button" id="btnDetalhes" value="Detalhes"  onclick="ExibirDetalhes(\'' + item.regiaoID + '\'); return false;"/></td>';
            var final = '</tr>';

            var conteudo = inicio + coluna1 + coluna2 + coluna3 + coluna4 + coluna5 + coluna6 + final;

            $('#tblEstados tbody').append(conteudo);
        }
    }
}

function ExibirDetalhes(ufid) {
    localStorage.setItem('ufid', ufid);
    window.open('unidadesfederacoesdetalhes.html', '_blank');
}