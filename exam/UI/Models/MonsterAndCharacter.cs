using System.Text.Json.Serialization;
using DB.Models;

namespace UI.Models
{
    public class MonsterAndCharacter
    {
        [JsonPropertyName("monster")]
        public Monster Monster { get; set; }
        
        [JsonPropertyName("character")]
        public CharacterModel Character { get; set; }
    }
}