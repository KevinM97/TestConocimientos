using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Entities;
public class CatalogLocalityItem : BaseEntity
{
    public int CatalogLocalityId { get; set; }
    public CatalogLocality CatalogLocality { get; set; }

    public int CatalogItemId { get; set; }
    public CatalogItem CatalogItem { get; set; }
}
