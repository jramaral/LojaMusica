using Music.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Music.Contexto;

namespace Music.Web.Controllers
{
    public class ConsultaController : Controller
    {
        ConsultaDao dao = new ConsultaDao();
        // GET: Consulta
        public ActionResult Index()
        {
            var query = dao.TipoConsulta();

            
            ViewBag.TipoConsulta = new SelectList(query, "ConsultaId", "Descricao");

            return View();
        }
        //Método para pesquisar 
        public ActionResult Pesquisar(int ConsultaId)
        {
            dao.getResultado(ConsultaId);
            var query = "teste";
        

            return Json(query, JsonRequestBehavior.AllowGet);
        }

    }
}