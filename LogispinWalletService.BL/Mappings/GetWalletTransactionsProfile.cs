using AutoMapper;
using LogispinWalletService.BL.Helper;
using LogispinWalletService.BL.Queries.ReturnTypes;
using LogispinWalletService.Data.Models;

namespace LogispinWalletService.BL.Mappings
{
    public class GetWalletTransactionsProfile : Profile
    {
        public GetWalletTransactionsProfile()
        {
            CreateMap<Transaction, WalletTransaction>()
           .ForMember(
               dest => dest.amount,
               opt => opt.MapFrom(src => src.Amount)
           )
           .ForMember(
               dest => dest.transactionStatus,
               opt => opt.MapFrom(src => UtilityHelper.GetEnumDescription(src.Status))
           )
           .ForMember(
               dest => dest.dateCreated,
               opt => opt.MapFrom(src => src.DateCreated)
           )
            .ForMember(
               dest => dest.dateUpdated,
               opt => opt.MapFrom(src => src.DateUpdated)
           );
        }
    }
}
