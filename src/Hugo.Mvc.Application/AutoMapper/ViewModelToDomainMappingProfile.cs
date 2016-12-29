using AutoMapper;
using Hugo.Mvc.Application.ViewModels;
using Hugo.Mvc.Domain.Entities;

namespace Hugo.Mvc.Application.AutoMapper
{
	class ViewModelToDomainMappingProfile : Profile
	{
		protected override void Configure()
		{
			CreateMap<ClienteViewModel, Cliente>();
			CreateMap<ClienteEnderecoViewModel, Cliente>();
			CreateMap<EnderecoViewModel, Endereco>();
			CreateMap<ClienteEnderecoViewModel, Endereco>();
		}
	}
}
