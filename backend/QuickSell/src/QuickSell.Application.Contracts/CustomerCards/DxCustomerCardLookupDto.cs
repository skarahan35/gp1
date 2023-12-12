using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSell.CustomerCards
{
    public class DxCustomerCardLookupDto
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public Guid? CustomerTypeID { get; set; }
        public Guid? CustomerGroupID { get; set; }
        public string TaxOffice { get; set; }
        public int? TaxNo { get; set; }
        public string TCNumber { get; set; }
        public string AuthorizedPerson { get; set; }
        public string EMail { get; set; }
        public decimal? RiskLimit { get; set; }
    }
}
