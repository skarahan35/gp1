using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Data;
using QuickSell.StockGroups;
using QuickSell.StockTypes;
using QuickSell.StockUnits;
using QuickSell.StockPrices;
using QuickSell.StockCards;
using QuickSell.CustomerTypes;
using QuickSell.CustomerGroups;
using QuickSell.CustomerCards;
using QuickSell.Districts;
using QuickSell.MovementHeaders;
using QuickSell.Countries;
using QuickSell.Cities;
using QuickSell.CustomerAddresses;
using QuickSell.Companies;
using QuickSell.MovementDetails;

namespace QuickSell.EntityFrameworkCore
{
    [ConnectionStringName(QuickSellDbProperties.ConnectionStringName)]
    public class QuickSellDbContext :AbpDbContext<QuickSellDbContext>,IQuickSellDbContext
    {
       



        public QuickSellDbContext(DbContextOptions<QuickSellDbContext> options)
        : base(options)
    {

    }
       
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<StockGroup> StockGroups { get; set; }
        public DbSet<StockType> StockTypes { get; set; }
        public DbSet<StockUnit> StockUnits { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }
        public DbSet<StockCard> StockCards { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<CustomerGroup> CustomerGroups { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerCard> CustomerCards { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<MovementHeader> MovementHeaders { get; set; }
        public DbSet<MovementDetail> MovementDetails { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<Country>(e=>{

                  e.Property(e => e.Code); 
                  e.Property(e => e.Name); 
                      });
                builder.Entity<City>(e=>{

                  e.Property(e => e.Code); 
                  e.Property(e => e.Name); 
                      });
                builder.Entity<StockGroup>(e=>{

                  e.Property(e => e.Code); 
                  e.Property(e => e.Name); 
                      });
                builder.Entity<StockType>(e=>{

                  e.Property(e => e.Code); 
                  e.Property(e => e.Name); 
                  e.Property(e => e.Condition); 
                      });
                builder.Entity<StockUnit>(e=>{

                  e.Property(e => e.Code); 
                  e.Property(e => e.Name); 
                      });
                builder.Entity<StockPrice>(e=>{

                  e.Property(e => e.StockCardID); 
                  e.Property(e => e.Price); 
                  e.Property(e => e.PriceType); 
                e.HasOne<StockCard>().WithMany().HasForeignKey(x => x.StockCardID).IsRequired();
                      });
                builder.Entity<StockCard>(e=>{

                  e.Property(e => e.Code); 
                  e.Property(e => e.Name); 
                  e.Property(e => e.StockTypeID); 
                  e.Property(e => e.StockUnitID); 
                  e.Property(e => e.StockGroupID); 
                  e.Property(e => e.TransferredQuantity); 
                  e.Property(e => e.AvailableQuantity); 
                  e.Property(e => e.TotalEntryQuantity); 
                  e.Property(e => e.TotalOutputQuantity); 
                  e.Property(e => e.VATRate); 
                  e.Property(e => e.DiscountRate); 
                  e.Property(e => e.CurrencyType); 
                  e.Property(e => e.Price1); 
                  e.Property(e => e.Price2); 
                  e.Property(e => e.Price3); 
                e.HasOne<StockType>().WithMany().HasForeignKey(x => x.StockTypeID).IsRequired();
                e.HasOne<StockUnit>().WithMany().HasForeignKey(x => x.StockUnitID).IsRequired();
                e.HasOne<StockGroup>().WithMany().HasForeignKey(x => x.StockGroupID).IsRequired();
                      });
                builder.Entity<CustomerType>(e=>{

                  e.Property(e => e.Code); 
                  e.Property(e => e.Name); 
                      });
                builder.Entity<CustomerGroup>(e=>{

                  e.Property(e => e.Code); 
                  e.Property(e => e.Name); 
                      });
                builder.Entity<CustomerAddress>(e=>{

                  e.Property(e => e.AddressCode); 
                  e.Property(e => e.Road); 
                  e.Property(e => e.Street); 
                  e.Property(e => e.BuildingName); 
                  e.Property(e => e.BuildingNo); 
                  e.Property(e => e.PostCode);
                  e.Property(e => e.CustomerCardId);
                  e.Property(e => e.DistrictId); 
                  e.Property(e => e.CityId); 
                  e.Property(e => e.CountryId); 
                e.HasOne<CustomerCard>().WithMany().HasForeignKey(x => x.CustomerCardId).IsRequired();
                e.HasOne<District>().WithMany().HasForeignKey(x => x.DistrictId).IsRequired();
                e.HasOne<City>().WithMany().HasForeignKey(x => x.CityId).IsRequired();
                e.HasOne<Country>().WithMany().HasForeignKey(x => x.CountryId).IsRequired();
                      });
                builder.Entity<CustomerCard>(e=>{

                  e.Property(e => e.Code); 
                  e.Property(e => e.Name); 
                  e.Property(e => e.CustomerTypeID); 
                  e.Property(e => e.CustomerGroupID); 
                  e.Property(e => e.TaxOffice); 
                  e.Property(e => e.TaxNo); 
                  e.Property(e => e.TCNumber); 
                  e.Property(e => e.AuthorizedPerson); 
                  e.Property(e => e.EMail); 
                  e.Property(e => e.RiskLimit); 
                e.HasOne<CustomerType>().WithMany().HasForeignKey(x => x.CustomerTypeID).IsRequired();
                e.HasOne<CustomerGroup>().WithMany().HasForeignKey(x => x.CustomerGroupID).IsRequired();
                      });
                builder.Entity<District>(e=>{

                  e.Property(e => e.Code); 
                  e.Property(e => e.Name); 
                      });
                builder.Entity<MovementHeader>(e=>{

                  e.Property(e => e.TypeCode); 
                  e.Property(e => e.ReceiptNo); 
                  e.Property(e => e.CustomerCardID); 
                  e.Property(e => e.FirstAmount); 
                  e.Property(e => e.DiscountAmount); 
                  e.Property(e => e.VATAmount); 
                  e.Property(e => e.TotalAmount); 
                e.HasOne<CustomerCard>().WithMany().HasForeignKey(x => x.CustomerCardID).IsRequired();
                      });
                builder.Entity<MovementDetail>(e=>{

                  e.Property(e => e.TypeCode); 
                  e.Property(e => e.ReceiptNo); 
                  e.Property(e => e.StockCardID); 
                  e.Property(e => e.Quantity); 
                  e.Property(e => e.Price); 
                  e.Property(e => e.DiscountRate); 
                  e.Property(e => e.DiscountAmount); 
                  e.Property(e => e.VATRate); 
                  e.Property(e => e.VATAmount); 
                e.HasOne<StockCard>().WithMany().HasForeignKey(x => x.StockCardID).IsRequired();
                      });
                builder.Entity<Company>(e=>{

                  e.Property(e => e.CompanyName); 
                  e.Property(e => e.Road); 
                  e.Property(e => e.Street); 
                  e.Property(e => e.BuildingName); 
                  e.Property(e => e.BuildingNo); 
                  e.Property(e => e.PostCode); 
                  e.Property(e => e.DistrictID); 
                  e.Property(e => e.CityID); 
                  e.Property(e => e.CountryID); 
                  e.Property(e => e.TaxNo); 
                  e.Property(e => e.TaxOffice); 
                  e.Property(e => e.Currency); 
                  e.Property(e => e.DateFormat); 
                  e.Property(e => e.WebSite); 
                  e.Property(e => e.IncomingMail); 
                  e.Property(e => e.SendingMail); 
                  e.Property(e => e.WorkingYear); 
                  e.Property(e => e.QuantityDecimal); 
                  e.Property(e => e.PriceDecimal); 
                  e.Property(e => e.AmountDecimal); 
                e.HasOne<District>().WithMany().HasForeignKey(x => x.DistrictID).IsRequired();
                e.HasOne<City>().WithMany().HasForeignKey(x => x.CityID).IsRequired();
                e.HasOne<Country>().WithMany().HasForeignKey(x => x.CountryID).IsRequired();
                });
        
        }
    }
}



            