using Hugo.Mvc.Application.Interfaces;
using Hugo.Mvc.Application.ViewModels;
using Hugo.Mvc.Infra.CrossCutting.MvcFilters;
using System;
using System.Net;
using System.Web.Mvc;

namespace Hugo.Mvc.UI.Site.Controllers
{
	// PermissoesClientes
	//	-> CL = Claim Listar Todos
	//	-> CI = Claim Incluir
	//	-> CE = Claim Editar
	//	-> CD = Claim Ver Detalhes
	//	-> CX = Claim Excluir

	[Authorize]
	[RoutePrefix("gestao/cadastros")]
	public class ClientesController : Controller
	{
		private readonly IClienteAppService _clienteAppService;

		public ClientesController(IClienteAppService clienteAppService)
		{
			_clienteAppService = clienteAppService;
		}

		// GET: Clientes
		[ClaimsAuthorize("PermissoesClientes", "CL")]
		[Route("listar-clientes")]
		public ActionResult Index()
		{
			return View(_clienteAppService.ObterTodos());
		}

		// GET: Clientes/Details/5
		[ClaimsAuthorize("PermissoesClientes", "CD")]
		[Route("{id:guid}/detalhe-cliente")]
		public ActionResult Details(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

			if (clienteViewModel == null)
			{
				return HttpNotFound();
			}
			return View(clienteViewModel);
		}

		// GET: Clientes/Create
		[ClaimsAuthorize("PermissoesClientes", "CI")]
		[Route("novo-cliente")]
		public ActionResult Create()
		{
			return View();
		}

		// POST: Clientes/Create
		[ClaimsAuthorize("PermissoesClientes", "CI")]
		[Route("novo-cliente")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
		{
			if (ModelState.IsValid)
			{
				clienteEnderecoViewModel = _clienteAppService.Adicionar(clienteEnderecoViewModel);

				if (!clienteEnderecoViewModel.ValidationResult.IsValid)
				{
					foreach (var erro in clienteEnderecoViewModel.ValidationResult.Erros)
					{
						ModelState.AddModelError(string.Empty, erro.Message);
					}

					return View(clienteEnderecoViewModel);
				}

				return RedirectToAction("Index");
			}

			return View(clienteEnderecoViewModel);
		}

		// GET: Clientes/Edit/5
		[ClaimsAuthorize("PermissoesClientes", "CE")]
		[Route("{id:guid}/editar-cliente")]
		public ActionResult Edit(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var clienteViewModel = _clienteAppService.ObterPorId(id.Value);
			if (clienteViewModel == null)
			{
				return HttpNotFound();
			}
			return View(clienteViewModel);
		}

		// POST: Clientes/Edit/5
		[ClaimsAuthorize("PermissoesClientes", "CE")]
		[Route("{id:guid}/editar-cliente")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(ClienteViewModel clienteViewModel)
		{
			if (ModelState.IsValid)
			{
				_clienteAppService.Atualizar(clienteViewModel);
				return RedirectToAction("Index");
			}
			return View(clienteViewModel);
		}

		// GET: Clientes/Delete/5
		[ClaimsAuthorize("PermissoesClientes", "CX")]
		[Route("{id:guid}/excluir-cliente")]
		public ActionResult Delete(Guid? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var clienteViewModel = _clienteAppService.ObterPorId(id.Value);
			if (clienteViewModel == null)
			{
				return HttpNotFound();
			}
			return View(clienteViewModel);
		}

		// POST: Clientes/Delete/5
		[ClaimsAuthorize("PermissoesClientes", "CX")]
		[Route("{id:guid}/excluir-cliente")]
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(Guid id)
		{
			_clienteAppService.Remover(id);
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_clienteAppService.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
