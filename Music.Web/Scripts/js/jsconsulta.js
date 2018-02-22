$(document).ready(function () {

    executarPesquisa();
    formatar();
   

});

function formatar() {
    $("#TipoConsulta").addClass("form-control");
  
}

function executarPesquisa() {
    $("#pesquisar").on("click", function () {
        pesquisar();
    });


}


function pesquisar() {
    var pesquisa = { ConsultaId: $("#TipoConsulta").val() };

    $.getJSON("/consulta/pesquisar", pesquisa, function (data) {

        var resultados = $("#resultado-consulta");

        resultados.empty();

        if (data.length == 0) {
            resultados.append('<div class="alert alert-danger">Nenhuma música encontrado para o album escolhido! :(</div>');
            return false;
        }

        for (var i = 0; i < data.length; i++) {

            resultados.append('<div class="col-sm-6 col-md-4"><div class="thumbnail panel-success"><div class="caption"><h4>'
                + data[i].Nome +
                '</h4><p>Quantidade: ' + data[i].Quantidade + '</p></div></div ></div>');



        }

    });
}