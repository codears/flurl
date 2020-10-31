using Flurl;
using Flurl.Http;
using System;
using System.Threading.Tasks;

namespace Consumidor
{
    public class ApiConsumer<TParam, TResposta> : IApiConsumer<TParam, TResposta>
    {
        string _urlBase = "https://deckofcardsapi.com/api/";

        public ApiConsumer()        {        }

        public async Task<TResposta> ConsumirApiAsync(string sufixo, TParam parametro)
        {
            try
            {
                var url = MontarUrl(parametro, sufixo);
                var resposta = await url.GetStringAsync();
                var baites = await url.GetBytesAsync();
                var str = await url.GetStreamAsync();


                return default(TResposta);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        private string MontarUrl(object queryParams, string sufixo = "deck/new/shuffle/")
        {
            return _urlBase
                .AppendPathSegment(sufixo)
                .SetQueryParams(queryParams);

        }
    }
}