using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSell.Tools
{
    public interface IToolName
    {
        public Guid Id { get; }
        public string? Name { get; set; }
    }
}
