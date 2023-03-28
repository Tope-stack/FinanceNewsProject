
using FinanceNews.Models;
using Newtonsoft.Json;

namespace FinanceNews.Services
{
    public class NewsService : INewsService
    {
        private readonly IConfiguration _configuration;
        public NewsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public News GetFinanceNews(int offset)
        {
            string apiKey = _configuration.GetValue<string>("API_KEY");
            string baseUrl = _configuration.GetValue<string>("API_URL");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                var parameters = string.Format("?apikey={0}&offset={1}&date={2}&sort={3}", apiKey, offset, "today", "desc");

                HttpResponseMessage response = client.GetAsync(parameters).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    return JsonConvert.DeserializeObject<News>(result);
                } else
                {
                    return new News()
                    {
                        Data = new List<FinanceData>(),
                        Pagination = new Pagination()
                    };
                }
            }
        }
    }
}
