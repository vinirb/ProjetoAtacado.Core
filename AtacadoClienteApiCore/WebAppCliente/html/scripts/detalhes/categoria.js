$(function () {
    debugger;
    CarregarDetalhes();
});

function CarregarDetalhes() {
    debugger;
    var id = localStorage.getItem('categoriaId');

    if ((id == undefined) || (id == 0)) {
        alert('Aviso! Categoria ID nao foi definido');
        return;
    }
    else {
        localStorage.removeItem('categoriaId');
        var urlServico = 'http://localhost:37806/api/estoque/categoria/' + id;
        $.ajax({
            url: urlServico,
            method: 'GET',
            async: false,
            success: function (data) {
                if (data.length == 0) {
                    alert('Erro ao carregar os dados da categoria!!!');
                    return;
                }
                else {
                    var categoriaID = data.categoriaId;
                    var Descricao = data.descricao;
                    var DataInclusao = data.dataInclusao;

                    $('#txtCategoriaID').val(categoriaID);
                    $('#txtDescricao').val(Descricao);
                    $('#txtDataInclusao').val(DataInclusao);
                }
            }
        });
    }
}
