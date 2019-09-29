
namespace ServicioLotoUCAB.Servicio.Logica.Comandos
{
    public interface IComando<TSalida>
    {
        TSalida Ejecutar();
    }
}
