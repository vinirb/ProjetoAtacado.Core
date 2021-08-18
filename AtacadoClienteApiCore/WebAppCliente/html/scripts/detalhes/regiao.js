$(function () {
    debugger;
    CarregarDetalhes();
});

function CarregarDetalhes() {
    debugger;
    var id = localStorage.getItem('regiaoID');

    if ((id == undefined) || (id == 0)) {
        alert('Aviso! Regiao ID nao foi definido');
        return;
    }
    else {
        localStorage.removeItem('regiaoID');
        var urlServico = 'http://localhost:37806/api/geografico/regiao/' + id;
        $.ajax({
            url: urlServico,
            method: 'GET',
            async: false,
            success: function (data) {
                if (data.length == 0) {
                    alert('Erro ao carregar os dados da regiao!!!');
                    return;
                }
                else {
                    var RegiaoID = data.regiaoID;
                    var Descricao = data.descricao;
                    var SiglaRegiao = data.siglaRegiao;
                    var DataInclusao = data.dataInclusao;

                    $('#txtRegiaoID').val(RegiaoID);
                    $('#txtDescricao').val(Descricao);
                    $('#txtSiglaRegiao').val(SiglaRegiao);
                    $('#txtDataInclusao').val(DataInclusao);
                }
            }
        });
    }

}