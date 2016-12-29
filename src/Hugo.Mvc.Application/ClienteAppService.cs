using AutoMapper;
using Hugo.Mvc.Application.Interfaces;
using Hugo.Mvc.Application.ViewModels;
using Hugo.Mvc.Domain.Entities;
using Hugo.Mvc.Domain.Interfaces.Services;
using Hugo.Mvc.Infra.Data.UnitOfWork;
using System;
using System.Collections.Generic;

namespace Hugo.Mvc.Application
{
	public class ClienteAppService : AppService, IClienteAppService
	{
		private readonly IClienteService _clienteService;

		public ClienteAppService(IClienteService clienteService, IUnitOfWork uow)
			: base(uow)
		{
			_clienteService = clienteService;
		}

		public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
		{
			var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel);
			var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel);

			cliente.Enderecos.Add(endereco);

			var clienteReturn = _clienteService.Adicionar(cliente);

			//Verificar se o dominio não criticou nada!
			if (clienteReturn.ValidationResult.IsValid)
				Commit();

			return Mapper.Map<ClienteEnderecoViewModel>(clienteReturn);
		}

		public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
		{
			var cliente = Mapper.Map<Cliente>(clienteViewModel);
			_clienteService.Atualizar(cliente);

			return clienteViewModel;
		}

		public ClienteViewModel ObterPorCpf(string cpf)
		{
			return Mapper.Map<ClienteViewModel>(_clienteService.ObterPorCpf(cpf));
		}

		public ClienteViewModel ObterPorEmail(string email)
		{
			return Mapper.Map<ClienteViewModel>(_clienteService.ObterPorEmail(email));
		}

		public ClienteViewModel ObterPorId(Guid id)
		{
			return Mapper.Map<ClienteViewModel>(_clienteService.ObterPorId(id));
		}

		public IEnumerable<ClienteViewModel> ObterTodos()
		{
			return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteService.ObterAtivos());
		}

		public void Remover(Guid id)
		{
			_clienteService.Remover(id);
		}

		public void Dispose()
		{
			_clienteService.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
