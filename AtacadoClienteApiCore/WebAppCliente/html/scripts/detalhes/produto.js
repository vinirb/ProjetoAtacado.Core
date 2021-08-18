$(function () {
    debugger;
    CarregarDetalhes();
})

function CarregarDetalhes() {
    debugger;
    var id = localStorage.getItem('produtoID');
    if ((id == undefined) || (id == 0)) {
        alert('Aviso! Produto ID nao foi definido');
        return;
    }
    else {
        localStorage.removeItem('produtoID');
        var urlServico = 'http://localhost:37806/api/estoque/produto/' + id;
        $.ajax({
            url: urlServico,
            method: 'GET',
            async: false,
            success: function (data) {
                if (data.length == 0) {
                    alert('Erro ao carregar os dados da produtos!!!');
                    return;
                }
                else {
                    var ProdutoID = data.produtoID;
                    var SubCategoriaID = data.subCategoriaID;
                    var CategoriaID = data.categoriaID;
                    var Descricao = data.descricao;
                    var DataInclusao = data.dataInclusao;

                    $('#txtProdutoID').val(ProdutoID);
                    $('#txtSubCategoriaID').val(SubCategoriaID);
                    $('#txtCategoriaID').val(CategoriaID);
                    $('#txtDescricao').val(Descricao);
                    $('#txtDataInclusao').val(DataInclusao);
                }
            }
        })
    }
}