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
using QuickSell.EndUsers;
using QuickSell.StockSubGroups;
using QuickSell.CustomerSubGroups;
using AutoMapper;
using QuickSell.Countries;
using QuickSell.Cities;
using QuickSell.CustomerAddresses;
using QuickSell.MovementDetails;
using QuickSell.Companies;
using QuickSell.Prefixes;

namespace QuickSell

{
    public class QuickSellApplicationAutoMapperProfile : Profile
    {
        public QuickSellApplicationAutoMapperProfile()
        {

            CreateMap<Country, CountryDto>();
            CreateMap<City, CityDto>();
            CreateMap<StockGroup, StockGroupDto>();
            CreateMap<StockType, StockTypeDto>();
            CreateMap<StockUnit, StockUnitDto>();
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
            CreateMap<EndUser, EndUserDto>();
            CreateMap<StockSubGroup, StockSubGroupDto>();
            CreateMap<CustomerSubGroup, CustomerSubGroupDto>();
            CreateMap<Prefix, PrefixDto>();
        }
    }

}