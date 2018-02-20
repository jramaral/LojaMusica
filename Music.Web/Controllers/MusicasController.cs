using Music.Dominio;
using Music.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music.Web.Controllers
{
    public class MusicasController : Controller
    {
        private MusicaDao dao = new MusicaDao();

        // GET: Musicas

        public ActionResult Index()
        {
            AlbumDao albumDao = new AlbumDao();
            ViewBag.Album = new SelectList(albumDao.BuscarTodos(), "AlbumId", "Titulo");
            return View();
        }

        public ActionResult Adicionar(int id)
        {
            //Pega o genero 
            GeneroDao gDao = new GeneroDao();
            //pega o tipo da midia
            TipoMidiaDao mDao = new TipoMidiaDao();
            //pega o album
            AlbumDao albumDao = new AlbumDao();

            //Busca o album selecionado na listagem
            var album = albumDao.BuscarPorId(id);


            ViewBag.IdAlbum = album.AlbumId;
            ViewBag.TituloAlbum = album.Titulo;


            var faixa = new Faixa();
            //Atribui o id do album a uma FK da Faixa
            faixa.AlbumId = album.AlbumId;

            ViewBag.GeneroID = new SelectList(gDao.BuscarTodos(), "GeneroID", "Nome");
            ViewBag.TipoMidiaId = new SelectList(mDao.BuscarTodos(), "TipoMidiaId","Nome");

            return View(faixa);
        }

        [HttpPost]
        public ActionResult Adicionar(Faixa faixa)
        {
            if (faixa.FaixaId == 0)
            {
                dao.Salvar(faixa);
                return RedirectToAction("Index");
            }
            else
            {
                return View(faixa);
            }

        }

        //Método para pesquisar as faixas de um determinado album
        public ActionResult Pesquisar(Faixa pesquisa)
        {
            
            var musicas = dao.Pesquisar(pesquisa);

            return Json(musicas, JsonRequestBehavior.AllowGet);
        }

        //Método para excluir um faixa
        [HttpPost]
        public void Deletar(int id)
        {
            try
            {
                bool TrueOrFalse = dao.Excluir(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult Editar(int id)
        {
            //Pega o genero 
            GeneroDao gDao = new GeneroDao();
            //pega o tipo da midia
            TipoMidiaDao mDao = new TipoMidiaDao();


            var faixa = dao.BuscarPorId(id);

            ViewBag.IdAlbum = faixa.AlbumId;// album.AlbumId;
            ViewBag.TituloAlbum = faixa.Album.Titulo; // album.Titulo;



            
            ViewBag.GeneroID = new SelectList(gDao.BuscarTodos(), "GeneroID", "Nome", faixa.GeneroId);
            ViewBag.TipoMidiaId = new SelectList(mDao.BuscarTodos(), "TipoMidiaId", "Nome", faixa.TipoMidiaId);

            return View(faixa);
        }

        [HttpPost]
        public ActionResult Editar(Faixa faixa)
        {
            if(faixa.FaixaId>0)
            {
                dao.SalvarAlteracao(faixa);
                return RedirectToAction("Index");
            }
           
            return View(faixa);
        }

    }
}