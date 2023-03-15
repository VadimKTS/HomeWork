using System.Text.Json.Serialization;

namespace Lesson13HomeWork.Task3
{
    internal class Member
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("age")]
        public int Age { get; set; }
        [JsonPropertyName("secretIdentity")]
        public string SecretIdentity { get; set; }
        [JsonPropertyName("powers")]
        public string[] Powers { get; set; }
    }
}
