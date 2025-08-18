using AutoMapper;
using BankPro.Core.DTOs;
using BankPro.Core.Entities;

namespace BankPro.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            CreateMap<Customer, CustomerRequestDTO>().ReverseMap();
            CreateMap<Customer, CustomerResponseDTO>();

            CreateMap<Account, AccountRequestDTO>().ReverseMap();
            CreateMap<Account, AccountResponseDTO>()
            .ForMember(dest => dest.AccHolder,
                       opt => opt.MapFrom(src => src.AccHolder.Name));

            CreateMap<Transaction, TransactionRequestDTO>().ReverseMap();
            CreateMap<Transaction, TransactionResponseDTO>();
        }
    }
}
