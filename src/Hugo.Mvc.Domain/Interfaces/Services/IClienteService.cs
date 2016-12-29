using Hugo.Mvc.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Hugo.Mvc.Domain.Interfaces.Services
{
	public interface IClienteService : IDisposable
	{
		Cliente Adicionar(Cliente cliente);

		Cliente ObterPorId(Guid id);

		IEnumerable<Cliente> ObterAtivos();

		IEnumerable<Cliente> ObterTodos();

		Cliente ObterPorCpf(string cpf);

		Cliente ObterPorEmail(string email);

		Cliente Atualizar(Cliente cliente);

		void Remover(Guid id);
	}
}
