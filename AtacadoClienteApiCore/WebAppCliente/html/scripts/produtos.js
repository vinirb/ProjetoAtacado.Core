var produtos = [];
var subcategorias = [];
var categorias = [];

$(function () {
    debugger;
    if (localStorage.getItem('categorias') == null) {
        CarregarCategorias();
    }
    else {
        var temp = localStorage.getItem('categorias');
        categorias = JSON.parse(temp);
    }

    EventosdaPagina();
    PreencherSelectCategorias();
});

function EventosdaPagina() {
    $('#cmbCategorias').change(function () {
        LimparDados();
        var catid = $('#cmbCategorias').val();
        CarregarSubCategorias(catid);
        PreencherSelectSubCategorias();
    });

    $('#cmbSubCategorias').change(function () {
        var subcatid = $('#cmbSubCategorias').val();
        CarregarProdutos(subcatid);
        PreencherTabelaProdutos();
    });

}

function CarregarProdutos(subcatid) {
    produtos = [];
    var urlServico = 'http://localhost:37806/api/estoque/subcategoria/' + subcatid +'/produtos';
    $.ajax({

        url: urlServico,
        method: 'GET',
        async: false,
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                var item = data[i];

                var produto = {

                    produtoID: item.produtoID,
                    subCategoriaID: item.subCategoriaID,
                    categoriaID: item.categoriaID,
                    descricao: item.descricao,
                    dataInclusao: item.dataInclusao

                }

                produtos.push(produto);
            }
            localStorage.setItem('produtos', JSON.stringify(produtos));
        }

    });
}

function CarregarCategorias() {
    var urlServico = 'http://localhost:37806/api/estoque/categoria';
    $.ajax({
        url: urlServico,
        method: 'GET',
        async: false,
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                var item = data[i];

                var categoria = {

                    categoriaId: item.categoriaId,
                    descricao: item.descricao,
                    dataInclusao: item.dataInclusao

                };

                categorias.push(categoria);
            }

            localStorage.setItem('categorias', JSON.stringify(categorias));
        }
    });
}

function CarregarSubCategorias(catid) {
    subcategorias = [];
    var urlServico = 'http://localhost:37806/api/estoque/categoria/' + catid + '/subcategorias';
    $.ajax({
        url: urlServico,
        method: 'GET',
        async: false,
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                var item = data[i];

                var subcategoria = {

                    subCategoriaID: item.subCategoriaID,
                    categoriaID: item.categoriaID,
                    descricao: item.descricao,
                    dataInclusao: item.dataInclusao
                }

                subcategorias.push(subcategoria);
            }
            localStorage.setItem('subcategorias', JSON.stringify(subcategorias));
        }
    })
}

function PreencherSelectCategorias() {
    if ((categorias == null) || (categorias.length == 0)) {
        alert("Aviso - Os dados de Categorias não foram carregados.");
        return;
    }
    else {
        $('#cmbCategorias').empty();
        $('#cmbCategorias').append($('<option>', { value: 0, text: "Selecione uma Categoria." }));
        for (var i = 0; i < categorias.length; i++) {
            var item = categorias[i];
            $('#cmbCategorias').append($('<option>', { value: item.categoriaId, text: item.descricao }));
        }
    }
}

function PreencherSelectSubCategorias() {
    debugger;
    if ((subcategorias == null) || (subcategorias.length == 0)) {
        alert("Aviso - Os dados de SubCategorias não foram carregados.");
        return;
    }
    else {
        $('#cmbSubCategorias').empty();
        $('#cmbSubCategorias').append($('<option>', { value: 0, text: "Selecione uma SubCategoria." }));
        for (var i = 0; i < subcategorias.length; i++) {
            var item = subcategorias[i];
            $('#cmbSubCategorias').append($('<option>', { value: item.subCategoriaID, text: item.descricao }));
        }
    }
}

function PreencherTabelaProdutos() {
    $('#tblProdutos tbody').empty();
    if (produtos == null || produtos.length == 0) {
        alert("Aviso - Os dados de Produtos não foram carregados.");
        return;
    }
    else {
        for (var i = 0; i < produtos.length; i++) {
            var item = produtos[i];

            var inicio = '<tr>';
            var coluna1 = '<td>' + item.produtoID + '</td>';
            var coluna2 = '<td>' + item.subCategoriaID + '</td>';
            var coluna3 = '<td>' + item.categoriaID + '</td>'
            var coluna4 = '<td>' + item.descricao + '</td>';
            var coluna5 = '<td>' + item.dataInclusao + '</td>';
            var coluna6 = '<td><input type="button" id="btnDetalhes" value="Detalhes"  onclick="ExibirDetalhes(\'' + item.produtoID + '\'); return false;"/></td>';
            var final = '</tr>';

            var conteudo = inicio + coluna1 + coluna2 + coluna3 + coluna4 + coluna5 + coluna6  + final;

            $('#tblProdutos tbody').append(conteudo);
        }
    }
}

function ExibirDetalhes(produtoID) {
    localStorage.setItem('produtoID',produtoID);
    var r = window.open('produtosdetalhes.html', '_blank');
}

function LimparDados() {
    $('#cmbSubCategorias').empty();
    $('#tblProdutos tbody').empty();
}

