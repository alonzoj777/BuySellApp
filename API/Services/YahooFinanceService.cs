using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace API.Services;

public class YahooFinanceService(HttpClient httpClient)
{
     private readonly HttpClient _httpClient = httpClient;

    public async Task<JObject> GetStockDataAsync(string ticker)
        {
            var url = $"https://query1.finance.yahoo.com/v7/finance/quote?symbols={ticker}";
          
            int maxRetries = 5;
            int delay = 1000; // Initial delay in milliseconds

            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    var response = await _httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    var responseData = await response.Content.ReadAsStringAsync();
                    return JObject.Parse(responseData);
                }
                catch (HttpRequestException ex) when (ex.StatusCode == (System.Net.HttpStatusCode)429)
                {
                    // Wait for the delay period before retrying
                    await Task.Delay(delay);
                    // Increase the delay for the next retry
                    delay *= 2;
                }
            }

            throw new HttpRequestException("Exceeded maximum retries for Yahoo Finance API.");
        }
}
