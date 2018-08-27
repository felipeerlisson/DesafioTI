using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DesafioTI.Models; //public static List<Cliente> ListClientes = new List<Cliente>();

namespace DesafioTI.Controllers
{
    public class VendasController : Controller
    {
        public static List<Venda> ListVendas = new List<Venda>();

        public ActionResult Index()
        {
            return View(ListVendas);
        }

        [HttpGet] //Adicionando atributos de rota Felipe Erlisson
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Venda vendas)
        {
            if (ModelState.IsValid)
            {
                ListVendas.Add(vendas);
                return RedirectToAction("Index");
            }
            return View(vendas);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Venda vendas = ListVendas.First(c => c.Id == id);

            if (vendas == null)
            {
                return HttpNotFound();
            }
            return View(vendas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind]Venda vendas)
        {
            if (id != vendas.Id)
            {
                return HttpNotFound();
            }
            if (ModelState.IsValid)
            {
                ListVendas[ListVendas.FindIndex(p => p.Id == id)] = vendas;
                return RedirectToAction("Index");
            }
            return View(vendas);
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Venda vendas = ListVendas.FirstOrDefault(p => p.Id == id);

            if (vendas == null)
            {
                return HttpNotFound();
            }

            return View(vendas);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            ListVendas.RemoveAll(p => p.Id == id);
            return RedirectToAction("Index");
        }

        public List<Item> GetItens()
        {
            return ItensController.ListItens;
        }
        
        public List<Cliente> GetClientes()
        {
            return ClienteController.ListClientes;
        }
        

    }
    /*Desafio TI

Desenvolva um aplicativo em C#, na estrutura MVC (pode ser em qualquer plataforma).
Insira estas 3 entidades na camada de modelo:

Itens:
• Valor Item
• Descrição
• Estoque

Clientes:
• Nome
• Data Nascimento
• Endereço
• Quantidade de Compras

Vendas:
• Valor Venda
• Item
• Quantidade
• Cliente

O aplicativo terá as seguintes funcionalidades:
- Cadastro de clientes, cadastro de itens e registro de vendas
- Exclusão de clientes, itens e vendas
- Alteração de clientes, itens e vendas
- Listagem de clientes, itens e vendas
- Sempre que uma venda for realizada, o estoque do item deve ser reduzido pela quantidade de itens comprados, e a quantidade de compras do cliente deve ser aumentada em + 1
- Não é possível ter um estoque menor que 0
- Os valores deverão ser salvos e acessados em Listas (recomendo o uso da biblioteca System.Collections.Generic)

*/
}