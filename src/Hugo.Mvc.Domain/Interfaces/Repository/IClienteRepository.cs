using Hugo.Mvc.Domain.Entities;
using System.Collections.Generic;

namespace Hugo.Mvc.Domain.Interfaces.Repository
{
	public interface IClienteRepository : IRepository<Cliente>
	{
		Cliente ObterPorCpf(string cpf);

		Cliente ObterPorEmail(string email);

		IEnumerable<Cliente> ObterAtivos();
	}
}
