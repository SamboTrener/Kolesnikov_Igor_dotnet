using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DB.Models
{
    public class Monster
    {
        public int Id { get; set; }

        [Required] [JsonPropertyName("name")] public string Name { get; set; }

        [Required]
        [JsonPropertyName("hitPoints")]
        [Range(1, 100)]
        public int HitPoints { get; set; }

        [Required]
        [JsonPropertyName("attackModifier")]
        [Range(1, 100)]
        public int AttackModifier { get; set; }

        [Required]
        [JsonPropertyName("attackPerRound")]
        [Range(1, 100)]
        public int AttackPerRound { get; set; }

        [Required]
        [JsonPropertyName("damage")]
        [Range(1, 100)]
        public string Damage { get; set; }

        [Required]
        [JsonPropertyName("damageModifier")]
        [Range(1, 100)]
        public int DamageModifier { get; set; }

        [Required]
        [JsonPropertyName("armorClass")]
        [Range(1, 100)]
        public int ArmorClass { get; set; }
    }
}