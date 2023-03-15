using System.Text.Json.Serialization;

namespace Lesson13HomeWork.Task3
{
    internal class SuperHero
    {
        [JsonPropertyName("squadName")]
        public string SquadName { get; set; }
        [JsonPropertyName("homeTown")]
        public string HomeTown { get; set; }
        [JsonPropertyName("formed")]
        public int Formed { get; set; }
        [JsonPropertyName("secretBase")]
        public string SecretBase { get; set; }
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        [JsonPropertyName("members")]
        public Member[] Members { get; set; }
    }
}
