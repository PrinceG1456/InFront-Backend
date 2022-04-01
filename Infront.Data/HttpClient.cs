using Infront.Domain.Models;
using Infront.Domain.Translator.Comment;
using Infront.Domain.Translator.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infront.Data
{
    public class HttpClient :IHttpClient
    {
        private readonly IHttpClientFactory _clientFactory;

        public HttpClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/users");
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<UserModel>>(responseStream);

                return result.ConvertAll(x=>x.ViewModelTranslator());
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
