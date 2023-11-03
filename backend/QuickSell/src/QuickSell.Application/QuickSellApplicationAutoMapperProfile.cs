
using QuickSell.Countrys;
using QuickSell.Citys;
using QuickSell.StockGroups;
using QuickSell.StockTypes;
using QuickSell.StockUnits;
using QuickSell.StockPrices;
using QuickSell.StockCards;
using QuickSell.CustomerTypes;
using QuickSell.CustomerGroups;
using QuickSell.CustomerAddresss;
using QuickSell.CustomerCards;
using QuickSell.Districts;
using QuickSell.MovementHeaders;
using QuickSell.MovementDetailss;
using QuickSell.Companys;
using AutoMapper;
using System.Linq;



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
            CreateMap<MovementDetails, MovementDetailsDto>();
            CreateMap<Company, CompanyDto>();
        }
    }

}