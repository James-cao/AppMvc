using DomainValidation.Validation;
using Hugo.Mvc.Domain.Entities;
using Hugo.Mvc.Domain.Specification.Clientes;

namespace Hugo.Mvc.Domain.Validation.Clientes
{
	public class ClienteEstaConsistenteValidation : Validator<Cliente>
	{
		public ClienteEstaConsistenteValidation()
		{
			var CPFCliente = new ClienteDeveTerCpfValidoSpecification();
			var clienteEmail = new ClienteDeveTerEmailValidoSpecification();
			var clienteMaiorIdade = new ClienteDeveSerMaiorDeIdadeSpecification();

			base.Add("CPFCliente", new Rule<Cliente>(CPFCliente, "Cpf inválido."));
			base.Add("clienteEmail", new Rule<Cliente>(clienteEmail, "Email inválido."));
			base.Add("clienteMaiorIdade", new Rule<Cliente>(clienteMaiorIdade, "Cliente não tem maior idade para o cadastro."));
		}
	}
}
