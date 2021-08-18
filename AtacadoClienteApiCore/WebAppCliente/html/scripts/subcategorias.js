var categorias = [];
var subcategorias = [];

$(function () {
    debugger;
    if (localStorage.getItem('categorias') == null) {
        CarregarCategorias();
    }
    else {
        var temp = localStorage.getItem('categorias');
        categorias = JSON.parse(temp);
    }
    PreencherSelectCategorias();
    EventosdaPagina();
});

function EventosdaPagina() {
    $('#cmbCategorias').change(function () {
        var catid = $('#cmbCategorias').val();
        CarregarSubCategorias(catid);
        PreencherTabelaSubCategorias();
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

function CarregarSubCategorias(catid) {
    debugger;
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

function PreencherTabelaSubCategorias() {
    $('#tblSubCategorias tbody').empty();
    debugger;
        if (subcategorias == null || subcategorias.length == 0) {
            alert("Aviso - Os dados de SubCategorias não foram carregados.");
            return;
        }
        else {
            for (var i = 0; i < subcategorias.length; i++) {
                var item = subcategorias[i];

                var inicio = '<tr>';
                var coluna1 = '<td>' + item.subCategoriaID + '</td>';
                var coluna2 = '<td>' + item.categoriaID + '</td>'
                var coluna3 = '<td>' + item.descricao + '</td>';
                var coluna4 = '<td>' + item.dataInclusao + '</td>';
                var coluna5 = '<td><input type="button" id="btnDetalhes" value="Detalhes"  onclick="ExibirDetalhes(\'' + item.subCategoriaID + '\'); return false;"/></td>';
                var final = '</tr>';

                var conteudo = inicio + coluna1 + coluna2 + coluna3 + coluna4 + coluna5 + final;

                $('#tblSubCategorias tbody').append(conteudo);
            }
        }
}

function ExibirDetalhes(subCategoriaID) {
    debugger;
    localStorage.setItem('subCategoriaID',subCategoriaID);
    window.open('subcategoriadetalhes.html', '_blank');
}
