using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;

namespace Microsoft.eShopWeb.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext catalogContext, ILogger logger, int retry = 0)
        {
            var retryForAvailability = retry;
            try
            {
                if (catalogContext.Database.IsSqlServer())
                {
                    // Eliminar la base de datos si existe
                    if (catalogContext.Database.CanConnect())
                    {
                        await catalogContext.Database.EnsureDeletedAsync();
                    }

                    await catalogContext.Database.EnsureCreatedAsync();
                }

                await SeedData(catalogContext);

                logger.LogInformation("Database seeded successfully.");
            }
            catch (Exception ex)
            {
                if (retryForAvailability >= 10) throw;

                retryForAvailability++;

                logger.LogError(ex.Message);
                await SeedAsync(catalogContext, logger, retryForAvailability);
                throw;
            }
        }

        private static async Task SeedData(CatalogContext catalogContext)
        {
            if (!await catalogContext.CatalogBrands.AnyAsync())
            {
                await catalogContext.CatalogBrands.AddRangeAsync(GetPreconfiguredCatalogBrands());
                await catalogContext.SaveChangesAsync();
            }

            if (!await catalogContext.CatalogTypes.AnyAsync())
            {
                await catalogContext.CatalogTypes.AddRangeAsync(GetPreconfiguredCatalogTypes());
                await catalogContext.SaveChangesAsync();
            }

            if (!await catalogContext.CatalogItems.AnyAsync())
            {
                await catalogContext.CatalogItems.AddRangeAsync(GetPreconfiguredItems());
                await catalogContext.SaveChangesAsync();
            }

            if (!await catalogContext.CatalogLocalities.AnyAsync())
            {
                await catalogContext.CatalogLocalities.AddRangeAsync(GetPreconfiguredCatalogoLocalidades());
                await catalogContext.SaveChangesAsync();
            }

            if (!await catalogContext.CatalogLocalityItems.AnyAsync())
            {
                await catalogContext.CatalogLocalityItems.AddRangeAsync(GetPreconfiguredCatalogoLocalityItem());
                await catalogContext.SaveChangesAsync();
            }

        }

        private static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            return new List<CatalogBrand>
            {
                new CatalogBrand("Azure"),
                new CatalogBrand(".NET"),
                new CatalogBrand("Visual Studio"),
                new CatalogBrand("SQL Server"),
                new CatalogBrand("Other"),
                new CatalogBrand("Logic")
            };
        }

        private static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            return new List<CatalogType>
            {
                new CatalogType("Mug"),
                new CatalogType("T-Shirt"),
                new CatalogType("Sheet"),
                new CatalogType("USB Memory Stick")
            };
        }

        private static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            return new List<CatalogItem>
            {
                //id=1
                new CatalogItem(2, 2, ".NET Bot Black Sweatshirt", ".NET Bot Black Sweatshirt", 19.5M, "http://catalogbaseurltobereplaced/images/products/1.png"),
                //id=2
                new CatalogItem(1, 6, ".NET LOGIC MUG", ".NET LOGIC MUG", 8.50M, "http://catalogbaseurltobereplaced/images/products/2.png"),
                //id=3
                new CatalogItem(2, 5, "Prism White T-Shirt", "Prism White T-Shirt", 12, "http://catalogbaseurltobereplaced/images/products/3.png"),
                //id=4
                new CatalogItem(2, 2, ".NET Foundation Sweatshirt", ".NET Foundation Sweatshirt", 12, "http://catalogbaseurltobereplaced/images/products/4.png"),
                //id=5
                new CatalogItem(3, 5, "Roslyn Red Sheet", "Roslyn Red Sheet", 8.5M, "http://catalogbaseurltobereplaced/images/products/5.png"),
                //id=6
                new CatalogItem(2, 2, ".NET Blue Sweatshirt", ".NET Blue Sweatshirt", 12, "http://catalogbaseurltobereplaced/images/products/6.png"),
                //id=7
                new CatalogItem(2, 5, "Roslyn Red T-Shirt", "Roslyn Red T-Shirt", 12, "http://catalogbaseurltobereplaced/images/products/7.png"),
                //id=8
                new CatalogItem(2, 5, "Kudu Purple Sweatshirt", "Kudu Purple Sweatshirt", 8.5M, "http://catalogbaseurltobereplaced/images/products/8.png"),
                //id=9
                new CatalogItem(1, 5, "Cup<T> White Mug", "Cup<T> White Mug", 12, "http://catalogbaseurltobereplaced/images/products/9.png"),
                //id=10
                new CatalogItem(3, 2, ".NET Foundation Sheet", ".NET Foundation Sheet", 12, "http://catalogbaseurltobereplaced/images/products/10.png"),
                //id=11
                new CatalogItem(3, 2, "Cup<T> Sheet", "Cup<T> Sheet", 8.5M, "http://catalogbaseurltobereplaced/images/products/11.png"),
                //id=12
                new CatalogItem(2, 5, "Prism White TShirt", "Prism White TShirt", 12, "http://catalogbaseurltobereplaced/images/products/12.png")
            };
        }


        private static IEnumerable<CatalogLocality> GetPreconfiguredCatalogoLocalidades()
        {
            return new List<CatalogLocality>
                {
                           new CatalogLocality("Quito"),
                           new CatalogLocality("Guayaquil")
                };

        }

        //UIO
        //1. ROSLYN RED SHEET id:5
        //2. .NET BOT BLACK SWEATSHIRT id:1
        //3. .NET BLUE SWEATSHIRT id:6

        //GUY
        //1. CUP WHITE MUG - 9
        //2. ROSLYN RED T-SHIRT - 7
        private static IEnumerable<CatalogLocalityItem> GetPreconfiguredCatalogoLocalityItem()
        {
            return new List<CatalogLocalityItem>
                {
                           new CatalogLocalityItem{
                            CatalogLocalityId = 1,
                            CatalogItemId = 5,
                           },
                           new CatalogLocalityItem{
                            CatalogLocalityId = 1,
                            CatalogItemId = 1,
                           },
                           new CatalogLocalityItem{
                            CatalogLocalityId = 1,
                            CatalogItemId = 6,
                           },
                           new CatalogLocalityItem{
                            CatalogLocalityId = 2,
                            CatalogItemId = 7,
                           },
                           new CatalogLocalityItem{
                            CatalogLocalityId = 2,
                            CatalogItemId = 9,
                           }

                };

        }


    }
}
