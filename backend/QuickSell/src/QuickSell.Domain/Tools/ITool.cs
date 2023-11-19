using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSell.Tools
{
    public interface ITool
    {
        public Guid Id { get;}
        public string? Code { get; set; }
        public string? Name { get; set; }
    }
}
