using System.Collections.Generic; //- Os valores deverão ser salvos e acessados em Listas (recomendo o uso da biblioteca System.Collections.Generic)
using System.Linq;
using System.Web.Mvc;
using DesafioTI.Models;

namespace DesafioTI.Controllers
{

    public class ItensController : Controller
    {
        public static List<Item> ListItens = new List<Item>();
        public ActionResult Index()
        {
            return View(ListItens);
        }
        [HttpGet] //pagina de criaçao redirecionamento
        public ActionResult Create()//botao incluir da view
        {
 
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Item itens)
        {
            
            if (ModelState.IsValid)
            {
                ListItens.Add(itens);
                return RedirectToAction("Index");
            }

            return View(itens);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return HttpNotFound();
            }
            Item itens = ListItens.First(c => c.Id == id);

            if (itens == null)
            {
                return HttpNotFound();
            }
            return View(itens);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind]Item itens)
        {
            if (id != itens.Id)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                ListItens[ListItens.FindIndex(p => p.Id == id)] = itens;
                return RedirectToAction("Index");
            }
            return View(itens);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Item itens = ListItens.FirstOrDefault(p => p.Id == id);
     

            if (itens == null)
            {
                return HttpNotFound();
            }

            return View(itens);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            ListItens.RemoveAll(p => p.Id == id);
            return RedirectToAction("Index");
        }
        
    }
}