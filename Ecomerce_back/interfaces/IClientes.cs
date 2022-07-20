namespace Ecomerce_back.interfaces
{
    public interface IClientes
    {
        int Id { get; set; }
        string email { get; set; }
        string nombre { get; set; }
        string apellido { get; set; }
        string telefono { get; set; }
        string direccion { get; set; }
        string contraseña { get; set; }
    }
}
