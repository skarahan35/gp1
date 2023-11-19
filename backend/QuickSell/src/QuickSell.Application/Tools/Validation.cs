﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;

namespace QuickSell.Tools
{
    public class Validation<ENT, TResource> where ENT : class,IControlFields
    {
        //private IStringLocalizer<QuickSellResource> _localizer;

        //public Validation(IStringLocalizer<QuickSellResource> localizer)
        //{
        //    _localizer = localizer;
        //}
        //public async Task CodeControl<T>(T input, Func<T, string> getCodeFunc) where T : class
        //{
        //    var code = getCodeFunc(input);
        //    if (existingItem != null)
        //    {
        //        throw new UserFriendlyException(string.Format(_localizer["Code:AlreadyExist"]));
        //    }
        //    else if (string.IsNullOrEmpty(code))
        //    {
        //        throw new UserFriendlyException(string.Format(_localizer["Code:Null"]));
        //    }
        //}
        //public async Task CodeControl<T>(T input, Func<T, string> getCodeFunc, Func<string, Task<T>> findExistingItemAsync) where T : class
        //{
        //    var code = getCodeFunc(input);
        //    var existingItem = await findExistingItemAsync(code);

        //    if (existingItem != null)
        //    {
        //        throw new UserFriendlyException(string.Format(_localizer["Code:AlreadyExist"]));
        //    }
        //    else if (string.IsNullOrEmpty(code))
        //    {
        //        throw new UserFriendlyException(string.Format(_localizer["Code:Null"]));
        //    }
        //}
        public static async Task<bool> CodeControl(ITool input, IQueryable<ENT?> qry, IStringLocalizer<TResource> localizer)
        {
            if (await qry.AnyAsync((ENT x) => x.Code == input.Code && x.Id != input.Id))
            {
                throw new UserFriendlyException(string.Format(localizer["Code:AlreadyExist"]));
            }
            else if (input.Code.IsNullOrWhiteSpace())
            {
                throw new UserFriendlyException(string.Format(localizer["Code:Null"]));
            }
            return true;
        }
        
    }
}