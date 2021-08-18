$(function () {
    debugger;
    CarregarDetalhes();
});

function CarregarDetalhes() {
    debugger;
    var id = localStorage.getItem('ufid');

    if ((id == undefined) || (id == 0)) {
        alert('Aviso! UFID nao foi definido');
        return;
    }
    else {
        localStorage.removeItem('ufid');
        var urlServico = 'http://localhost:37806/api/geografico/unidadesfederacao/' + id;
        $.ajax({
            url: urlServico,
            method: 'GET',
            async: false,
            success: function (data) {
                if (data.length == 0) {
                    alert('Erro ao carregar os dados da unidadesfederacao!!!');
                    return;
                }
                else {
                    var UFID = data.ufid;
                    var Descricao = data.descricao;
                    var SiglaRegiao = data.siglaUF
                    var RegiaoID = data.regiaoID;
                    var DataInclusao = data.dataInclusao;

                    $('#txtUFID').val(UFID);
                    $('#txtDescricao').val(Descricao);
                    $('#txtSiglaRegiao').val(SiglaRegiao);
                    $('#txtRegiaoID').val(RegiaoID);
                    $('#txtDataInclusao').val(DataInclusao);
                }
            }
        });
    }
}