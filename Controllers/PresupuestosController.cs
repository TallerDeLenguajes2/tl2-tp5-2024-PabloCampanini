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
    public ActionResult AgregarProducto(int idBuscado,int idprod, int cant)
    {
        presupuestosRep.UpdatePresupuesto(idBuscado, idprod, cant);
        return Ok();
    }

    [HttpGet("GetPresupuestos")]
    public ActionResult<List<Presupuestos>> GetPresupestos()
    {
        return Ok(presupuestosRep.GetAllPresupuestos());    
    }

    [HttpGet("DetallePresupuesto/{idBuscado}")]
    public ActionResult<Presupuestos> DetallePresupuesto(int idBuscado)
    {
        return Ok(presupuestosRep.GetDetalleDePresupuesto(idBuscado));
    }

    [HttpDelete("BorrarPresupuesto/{idBuscado}")]
    public ActionResult BorrarPresupuesto(int idBuscado) 
    {
        presupuestosRep.DeletePresupuesto(idBuscado);
        return Ok();
    }
}