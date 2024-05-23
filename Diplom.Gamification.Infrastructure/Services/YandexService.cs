using Diplom.Gamification.Application.Interfaces;
using Diplom.Gamification.Application.ViewModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Diplom.Gamification.Infrastructure.Services
{
    public class YandexService : IYandexService
    {
        private readonly IConfiguration _configuration;

        private readonly string _apiKey;
        private readonly string _folderId;

        public YandexService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<GPTResponse> GetIntentAsync(string text)
        {
            var url = "https://llm.api.cloud.yandex.net/foundationModels/v1/completion";
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://llm.api.cloud.yandex.net/foundationModels/v1/completion"))
                {
                    var token = _configuration.GetSection("YandexServices:YandexIAM").Value;
                    var folderId = _configuration.GetSection("YandexServices:YandexFolderId").Value;
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {token}");

                    var content = JsonContent.Create(new GPTViewModel
                    {
                        ModelUri = $"gpt://{folderId}/yandexgpt-lite",
                        CompletionOptions = new CompletionOptions
                        {
                            Stream = false,
                            Temperature = 0,
                            MaxTokens = "2000"
                        },
                        Messages = new List<Message> { new Message
                        {
                            Role = "system",
                            Text = "Ты ассистент программист который отвечает на вопросы учеников. Отправляй текст как html markdown"
                        }, new Message
                        {
                            Role = "user",
                            Text = text
                        } 
                        }
                    });

                    var response = await httpClient.PostAsync(url, content);

                    return JsonConvert.DeserializeObject<GPTResponse>(await response.Content.ReadAsStringAsync());
                }
            }
        }
    }
}
