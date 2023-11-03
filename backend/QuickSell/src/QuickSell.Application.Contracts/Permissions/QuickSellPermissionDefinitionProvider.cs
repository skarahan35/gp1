using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;
using QuickSell.Localization;


namespace QuickSell.Permissions;

public class QuickSellPermissionDefinitonProvider:PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {

        var myGroup = context.AddGroup(QuickSellPermissions.GroupName,L("Permission:QuickSell "));

        
        var  countryPermission=myGroup.AddPermission(QuickSellPermissions.Countrys.Default,L("Permission:Countrys"));

        countryPermission.AddChild(QuickSellPermissions.Countrys.Create,L("Permission:Create"));
        countryPermission.AddChild(QuickSellPermissions.Countrys.Edit,L("Permission:Edit"));
        countryPermission.AddChild(QuickSellPermissions.Countrys.Delete,L("Permission:Delete"));
            
        
        
        var  cityPermission=myGroup.AddPermission(QuickSellPermissions.Citys.Default,L("Permission:Citys"));

        cityPermission.AddChild(QuickSellPermissions.Citys.Create,L("Permission:Create"));
        cityPermission.AddChild(QuickSellPermissions.Citys.Edit,L("Permission:Edit"));
        cityPermission.AddChild(QuickSellPermissions.Citys.Delete,L("Permission:Delete"));
            
        
        
        var  stock_groupPermission=myGroup.AddPermission(QuickSellPermissions.StockGroups.Default,L("Permission:StockGroups"));

        stock_groupPermission.AddChild(QuickSellPermissions.StockGroups.Create,L("Permission:Create"));
        stock_groupPermission.AddChild(QuickSellPermissions.StockGroups.Edit,L("Permission:Edit"));
        stock_groupPermission.AddChild(QuickSellPermissions.StockGroups.Delete,L("Permission:Delete"));
            
        
        
        var  stock_typePermission=myGroup.AddPermission(QuickSellPermissions.StockTypes.Default,L("Permission:StockTypes"));

        stock_typePermission.AddChild(QuickSellPermissions.StockTypes.Create,L("Permission:Create"));
        stock_typePermission.AddChild(QuickSellPermissions.StockTypes.Edit,L("Permission:Edit"));
        stock_typePermission.AddChild(QuickSellPermissions.StockTypes.Delete,L("Permission:Delete"));
            
        
        
        var  stock_unitPermission=myGroup.AddPermission(QuickSellPermissions.StockUnits.Default,L("Permission:StockUnits"));

        stock_unitPermission.AddChild(QuickSellPermissions.StockUnits.Create,L("Permission:Create"));
        stock_unitPermission.AddChild(QuickSellPermissions.StockUnits.Edit,L("Permission:Edit"));
        stock_unitPermission.AddChild(QuickSellPermissions.StockUnits.Delete,L("Permission:Delete"));
            
        
        
        var  stock_pricePermission=myGroup.AddPermission(QuickSellPermissions.StockPrices.Default,L("Permission:StockPrices"));

        stock_pricePermission.AddChild(QuickSellPermissions.StockPrices.Create,L("Permission:Create"));
        stock_pricePermission.AddChild(QuickSellPermissions.StockPrices.Edit,L("Permission:Edit"));
        stock_pricePermission.AddChild(QuickSellPermissions.StockPrices.Delete,L("Permission:Delete"));
            
        
        
        var  stock_cardPermission=myGroup.AddPermission(QuickSellPermissions.StockCards.Default,L("Permission:StockCards"));

        stock_cardPermission.AddChild(QuickSellPermissions.StockCards.Create,L("Permission:Create"));
        stock_cardPermission.AddChild(QuickSellPermissions.StockCards.Edit,L("Permission:Edit"));
        stock_cardPermission.AddChild(QuickSellPermissions.StockCards.Delete,L("Permission:Delete"));
            
        
        
        var  customer_typePermission=myGroup.AddPermission(QuickSellPermissions.CustomerTypes.Default,L("Permission:CustomerTypes"));

        customer_typePermission.AddChild(QuickSellPermissions.CustomerTypes.Create,L("Permission:Create"));
        customer_typePermission.AddChild(QuickSellPermissions.CustomerTypes.Edit,L("Permission:Edit"));
        customer_typePermission.AddChild(QuickSellPermissions.CustomerTypes.Delete,L("Permission:Delete"));
            
        
        
        var  customer_groupPermission=myGroup.AddPermission(QuickSellPermissions.CustomerGroups.Default,L("Permission:CustomerGroups"));

        customer_groupPermission.AddChild(QuickSellPermissions.CustomerGroups.Create,L("Permission:Create"));
        customer_groupPermission.AddChild(QuickSellPermissions.CustomerGroups.Edit,L("Permission:Edit"));
        customer_groupPermission.AddChild(QuickSellPermissions.CustomerGroups.Delete,L("Permission:Delete"));
            
        
        
        var  customer_addressPermission=myGroup.AddPermission(QuickSellPermissions.CustomerAddresss.Default,L("Permission:CustomerAddresss"));

        customer_addressPermission.AddChild(QuickSellPermissions.CustomerAddresss.Create,L("Permission:Create"));
        customer_addressPermission.AddChild(QuickSellPermissions.CustomerAddresss.Edit,L("Permission:Edit"));
        customer_addressPermission.AddChild(QuickSellPermissions.CustomerAddresss.Delete,L("Permission:Delete"));
            
        
        
        var  customer_cardPermission=myGroup.AddPermission(QuickSellPermissions.CustomerCards.Default,L("Permission:CustomerCards"));

        customer_cardPermission.AddChild(QuickSellPermissions.CustomerCards.Create,L("Permission:Create"));
        customer_cardPermission.AddChild(QuickSellPermissions.CustomerCards.Edit,L("Permission:Edit"));
        customer_cardPermission.AddChild(QuickSellPermissions.CustomerCards.Delete,L("Permission:Delete"));
            
        
        
        var  districtPermission=myGroup.AddPermission(QuickSellPermissions.Districts.Default,L("Permission:Districts"));

        districtPermission.AddChild(QuickSellPermissions.Districts.Create,L("Permission:Create"));
        districtPermission.AddChild(QuickSellPermissions.Districts.Edit,L("Permission:Edit"));
        districtPermission.AddChild(QuickSellPermissions.Districts.Delete,L("Permission:Delete"));
            
        
        
        var  movement_headerPermission=myGroup.AddPermission(QuickSellPermissions.MovementHeaders.Default,L("Permission:MovementHeaders"));

        movement_headerPermission.AddChild(QuickSellPermissions.MovementHeaders.Create,L("Permission:Create"));
        movement_headerPermission.AddChild(QuickSellPermissions.MovementHeaders.Edit,L("Permission:Edit"));
        movement_headerPermission.AddChild(QuickSellPermissions.MovementHeaders.Delete,L("Permission:Delete"));
            
        
        
        var  movement_detailsPermission=myGroup.AddPermission(QuickSellPermissions.MovementDetailss.Default,L("Permission:MovementDetailss"));

        movement_detailsPermission.AddChild(QuickSellPermissions.MovementDetailss.Create,L("Permission:Create"));
        movement_detailsPermission.AddChild(QuickSellPermissions.MovementDetailss.Edit,L("Permission:Edit"));
        movement_detailsPermission.AddChild(QuickSellPermissions.MovementDetailss.Delete,L("Permission:Delete"));
            
        
        
        var  companyPermission=myGroup.AddPermission(QuickSellPermissions.Companys.Default,L("Permission:Companys"));

        companyPermission.AddChild(QuickSellPermissions.Companys.Create,L("Permission:Create"));
        companyPermission.AddChild(QuickSellPermissions.Companys.Edit,L("Permission:Edit"));
        companyPermission.AddChild(QuickSellPermissions.Companys.Delete,L("Permission:Delete"));
            
        
        }
            private static LocalizableString L(string name)
        {
            return LocalizableString.Create<QuickSellResource>(name);
        }


    }

