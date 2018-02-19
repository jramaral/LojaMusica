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
            GeneroDao gDao = new GeneroDao();
            TipoMidiaDao mDao = new TipoMidiaDao();

            AlbumDao albumDao = new AlbumDao();

            var album = albumDao.BuscarPorId(id);

            ViewBag.IdAlbum = album.AlbumId;
            ViewBag.TituloAlbum = album.Titulo;

            var faixa = new Faixa();

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

        public ActionResult Pesquisar(Faixa pesquisa)
        {
            
            var musicas = dao.Pesquisar(pesquisa);

            return Json(musicas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string Excluir(int id)
        {
            bool TrueOrFalse = dao.Excluir(id);

            if (TrueOrFalse)
            {
                return Boolean.TrueString;
            }
            else
            {
                return Boolean.FalseString;
            }
            
        }

    }
}