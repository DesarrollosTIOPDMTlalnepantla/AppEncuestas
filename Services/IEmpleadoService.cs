using AppEncuestas.Services.Base;

namespace AppEncuestas.Services
{
    public interface IEmpleadoService
    {
        Task<Response<List<EmpleadoReadOnlyDTO>>> GetEmpleados();
        Task<Response<Empleado>> GetEmpleado(int empleado);
    }
}