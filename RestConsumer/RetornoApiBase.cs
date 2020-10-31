namespace RestConsumer
{
    public class RetornoApiBase<T> 
    {
        public int StatusCode { get; set; }
        public T Resposta { get; set; }
        public string MensagemErro { get; set; }
    }
}