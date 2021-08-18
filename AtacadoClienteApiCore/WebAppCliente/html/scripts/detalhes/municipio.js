$(function () {
    CarregarDetalhes();
});

function CarregarDetalhes() {

    var id = localStorage.getItem('municipioID');

    if ((id == undefined) || (id == 0)) {
        alert('Aviso! MunicipioID nao foi definido');
        return;
    }
    else {
        localStorage.removeItem('municipioID');
        var urlServico = 'http://localhost:37806/api/geografico/municipio/' + id;
        $.ajax({
            url: urlServico,
            method: 'GET',
            async: false,
            success: function (data) {
                if (data.length == 0) {
                    alert('Erro ao carregar os dados de municipio!!!');
                    return;
                }
                else {
                    var MunicipioID = data.municipioID;
                    var IBGE6 = data.ibgE6;
                    var IBGE7 = data.ibgE7;
                    var Descricao = data.descricao;
                    var MesoregiaoID = data.mesoregiaoID;
                    var MicroregiaoID = data.microregiaoID;
                    var UFID = data.ufid;
                    var Populacao = data.populacao;
                    var CEP = data.cep;
                    var SiglaUF = data.siglaUF;

                    $('#txtMunicipioID').val(MunicipioID);
                    $('#txtIBGE6').val(IBGE6);
                    $('#txtIBGE7').val(IBGE7);
                    $('#txtDescricao').val(Descricao);
                    $('#txtMesoRegiaoID').val(MesoregiaoID);
                    $('#txtMicroRegiaoID').val(MicroregiaoID);
                    $('#txtUFID').val(UFID);
                    $('#txtPopulacao').val(Populacao);
                    $('#txtCEP').val(CEP);
                    $('#txtSiglaUF').val(SiglaUF);
                }
            }
        });
    }
}
