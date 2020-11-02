using Flurl;
using Flurl.Http;
using System;
using System.Threading.Tasks;

namespace RestConsumer
{
    public class ApiConsumer<TResposta>
    {
        string _urlBase = "https://deckofcardsapi.com/api/";

        public ApiConsumer() { }

        public async Task<TResposta> GetAsync(string sufixo, object parametro, string path = "", string fragment = "")
        {
            try
            {
                var url = MontarUrl(parametro, sufixo, path, fragment);
                var retorno = await url.GetStringAsync();
                var resposta = await url
                                    .GetJsonAsync<TResposta>();               

                return resposta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TResposta> PostAsync(string sufixo, object parametro)
        {
            try
            {
                var url = MontarUrl(parametro, sufixo);
                var tResposta =  await url.PostJsonAsync(parametro).ReceiveJson<TResposta>();
                
                return tResposta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string MontarUrl(object queryParams, string sufixo = "deck/new/shuffle/",  string path = "", string fragment = "")
        {
            return _urlBase
                .AppendPathSegment(sufixo)
                .AppendPathSegments(path, fragment)
                .SetQueryParams(queryParams);                             
        }
    }
}