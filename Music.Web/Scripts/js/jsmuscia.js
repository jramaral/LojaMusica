var corpoTabela = $("#secao-pesquisa").find("tbody");

$(document).ready(function () {

    pesquisarFaixa();
    validarBotaoNovo();
    aceitarNumeros();
    destativarCampo();
    formatar();


});

function validarBotaoNovo() {
    $("#new-music").one("click", function (e) {
        var texto = $("#Album").val()

        if (!texto > 0) {
            var resultados = $("#resultados");
            resultados.append('<div class="alert alert-danger">Selecione um Album para cadastrar novas músicas! :(</div>');
            e.preventDefault();
        } else {
            $(this).attr("href", "/Musicas/Adicionar/" + texto);
        }

    });
}


function novaLinha(codigo, faixa, genero, preco) {
    var linha = $("<tr>");
    var colunaCodigo = $("<td>").text(codigo);
    var colunaFaixa = $("<td>").text(faixa);
    var colunaGenero = $("<td>").text(genero);
    var colunaPreco = $("<td>").text(preco);
    var colunaAcoes = $("<td>");
    var pathEditar = "/Musicas/Editar/" + codigo;
    var pathExcluir = "/Musicas/Excluir/" + codigo;

    var link = $("<a>").addClass("btn btn-default btn-xs").attr("href", pathEditar);
    var icone = $("<span>").addClass("glyphicon glyphicon-pencil").attr("aria-hidden", "true");

    link.append(icone);

    var link1 = $("<a>").addClass("btn btn-danger btn-xs").attr("onclick","Deletar(" + codigo + ")").attr("id", "excluir");
    var icone1 = $("<span>").addClass("glyphicon glyphicon-trash").attr("aria-hidden", "true");

    link1.append(icone1);

    colunaAcoes.append(link).append(" | ");
    colunaAcoes.append(link1);

    linha.append(colunaCodigo);
    linha.append(colunaFaixa);
    linha.append(colunaGenero);
    linha.append(colunaPreco);
    linha.append(colunaAcoes);

    return linha;
}



function pesquisar()
{
    var pesquisa = { albumid: $("#Album").val() };

    $.getJSON("/musicas/pesquisar", pesquisa, function (data) {

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



function pesquisarFaixa() {
    $("#pesquisar").on("click", function () {
        pesquisar();
    });


}

function aceitarNumeros() {
    $("#Milissegundos").keyup(function () {
        $(this).val(this.value.replace(/\D/g, ''));

    });
}

function destativarCampo() {
    $("#titulo-album-desativado").attr("disabled", true);
}

function Deletar(idFaixa) {
  
    var confirmar = confirm("Deseja Realmente apagar?");

    if (confirmar) {
  
        $.ajax({
            type: 'POST',
            url: "/Musicas/Deletar",
            data: { id: idFaixa },
            success: function () {
                pesquisar();
            },
            error: function () {
                alert("Ocorreu algum erro :(");
            }
        });
    }
}

function formatar(){
    $("#TipoMidiaId").addClass("form-control");
    $("#GeneroID").addClass("form-control");
}