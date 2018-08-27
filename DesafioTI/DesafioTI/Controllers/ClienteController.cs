using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DesafioTI.Models; //public static List<Cliente> ListClientes = new List<Cliente>();

namespace DesafioTI.Controllers
{
    public class ClienteController : Controller
    {
        public static List<Cliente> ListClientes = new List<Cliente>();

        public ActionResult Index()
        {
            return View(ListClientes);
        }

        [HttpGet] //Adicionando atributos de rota Felipe Erlisson
        public ActionResult Create()
        {        
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Cliente cliente)
        {
            Cliente somador = new Cliente();
            if (ModelState.IsValid)
            {
                ListClientes.Add(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                 
            }
            Cliente cliente= ListClientes.First(c => c.ClienteId == id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind]Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                ListClientes[ListClientes.FindIndex(p => p.ClienteId == id)] = cliente;
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Cliente cliente = ListClientes.FirstOrDefault(p => p.ClienteId == id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            ListClientes.RemoveAll(p => p.ClienteId == id);
            return RedirectToAction("Index");
        }
    }
    
}