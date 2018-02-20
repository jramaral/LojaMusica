
function Deletar(idArtista) {

    var confirmar = confirm("Deseja Realmente apagar?");

    if (confirmar) {

       
        $.ajax({
            type: 'POST',
            url: "/Artista/Deletar",
            data: { id: idArtista },
            success: function () {
                alert("Deletado com Sucesso !");
                $(location).attr('href', '/Artista/Index');
            },
            error: function () {
                alert("Ocorreu algum erro :(");
            }
        });
        console.log(flag);
    }

    
}




