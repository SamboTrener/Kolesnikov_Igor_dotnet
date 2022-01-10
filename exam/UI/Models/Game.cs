using System.Collections.Generic;
using DB.Models;

namespace UI.Models
{
    public class Game
    {
        public Monster Monster { get; set; }
        public CharacterModel Character { get; set; }
        public Log Log { get; set; }
    }

    public class Log
    {
        public List<Round> Rounds { get; set; }

        public Log()
        {
            Rounds = new List<Round>();
        }
    }

    public class Round
    {
        public int Id { get; set; }
        public List<Attack> Attacks { get; set; }

        public Round()
        {
            Attacks = new List<Attack>();
        }
    }

    public class Attack
    {
        public string OwnerName { get; set; }
        public int AttackDrop { get; set; }
        public int AttackModifier { get; set; }
        public bool IsAttack { get; set; }
        public int DamageDrop { get; set; }
    }
}