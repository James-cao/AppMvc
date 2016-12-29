using AutoMapper;
using Hugo.Mvc.Application.ViewModels;
using Hugo.Mvc.Domain.Entities;

namespace Hugo.Mvc.Application.AutoMapper
{
	public class DomainToViewModelMappingProfile : Profile
	{
		protected override void Configure()
		{
			CreateMap<Cliente, ClienteViewModel>();
			CreateMap<Cliente, ClienteEnderecoViewModel>();
			CreateMap<Endereco, EnderecoViewModel>();
			CreateMap<Endereco, ClienteEnderecoViewModel>();
		}
	}
}
