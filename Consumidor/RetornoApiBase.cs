namespace Consumidor
{
    public class RetornoApiBase<T> : IRetornoApiBase<T>
    {
        public int StatusCode { get; set; }
        public T Resposta { get; set; }
        public string MensagemErro { get; set; }
    }
}