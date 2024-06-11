using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.eShopWeb.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;

namespace Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints;

[ApiController]
[Route("api/[Controller]")]
public class ListProdLocalidad : ControllerBase
{
    private readonly CatalogContext _catalogContext;

    public ListProdLocalidad(CatalogContext catalogContext)
    {
        _catalogContext = catalogContext;
    }
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<CatalogoProducto>>> GetByLocalidad(int id)
    {
        if (id == 0)
        {
            return BadRequest("No puede ingresar 0");
        }

        var localidad = await _catalogContext.CatalogLocalities.FindAsync(id);
        if (localidad == null)
        {
            return NotFound("Localidad no encontrada.");
        }

        var catalogItems = await _catalogContext.CatalogLocalityItems
          .Where(x => x.CatalogLocality.Id == id)
          .Select(c => new CatalogoProducto
          {
              Id = c.CatalogItem.Id,
              Name = c.CatalogItem.Name,
              IdLocalidad = c.CatalogLocality.Id,

          })
          .ToListAsync();

        return Ok(catalogItems);
    }


    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CatalogoProducto>>> GetItems()
    {
        var catalogItems = await _catalogContext.CatalogItems.ToListAsync();
        return Ok(catalogItems);
    }
}
