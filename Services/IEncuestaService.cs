using AppEncuestas.Services.Base;

namespace AppEncuestas.Services
{
    public interface IEncuestaService
    {
        Task<Response<List<EncuestaReadOnlyDTO>>> GetEncuestas();
        Task<Response<int>> CreateEncuesta(EncuestaCrearDTO encuesta);

    }
}