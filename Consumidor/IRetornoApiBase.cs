namespace Consumidor
{
    public interface IRetornoApiBase<T>
    {
        int StatusCode { get; set; }
        T Resposta { get; set; }
        string MensagemErro { get; set; }
    }
}