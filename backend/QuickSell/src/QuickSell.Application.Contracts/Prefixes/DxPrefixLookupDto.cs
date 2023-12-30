using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuickSell.Prefixes
{
    public class DxPrefixLookupDto
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Parameter { get; set; }
        public bool? BeUsed { get; set; }
    }
}
