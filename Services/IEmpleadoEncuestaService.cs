using AppEncuestas.Services.Base;

namespace AppEncuestas.Services
{
    public interface IEmpleadoEncuestaService
    {
        Task<Response<List<EmpleadoEncuestaReadOnlyDTO>>> GetEmpleadosEncuesta();
        Task<Response<int>> CreateEmpleadoEncuesta(EmpleadoEncuestaCrearDTO empleadoEncuesta);
        Task<Response<EmpleadoEncuesta>> GetEmpleadoEncuesta(int idEmpleadoEncuesta);

    }
}