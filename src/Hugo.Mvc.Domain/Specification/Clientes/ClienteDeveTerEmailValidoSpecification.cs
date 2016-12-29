using DomainValidation.Interfaces.Specification;
using Hugo.Mvc.Domain.Entities;
using Hugo.Mvc.Domain.Validation.Documentos;

namespace Hugo.Mvc.Domain.Specification.Clientes
{
	public class ClienteDeveTerEmailValidoSpecification : ISpecification<Cliente>
	{
		public bool IsSatisfiedBy(Cliente cliente)
		{
			return EmailValidation.Validar(cliente.Email);
		}
	}
}
