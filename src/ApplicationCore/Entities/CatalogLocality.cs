using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;

namespace Microsoft.eShopWeb.ApplicationCore.Entities;
public class CatalogLocality : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
    public List<CatalogLocalityItem> CatalogLocalityItems { get; set; }


        public CatalogLocality (string name ) 
            {
                Name = name;
            }
}
