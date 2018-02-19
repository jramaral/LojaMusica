using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Music.Contexto;
using Music.Dominio;

namespace Music.Web.Controllers
{
    public class AlbumController : Controller
    {

        AlbumDao dao = new AlbumDao();

        // GET: Album
        public ActionResult Index()
        {
            var album = dao.BuscarTodos();
            return View(album);
        }
        public ActionResult Adicionar()
        {
            ArtistaDao artistaDao = new ArtistaDao();
            ViewBag.ArtistaID = new SelectList(artistaDao.BuscarTodos(), "ArtistaID", "Nome");
            return View();
       }
        [HttpPost]
        public ActionResult Adicionar(Album album)
        {
            if (album.ArtistaId>0)
            {
                dao.Salvar(album);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
           
        }
        public ActionResult Editar(int id)
        {
            var album = dao.BuscarPorId(id);
            ArtistaDao artistaDao = new ArtistaDao();
            var artista = artistaDao.BuscarTodos();

            ViewBag.ArtistaID = new SelectList(artista, "ArtistaID", "Nome", album.ArtistaId);

            return View(album);

        }
        [HttpPost]
        public ActionResult Editar(Album album)
        {
            if (!string.IsNullOrEmpty(album.Titulo))
            {
                dao.SalvarAlteracao(album);
                
                return RedirectToAction("Index");
            }

            return View(album);
        }


    }
    
}