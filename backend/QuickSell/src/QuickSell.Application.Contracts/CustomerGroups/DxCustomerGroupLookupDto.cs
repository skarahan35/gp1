using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSell.CustomerGroups
{
    public class DxCustomerGroupLookupDto
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}
