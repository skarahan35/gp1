using QuickSell.StockGroups;
using QuickSell.StockTypes;
using QuickSell.StockUnits;
using QuickSell.StockPrices;
using QuickSell.StockCards;
using QuickSell.CustomerTypes;
using QuickSell.CustomerGroups;
using QuickSell.CustomerCards;
using QuickSell.Districts;
using QuickSell.MovementHeaders;
using AutoMapper;
using QuickSell.Countries;
using QuickSell.Cities;
using QuickSell.CustomerAddresses;
using QuickSell.MovementDetails;
using QuickSell.Companies;

namespace QuickSell

{
    public class QuickSellApplicationAutoMapperProfile : Profile
    {
        public QuickSellApplicationAutoMapperProfile()
        {

            CreateMap<Country, CountryDto>();
            CreateMap<City, CityDto>();
            CreateMap<StockGroup, StockGroupDto>();
            CreateMap<StockGroupDto, StockGroup>()
            .ForMember(dest => dest.TenantId, opt => opt.Ignore())
            .ForMember(dest => dest.ExtraProperties, opt => opt.Ignore());
            CreateMap<StockType, StockTypeDto>();
            CreateMap<StockTypeDto, StockType>()
            .ForMember(dest => dest.TenantId, opt => opt.Ignore())
            .ForMember(dest => dest.ExtraProperties, opt => opt.Ignore());
            CreateMap<StockUnit, StockUnitDto>();
            CreateMap<StockUnitDto, StockUnit>()
            .ForMember(dest => dest.TenantId, opt => opt.Ignore())
            .ForMember(dest => dest.ExtraProperties, opt => opt.Ignore());
            CreateMap<StockPrice, StockPriceDto>();
            CreateMap<StockCard, StockCardDto>();
            CreateMap<CustomerType, CustomerTypeDto>();
            CreateMap<CustomerGroup, CustomerGroupDto>();
            CreateMap<CustomerAddress, CustomerAddressDto>();
            CreateMap<CustomerCard, CustomerCardDto>();
            CreateMap<District, DistrictDto>();
            CreateMap<MovementHeader, MovementHeaderDto>();
            CreateMap<MovementDetail, MovementDetailDto>();
            CreateMap<Company, CompanyDto>();
        }
    }

}