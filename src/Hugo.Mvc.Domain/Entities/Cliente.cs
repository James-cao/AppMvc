using DomainValidation.Validation;
using Hugo.Mvc.Domain.Validation.Clientes;
using System;
using System.Collections.Generic;

namespace Hugo.Mvc.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
			Enderecos = new List<Endereco>();
        }

        public Guid ClienteId { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }

		public ValidationResult ValidationResult { get; set; }

		public bool IsValid()
		{
			// Specification pattern
			// install-package domainvalidation
			ValidationResult = new ClienteEstaConsistenteValidation().Validate(this);
			return ValidationResult.IsValid;
		}
	}
}
