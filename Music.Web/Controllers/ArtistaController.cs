using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Music.Contexto;
using Music.Dominio;

namespace Music.Web.Controllers
{
    public class ArtistaController : Controller
    {
        ArtistaDao artistaDao = new ArtistaDao();
        // GET: Artista
        public ActionResult Index()
        {
            var artista = artistaDao.BuscarTodos();

            return View(artista);
        }

        public ActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adicionar(Artista artista)
        {
            if (! string.IsNullOrEmpty(artista.Nome))
            {
                artistaDao.Salvar(artista);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }

        }

        public ActionResult Editar(int id)
        {

            var artista = artistaDao.BuscarPorId(id);

            return View(artista);

        }
        [HttpPost]
        public ActionResult Editar(Artista artista)
        {
            if (!string.IsNullOrEmpty(artista.Nome))
            {
                artistaDao.SalvarAlteracao(artista);

                return RedirectToAction("Index");
            }

            return View(artista);
        }


    }
}