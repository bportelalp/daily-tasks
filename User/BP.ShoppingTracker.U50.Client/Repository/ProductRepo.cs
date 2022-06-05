using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace BP.ShoppingTracker.U50.Client.Repository
{
    public class ProductRepo
    {
        private readonly HttpClient httpClient;

        public ProductRepo(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ResponseRepo<TResult>> GetAsync<TResult>(string path)
        {
            var response = await httpClient.GetAsync(path);
            TResult result = default(TResult);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<TResult>();
                return new ResponseRepo<TResult>(result, false, response);
            }
            else
            {
                return new ResponseRepo<TResult>(default, true, response);
            }
        }

        public async Task<ResponseRepo<TResult>> PostAsync<T, TResult>(T body, string path)
        {
            var content = new StringContent(JsonConvert.SerializeObject(body));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await httpClient.PostAsync(path, content);
            TResult result = default(TResult);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<TResult>();
                return new ResponseRepo<TResult>(result, false, response);
            }
            else
            {
                return new ResponseRepo<TResult>(default, true, response);
            }
        }
    }
}
