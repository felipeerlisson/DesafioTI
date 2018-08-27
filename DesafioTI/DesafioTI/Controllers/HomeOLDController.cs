using DesafioTI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesafioTI.Controllers
{
    public class HomeControllerOLD : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Sobre()
        {
            return View();
        }
      

        public ActionResult CadastroCliente()
        {
            var cliente = new Cliente()
            {
                ClienteId = 1,
                Nome = "Felipe Erlisson",
                DataDeNascimento =new DateTime(1997,12,5),
                Endereço = "Carlos Prates nº 201 Rua Peçanha",
                QuantidadeDeCompras = 1
            };
            ViewData["ClienteId"] = cliente.ClienteId;
            ViewData["Nome"] = cliente.Nome;
            ViewData["DataDeNascimento"] = cliente.DataDeNascimento;
            ViewData["Endereço"] = cliente.Endereço;
            ViewData["QuantidadeDeCompras"] = cliente.QuantidadeDeCompras;
            return View(cliente);
        }
        
        public ActionResult CadastroItens()
        {
            var itens = new Item()
            {
                Id = 1,
                Valor = 20,
                Descricao = "Limpeza",
                Estoque = 10

            };
            ViewData["Id"] = itens.Id;
            ViewData["Valor"] = itens.Valor;
            ViewData["Descricao"] = itens.Descricao;
            ViewData["Estoque"] = itens.Estoque;
            return View(itens);
        }
        public ActionResult CadastroVendas()
        {
            var vendas = new Venda()
            {
                Valor = 20,
                IdItem = 2,
                Quantidade = 1,
                Cliente = 1
            };
            ViewData["Valor"] = vendas.Valor;
            ViewData["Item"] = vendas.IdItem;
            ViewData["Quantidade"] = vendas.Quantidade;
            ViewData["Cliente"] = vendas.Cliente;
            return View(vendas);
        }

        [HttpPost]
        public ActionResult ListagemCliente(int ClienteId, string Nome, int DataDeNascimento, string Endereço, int QuantidadeDeCompras)
        {
            ViewData["ClienteId"] = ClienteId;
            ViewData["Nome"] = Nome;
            ViewData["DataDeNascimento"] = DataDeNascimento;
            ViewData["Endereço"] = Endereço;
            ViewData["QuantidadeDeCompras"] = QuantidadeDeCompras;
            return View();

        }
        [HttpPost]
        public ActionResult ListagemItens(FormCollection form)
        {
            ViewData["Id"] = form["Id"];
            ViewData["Valor"] = form["Valor"];
            ViewData["Descricao"] = form["Descricao"];
            ViewData["Estoque"] = form["Estoque"];
            return View();
        }
        [HttpPost]
        public ActionResult ListagemVendas(Venda vendas)
        {
            ViewData["Valor"] = vendas.Valor;
            ViewData["Item"] = vendas.IdItem;
            ViewData["Quantidade"] = vendas.Quantidade;
            ViewData["Cliente"] = vendas.Cliente;
            return View();
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