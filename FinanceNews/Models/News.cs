using Newtonsoft.Json;


namespace FinanceNews.Models
{
    public class News
    {
        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty("data")]
        public List<FinanceData> Data { get; set; }
    }
}
