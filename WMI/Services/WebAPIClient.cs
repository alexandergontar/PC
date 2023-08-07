using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WMI.Services
{
    public class WebAPIClient : IClient
    {
        public async Task<string> sendPost(string jsonString, string url)
        {
            StringContent data = new StringContent(jsonString, Encoding.UTF8, "application/json");            
            using HttpClient client = new HttpClient();
            var response = await client.PostAsync(url, data);
            string result = await response.Content.ReadAsStringAsync();            
            return result;
        }
    }
}
