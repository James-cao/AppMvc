using Dapper;
using Hugo.Mvc.Domain.Entities;
using Hugo.Mvc.Domain.Interfaces.Repository;
using Hugo.Mvc.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hugo.Mvc.Infra.Data.Repository
{
	public class ClienteRepository : Repository<Cliente>, IClienteRepository
	{
		public ClienteRepository(MvcContext context)
			: base(context)
		{

		}

		public IEnumerable<Cliente> ObterAtivos()
		{
			return Buscar(c => c.Ativo);
		}

		public Cliente ObterPorCpf(string cpf)
		{
			return Buscar(c => c.CPF == cpf).FirstOrDefault();
		}

		public Cliente ObterPorEmail(string email)
		{
			return Buscar(c => c.Email == email).FirstOrDefault();
		}

		public override void Remover(Guid id)
		{
			var cliente = ObterPorId(id);
			cliente.Ativo = false;
			Atualizar(cliente);
		}

		public override IEnumerable<Cliente> ObterTodos()
		{
			#region [ Entity ]
			//return Db.Clientes.OrderBy(c => c.Nome);  
			#endregion

			//DAPPER
			var cn = Db.Database.Connection;
			var sql = @"SELECT * FROM CLIENTES";

			return cn.Query<Cliente>(sql);
		}

		public override Cliente ObterPorId(Guid id)
		{
			var cn = Db.Database.Connection;
			var sql = @" SELECT * FROM Clientes c " +
						"LEFT JOIN Enderecos e " +
						"ON c.ClienteId = e.ClienteId " +
						"WHERE c.ClienteId = @sid";

			var cliente = cn.Query<Cliente, Endereco, Cliente>(sql,
				(c, e) =>
				{
					c.Enderecos.Add(e);
					return c;
				}, new { sid = id }, splitOn: "ClienteId, EnderecoId");

			return cliente.FirstOrDefault();
		}
	}
}
