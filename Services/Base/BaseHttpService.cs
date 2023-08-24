namespace AppEncuestas.Services.Base
{
    public class BaseHttpService
    {
        private readonly IClient client;
        public BaseHttpService(IClient client)
        {
            this.client=client;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException apiException)
        {
            if(apiException.StatusCode==400)
            {
                return new Response<Guid>() { Message="Validation errors have occured.", ValidationErrors=apiException.Response, Success=false};
            }
            if(apiException.StatusCode==404)
            {
                return new Response<Guid>() { Message="Elemento solicitado NO ENCONTRADO.", ValidationErrors=apiException.Response, Success=false};
            }           

            if(apiException.StatusCode>=200 && apiException.StatusCode<=299)
            {
                return new Response<Guid>() { Message="Operation Reported Success.", Success=true};
            }      

            return new Response<Guid>{ Message="Something went wrong, please try again.", Success=false};
        }
    }
}