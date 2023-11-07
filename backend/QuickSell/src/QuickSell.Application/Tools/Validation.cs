using Microsoft.Extensions.Localization;
using QuickSell.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace QuickSell.Tools
{
    public class Validation
    {
        private static IStringLocalizer<QuickSellResource> _localizer;
        public static void Initialize(IStringLocalizer<QuickSellResource> localizer)
        {
            _localizer= localizer;
        }
        public async Task CodeControl<T>(T input, Func<T, string> getCodeFunc) where T : class
        {
            var code = getCodeFunc(input);
            if (code != null)
            {
                throw new UserFriendlyException(string.Format(_localizer["Code:AlreadyExist"]));
            }
            else if (string.IsNullOrEmpty(code))
            {
                throw new UserFriendlyException(string.Format(_localizer["Code:Null"]));
            }
        }
    }
}
