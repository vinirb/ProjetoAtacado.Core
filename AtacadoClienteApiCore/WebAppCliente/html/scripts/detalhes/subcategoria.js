$(function () {
    debugger;
    CarregarDetalhes();
});

function CarregarDetalhes() {
    debugger;
    var id = localStorage.getItem('subCategoriaID');

    if ((id == undefined) || (id == 0)) {
        alert('Aviso! SubCtegoria ID nao foi definido');
        return;
    }
    else {
        localStorage.removeItem('subCategoriaID');
        var urlServico = 'http://localhost:37806/api/estoque/subcategoria/'+ id;
        $.ajax({
            url: urlServico,
            method: 'GET',
            async: false,
            success: function (data) {
                if (data.length == 0) {
                    alert('Erro ao carregar os dados da subcategoria!!!');
                    return;
                }
                else {
                    var SubcategoriaID = data.subCategoriaID;
                    var CategoriaID = data.categoriaID;
                    var Descricao = data.descricao;
                    var DataInclusao = data.dataInclusao;

                    $('#txtSubCategoriaID').val(SubcategoriaID);
                    $('#txtCategoriaID').val(CategoriaID);
                    $('#txtDescricao').val(Descricao);
                    $('#txtDataInclusao').val(DataInclusao);
                };
            }
        });
    }
}
