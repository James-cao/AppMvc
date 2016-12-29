using DomainValidation.Interfaces.Specification;
using Hugo.Mvc.Domain.Entities;
using System;

namespace Hugo.Mvc.Domain.Specification.Clientes
{
	public class ClienteDeveSerMaiorDeIdadeSpecification : ISpecification<Cliente>
	{
		public bool IsSatisfiedBy(Cliente cliente)
		{
			return DateTime.Now.Year - cliente.DataNascimento.Year >= 18;
		}
	}
}
