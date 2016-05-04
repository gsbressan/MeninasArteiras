using MeninasArteiras.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeninasArteiras.Controllers
{
    public class ClienteController : Controller
    {
        Contexto db = new Contexto();
        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            return View("Index", db.Clientes.ToList());
        }

        #region Mostrar detalhes de um cliente específico

        //
        // Cria um objeto Cliente usando como referência as informações localizadas no Banco de Dados, na tabela de Clientes, atravéz do Código de Identidicação do Cliente.
        public ActionResult Details(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            return View("Details", cliente);
        }

        #endregion

        #region Criar novo Cliente no Banco de Dados
        //
        // Ação GET de criar novo cliente: Controlador cria um novo objeto CLIENTE vazio e passa ele para a Visão de Criação de novos Clientes.
        public ActionResult Create()
        {
            Cliente newCliente = new Cliente();
            return View("Create", newCliente);
        }

        //
        // Ação POST de criar novo cliente: Controlador verifica se os dados digitados satisfazem o modelo definido. Se sim adiciona o novo cliente no Banco de Dados, salva e retorna para a lista de clientes.
        // Se não retorna o objeto referente ao Novo Cliente de volta para a tela de criação para que o usuário resolva as inconsistências.
        [HttpPost]
        public ActionResult Create(Cliente newCliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(newCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", newCliente);
            }
        }
        #endregion

        #region Editar os dados de um cliente específico

        //
        // Ação GET para edição dos dados de um Cliente: Cria um objeto Cliente utilizando dados localizados no Banco de Dados, na tabela de Clientes, através do Código de Identificação do Cliente.
        public ActionResult Edit(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View("Edit", cliente);
        }

        //
        //Ação POST para edição dos dados de um Cliente: Se os dados digitados estiverem de acordo com o Modelo definido, altera os dados do Cliente no Banco de Dados, salva e retorna para a lista de Clientes.
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", cliente);
            }
        }

        #endregion

        #region Apagar um cliente específico do Banco de Dados

        //
        //Ação GET
        public ActionResult Delete(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View("Delete", cliente);
        }

        //
        //Ação POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        #endregion

    }
}
