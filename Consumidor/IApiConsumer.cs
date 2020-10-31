using System.Threading.Tasks;

namespace Consumidor
{
    public interface IApiConsumer<TParam, TResposta>
    {
        Task<TResposta> ConsumirApiAsync(string sufixo, TParam parametro);
    }
}

