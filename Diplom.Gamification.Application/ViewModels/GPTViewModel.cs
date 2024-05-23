using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Diplom.Gamification.Application.ViewModels
{
    public class CompletionOptions
    {
        [JsonProperty("stream")]
        public bool Stream { get; set; }

        [JsonProperty("temperature")]
        public int Temperature { get; set; }

        [JsonProperty("maxTokens")]
        public string MaxTokens { get; set; }
    }

    public class Message
    {
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class GPTViewModel
    {
        [JsonProperty("modelUri")]
        public string ModelUri { get; set; }

        [JsonProperty("completionOptions")]
        public CompletionOptions CompletionOptions { get; set; }

        [JsonProperty("messages")]
        public List<Message> Messages { get; set; }
    }

    public class GPTRequest
    {
        public string? Request { get; set; }
    }

    public class Alternative
    {
        [JsonProperty("message")]
        public Message Message { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class Result
    {
        [JsonProperty("alternatives")]
        public List<Alternative> Alternatives { get; set; }

        [JsonProperty("usage")]
        public Usage Usage { get; set; }

        [JsonProperty("modelVersion")]
        public string ModelVersion { get; set; }
    }

    public class GPTResponse
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }

    public class Usage
    {
        [JsonProperty("inputTextTokens")]
        public string InputTextTokens { get; set; }

        [JsonProperty("completionTokens")]
        public string CompletionTokens { get; set; }

        [JsonProperty("totalTokens")]
        public string TotalTokens { get; set; }
    }
}
