using AppEncuestas.Services.Base;

namespace AppEncuestas.Services
{
    public class EncuestaService : BaseHttpService, IEncuestaService
    {
        private readonly IClient client;
        public EncuestaService(IClient client) : base(client)
        {
            this.client = client;
        }
        public async Task<Response<int>> CreateEncuesta(EncuestaCrearDTO encuesta)
        {
            Response<int> response = new Response<int>() { Success = true};

            try
            {
                await client.EncuestasPOSTAsync(encuesta);
            }
            catch (ApiException exception)
            {
                response = ConvertApiExceptions<int>(exception);
            }

            return response;
        }
        public async Task<Response<List<EncuestaReadOnlyDTO>>> GetEncuestas()
        {
            Response<List<EncuestaReadOnlyDTO>> response;

            try
            {
                var data = await client.EncuestasAllAsync();
                response = new Response<List<EncuestaReadOnlyDTO>>
                {
                    Data = data.ToList(),
                    Success = true
                };
            }
            catch (ApiException exception)
            {

                response = ConvertApiExceptions<List<EncuestaReadOnlyDTO>>(exception);
            }

            return response;

        }
    }
}