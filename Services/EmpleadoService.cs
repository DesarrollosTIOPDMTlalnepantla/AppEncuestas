using AppEncuestas.Services.Base;

namespace AppEncuestas.Services
{
    public class EmpleadoService : BaseHttpService, IEmpleadoService
    {
        private readonly IClient client;
        public EmpleadoService(IClient client) : base(client)
        {
            this.client = client;
        }
        public async Task<Response<List<EmpleadoReadOnlyDTO>>> GetEmpleados()
        {
            Response<List<EmpleadoReadOnlyDTO>> response;

            try
            {
                var data = await client.EmpleadosAllAsync();
                response = new Response<List<EmpleadoReadOnlyDTO>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException exception)
            {

                response = ConvertApiExceptions<List<EmpleadoReadOnlyDTO>>(exception);
            }

            return response;

        }
        public async Task<Response<Empleado>> GetEmpleado(int empleadoId)
        {
            Response<Empleado> response;

            try
            {
                var data = await client.EmpleadosAsync(empleadoId);
                response = new Response<Empleado>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException exception)
            {

                response = ConvertApiExceptions<Empleado>(exception);
            }

            return response;

        }         
    }
}
