using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSell.CustomerAddresses
{
    public class DxCustomerAddressLookupDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Road { get; set; }
        public string Street { get; set; }
        public string BuildingName { get; set; }
        public int? BuildingNo { get; set; }
        public int? PostCode { get; set; }
        public Guid? CustomerCardId { get; set; }
        public Guid? DistrictId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? CountryId { get; set; }
    }
}
