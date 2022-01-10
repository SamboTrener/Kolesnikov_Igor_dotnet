using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UI.Models
{
    public class CharacterModel
    {
        [Required]
        [MaxLength(50)]
        [DisplayName("Имя")]
        [JsonPropertyName("name")]
        public string Name { get; init; }
        
        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Очки здоровья")]
        [JsonPropertyName("hitPoints")]
        public int HitPoints { get; set; }
                
        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Модификация атаки")]
        [JsonPropertyName("attackModifier")]
        public int AttackModifier { get; init; }
                
        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Атака за раунд")]
        [JsonPropertyName("attackPerRound")]
        public int AttackPerRound { get; init; }
                
        [Required]
        [DisplayName("Урон")]
        [JsonPropertyName("damage")]
        [RegularExpression(@"^(?'count'\d+)d(?'sides'\d+)$", ErrorMessage = "Урон вводится в формате *число*d*число*")]
        public string Damage { get; init; }
                
        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Модификация урона")]
        [JsonPropertyName("damageModifier")]
        public int DamageModifier { get; init; }

        [Required]
        [Range(0, int.MaxValue)]
        [DisplayName("Класс армора")]
        [JsonPropertyName("armorClass")]
        public int ArmorClass { get; init; }
    }
}