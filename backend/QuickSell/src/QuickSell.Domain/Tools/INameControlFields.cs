using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSell.Tools
{
    public interface INameControlFields : IToolName
    {
        public Guid Id { get; }
    }
}
