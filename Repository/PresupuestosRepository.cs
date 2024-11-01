using Microsoft.Data.Sqlite;

public class PresupuestosRepository
{
    private const string connectionString = @"Data Source=db\Tienda.db;Cache=Shared";

    public void CreatePresupuesto(Presupuestos presupuestoNuevo)
    {
        string queryString = "INSERT INTO Presupuestos (NombreDestinatario, FechaCreacion)" +
                             "VALUES ('@NombreDestinatario', '@FechaCreacion')";

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            SqliteCommand command = new SqliteCommand(queryString, connection);

            command.Parameters.Add(new SqliteParameter("@NombreDestinatario", presupuestoNuevo.NombreDestinatario));
            command.Parameters.Add(new SqliteParameter("@FechaCreacion", presupuestoNuevo.FechaCreacion));

            command.ExecuteNonQuery();

            connection.Close();
        }
    }

    public List<Presupuestos> GetAllPresupuestos()
    {
        string queryString = "SELECT * FROM Presupuestos AS p" + 
                             "INNER JOIN PresupuestosDetalle AS pre ON p.idPresupuesto = pre.idPresupuesto" + 
                             "INNER JOIN Productos AS pro ON pre.idProducto = pro.idProducto";

        List<Presupuestos> ListaPresupuestos = new List<Presupuestos>();

        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            SqliteCommand command = new SqliteCommand(queryString, connection);

            connection.Open();

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Productos prod = new Productos();

                    prod.IdProducto = Convert.ToInt32(reader["idProducto"]);
                    prod.Descripcion = Convert.ToString(reader["Descripcion"]);
                    prod.Precio = Convert.ToInt32(reader["Precio"]);

                    PresupuestosDetalle prodDet = new PresupuestosDetalle();

                    int cantidad = Convert.ToInt32(reader["Cantidad"]);
                    prodDet.CargarProducto(cantidad, prod);

                    Presupuestos pres = new Presupuestos();

                    pres.IdPresupuesto = Convert.ToInt32(reader["idPresupuesto"]);
                    pres.NombreDestinatario = Convert.ToString(reader["NombreDestinatario"]);
                    pres.FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]);
                    pres.AgregarDetalle(prodDet);

                    ListaPresupuestos.Add(pres);
                }
            }

            connection.Close();
        }

        return ListaPresupuestos;
    }

    public void GetDetalleDePresupuesto(int idBuscado)
    {
        string queryString = "";


    }

    public void UpdatePresupuesto(int idBuscado)
    {

    }

    public void DeletePresupuesto(int idBuscado)
    {

    }
}