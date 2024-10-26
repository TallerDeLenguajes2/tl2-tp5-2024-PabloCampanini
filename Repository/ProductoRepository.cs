public class ProductoRepository
{
    private const string connectionString = @"Data Source=db\Tienda.db;Cache=Shared";
    
    public void CreateProducto(Productos producto)
    {
    }
    public void UpdateProducto(int idBuscado, Productos producto)
    {
    }

    public List<Productos> GetAllProductos()
    {
        List<Productos> hola = new List<Productos>();
        return hola;
    }

    public Productos GetDetalleDeProducto(int id)
    {
        Productos hola = null;
        return hola;
    }

    public void DeleteProducto(int id)
    {

    }
}