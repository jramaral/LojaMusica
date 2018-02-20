function Deletar(idAlbum) {

    var confirmar = confirm("Deseja Realmente apagar?");

    if (confirmar) {


        $.ajax({
            type: 'POST',
            url: "/Album/Deletar",
            data: { id: idAlbum },
            success: function () {
                alert("Deletado com Sucesso !");
                $(location).attr('href', '/Album/Index');
            },
            error: function () {
                alert("Ocorreu algum erro :(");
            }
        });
      
    }


}