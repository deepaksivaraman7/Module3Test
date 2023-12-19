using Newtonsoft.Json;

namespace JsonPlaceHolder.HelperClasses
{
    internal class PostData //after deserializing json response, the values get stored in this class
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("body")]
        public string? Body { get; set; }
    }
}
