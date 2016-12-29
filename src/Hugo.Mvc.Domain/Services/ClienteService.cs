using Hugo.Mvc.Domain.Entities;
using Hugo.Mvc.Domain.Interfaces.Repository;
using Hugo.Mvc.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Hugo.Mvc.Domain.Services
{
	public class ClienteService : IClienteService
	{
		private readonly IClienteRepository _clienteRepository;

		public ClienteService(IClienteRepository clienteRepository)
		{
			this._clienteRepository = clienteRepository;
		}

		public Cliente Adicionar(Cliente cliente)
		{
			if (!cliente.IsValid())
				return cliente;

			return _clienteRepository.Adicionar(cliente);
		}

		public Cliente Atualizar(Cliente cliente)
		{
			return _clienteRepository.Atualizar(cliente);
		}

		public IEnumerable<Cliente> ObterAtivos()
		{
			return _clienteRepository.ObterAtivos();
		}

		public Cliente ObterPorCpf(string cpf)
		{
			return _clienteRepository.ObterPorCpf(cpf);
		}

		public Cliente ObterPorEmail(string email)
		{
			return _clienteRepository.ObterPorEmail(email);
		}

		public Cliente ObterPorId(Guid id)
		{
			return _clienteRepository.ObterPorId(id);
		}

		public IEnumerable<Cliente> ObterTodos()
		{
			return _clienteRepository.ObterTodos();
		}

		public void Remover(Guid id)
		{
			_clienteRepository.Remover(id);
		}

		public void Dispose()
		{
			_clienteRepository.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
