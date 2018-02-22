$(document).ready(function () {

    executarPesquisa();
   

});

function executarPesquisa() {
    $("#pesquisar").on("click", function () {
        pesquisar();
    });


}


function pesquisar() {
    var pesquisa = { ConsultaId: $("#TipoConsulta").val() };

    $.getJSON("/consulta/pesquisar", pesquisa, function (data) {

        var resultados = $("#resultados");

        resultados.empty();

        if (data.length == 0) {
            resultados.append('<div class="alert alert-danger">Nenhuma música encontrado para o album escolhido! :(</div>');
            return false;
        }

        for (var i = 0; i < data.length; i++) {

            var linha = novaLinha(data[i].Codigo, data[i].Nome, data[i].Genero, data[i].Preco);
            console.log(linha);
            corpoTabela.append(linha);

        }

    });
}