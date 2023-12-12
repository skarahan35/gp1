

using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using QuickSell.Shared;
using System.Collections.Generic;
using DevExtreme.AspNet.Data.ResponseModel;

namespace QuickSell.Companies

{
    public interface ICompaniesAppService: IApplicationService
    {
        Task<LoadResult> GetListCompany(DataSourceLoadOptions loadOptions);
        Task<DxCompanyLookupDto?> GetCompanyByID(Guid? id);
        Task<CompanyDto> AddCompany(CompanyDto input);
        Task<CompanyDto> UpdateCompany(Guid id, IDictionary<string, object> input);
        Task DeleteCompany(Guid id);
    }
}


