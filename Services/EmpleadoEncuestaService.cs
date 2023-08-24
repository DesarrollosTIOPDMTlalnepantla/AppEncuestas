using AppEncuestas.Services.Base;

namespace AppEncuestas.Services
{
    public class EmpleadoEncuestaService : BaseHttpService, IEmpleadoEncuestaService
    {
        private readonly IClient client;
        public EmpleadoEncuestaService(IClient client) : base(client)
        {
            this.client = client;
        }
        public async Task<Response<int>> CreateEmpleadoEncuesta(EmpleadoEncuestaCrearDTO empleadoEncuesta)
        {
            Response<int> response = new();

            try
            {
                await client.EmpleadosEncuestaPOSTAsync(empleadoEncuesta);
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }
        public async Task<Response<List<EmpleadoEncuestaReadOnlyDTO>>> GetEmpleadosEncuesta()
        {
            Response<List<EmpleadoEncuestaReadOnlyDTO>> response;

            try
            {
                var data = await client.EmpleadosEncuestaAllAsync();
                response = new Response<List<EmpleadoEncuestaReadOnlyDTO>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException exception)
            {

                response = ConvertApiExceptions<List<EmpleadoEncuestaReadOnlyDTO>>(exception);
            }

            return response;

        }
        public async Task<Response<EmpleadoEncuesta>> GetEmpleadoEncuesta(int empleadoEncuestaId)
        {
            Response<EmpleadoEncuesta> response;

            try
            {
                var data = await client.EmpleadosEncuestaGETAsync(empleadoEncuestaId);
                response = new Response<EmpleadoEncuesta>
                {
                    Data = data,
                    Success = true
                };
            }
            catch (ApiException exception)
            {

                response = ConvertApiExceptions<EmpleadoEncuesta>(exception);
            }

            return response;

        }        
    }
}
