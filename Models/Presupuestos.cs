public class Presupuestos
{
    private int idPresupuesto;
    private string nombreDestinatario;
    private DateTime fechaCreacion;
    List<PresupuestosDetalle> detalle;
    public Presupuestos()
    {
        detalle = new List<PresupuestosDetalle>();
    }

    public int IdPresupuesto { get => idPresupuesto; set => idPresupuesto = value; }
    public string NombreDestinatario { get => nombreDestinatario; set => nombreDestinatario = value; }
    public List<PresupuestosDetalle> Detalle { get => detalle; }
    public DateTime FechaCreacion { get => fechaCreacion; set => fechaCreacion = value; }

    public void MontoPresupuesto()
    {

    }

    public void MontoPresupuestoConIva()
    {

    }

    public void CantidadProductos()
    {
        
    }
}