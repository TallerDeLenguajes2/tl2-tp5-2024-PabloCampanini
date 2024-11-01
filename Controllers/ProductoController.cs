using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class ProductoController : ControllerBase
{
    // private Productos producto;
    private ProductoRepository productosRep;

    public ProductoController()
    {
        productosRep = new ProductoRepository();
    }

    [HttpPost("AgregarProducto")]
    public ActionResult AgregarProducto([FromBody] Productos productoNuevo)
    {
        productosRep.CreateProducto(productoNuevo);

        return Created();
    }

    [HttpGet("GetProductos")]
    public ActionResult<List<Productos>> GetProductos()
    {
        return Ok(productosRep.GetAllProductos());
    }

    [HttpPut("ModificarNombreProducto")]
    public ActionResult ModificarNombreProducto(int idBuscado, [FromBody] Productos producto)
    {
        productosRep.UpdateProducto(idBuscado, producto);
        return Ok();
    }
}