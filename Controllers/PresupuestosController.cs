using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class PresupuestosController : ControllerBase
{
    private PresupuestosRepository presupuestosRep;

    public PresupuestosController()
    {
        presupuestosRep = new PresupuestosRepository();
    }

    [HttpPost("CargarPresupuesto")]
    public ActionResult CargarPresupuesto([FromBody] Presupuestos presupuestoNuevo)
    {
        presupuestosRep.CreatePresupuesto(presupuestoNuevo);
        return Created();
    }

    [HttpPost("AgregarProductoAlPresupuesto/{idBuscado}/ProductoDetalle")]
    public ActionResult AgregarProducto(int idBuscado)
    {
        presupuestosRep.UpdatePresupuesto(idBuscado);
        return Ok();
    }

    
}