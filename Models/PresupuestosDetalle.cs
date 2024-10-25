public class PresupuestosDetalle
{
    private Productos producto;
    private int cantidad;
    public PresupuestosDetalle()
    {
    }

    public Productos Producto { get => producto; }
    public int Cantidad { get => cantidad; set => cantidad = value; }

}