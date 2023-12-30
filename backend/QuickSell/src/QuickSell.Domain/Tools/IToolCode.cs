using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSell.Tools
{
    public interface IToolCode
    {
        public Guid Id { get;}
        public string? Code { get; set; }
    }
}
