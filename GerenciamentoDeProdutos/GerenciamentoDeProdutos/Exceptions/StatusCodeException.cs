namespace GerenciamentoDeProdutos.Exceptions
{
    public class StatusCodeException : Exception
    {
        public int StatusCode { get; set; }

        public StatusCodeException(string message, int statusCode) : base(message) 
        {
            StatusCode = statusCode;
        }
    }
}
