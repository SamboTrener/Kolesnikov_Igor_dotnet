using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DB.Models;
using UI.Models;

namespace BusinessLogic.Controllers
{
    [Route("[controller]")]
    public class FightController : Controller
    {
        [HttpPost]
        [Route("StartFight")]
        public Game StartFight([FromBody] MonsterAndCharacter monsterAndCharacter)
        {
            var monster = monsterAndCharacter.Monster;
            var character = monsterAndCharacter.Character;
            var charactersDamage = ParseDamage(character.Damage, character);
            var monstersDamage = ParseDamage(monster.Damage, monster);
            var log = new Log();
            var staticId = 0;
            while (monster.HitPoints > 0 && character.HitPoints > 0)
            {
                var round = new Round() {Id = ++staticId};
                for (int i = 0; i < character.AttackPerRound; i++)
                {
                    var attack = new Attack
                    {
                        OwnerName = character.Name,
                        AttackDrop = new Random().Next(1, 20),
                        AttackModifier = character.AttackModifier,
                    };
                    if (attack.AttackDrop == 1)
                    {
                        round.Attacks.Add(attack);
                        continue;
                    }

                    if (attack.AttackDrop + character.AttackModifier + 1 > monster.ArmorClass ||
                        attack.AttackDrop == 20)
                    {
                        attack.IsAttack = true;
                        for (int j = 0; j < charactersDamage.DropsCount; j++)
                        {
                            attack.DamageDrop = new Random().Next(1, charactersDamage.DiceMaxValue);
                            var damage = attack.DamageDrop + character.DamageModifier;
                            if (attack.AttackDrop == 20)
                                damage *= 2;
                            monster.HitPoints -= damage;
                            if (monster.HitPoints < 0)
                            {
                                round.Attacks.Add(attack);
                                log.Rounds.Add(round);
                                return new Game()
                                {
                                    Log = log,
                                    Character = character,
                                    Monster = monster
                                };
                            }
                        }
                    }

                    round.Attacks.Add(attack);
                }

                for (int i = 0; i < monster.AttackPerRound; i++)
                {
                    var attack = new Attack
                    {
                        OwnerName = monster.Name,
                        AttackDrop = new Random().Next(1, 20),
                        AttackModifier = monster.AttackModifier,
                    };
                    if (attack.AttackDrop == 1)
                    {
                        round.Attacks.Add(attack);
                        continue;
                    }

                    if (attack.AttackDrop + attack.AttackModifier + 1 > character.ArmorClass || attack.AttackDrop == 20)
                    {
                        attack.IsAttack = true;
                        for (int j = 0; j < monstersDamage.DropsCount; j++)
                        {
                            attack.DamageDrop = new Random().Next(1, monstersDamage.DiceMaxValue);
                            var damage = attack.DamageDrop + monster.DamageModifier;
                            if (attack.AttackDrop == 20)
                                damage *= 2;
                            character.HitPoints -= damage;
                            if (character.HitPoints < 0)
                            {
                                round.Attacks.Add(attack);
                                log.Rounds.Add(round);
                                return new Game()
                                {
                                    Log = log,
                                    Character = character,
                                    Monster = monster
                                };
                            }
                        }
                    }

                    round.Attacks.Add(attack);
                }

                log.Rounds.Add(round);
            }

            return new Game()
            {
                Log = log,
                Character = character,
                Monster = monster
            };
        }

        private Damage ParseDamage(string stringDamage, CharacterModel character)
        {
            var counter = 0;
            char i = character.Damage[counter];
            var strDropsCount = "";
            while (i != 'd')
            {
                strDropsCount += i;
                counter++;
                i = character.Damage[counter];
            }

            var dropsCount = int.Parse(strDropsCount);
            var diceMaxValue = int.Parse(character.Damage.Substring(counter + 1));
            return new Damage()
            {
                DropsCount = dropsCount,
                DiceMaxValue = diceMaxValue
            };
        }

        private Damage ParseDamage(string stringDamage, Monster monster)
        {
            var counter = 0;
            char i = monster.Damage[counter];
            var strDropsCount = "";
            while (i != 'd')
            {
                strDropsCount += i;
                counter++;
                i = monster.Damage[counter];
            }

            var dropsCount = int.Parse(strDropsCount);
            var diceMaxValue = int.Parse(monster.Damage.Substring(counter + 1));
            return new Damage()
            {
                DropsCount = dropsCount,
                DiceMaxValue = diceMaxValue
            };
        }

        public class Damage
        {
            public int DropsCount { get; set; }
            public int DiceMaxValue { get; set; }
        }
    }
}