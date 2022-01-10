using Microsoft.EntityFrameworkCore;

namespace DB.Models
{   
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { 
        }

        public DbSet<Monster> Monsters { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var monster1 = new Monster
            {
                Id = 1,
                Name = "Wretched",
                HitPoints = 10,
                AttackModifier = 4,
                AttackPerRound = 1,
                Damage = "1d10",//1d6 вводим дамаг перса
                DamageModifier = 1,
                ArmorClass = 15
            };

            var monster2 = new Monster
            {
                Id = 2,
                Name = "Flesh Golem",
                HitPoints = 93,
                AttackModifier = 44,
                AttackPerRound = 2,
                Damage = "11d8",
                DamageModifier = 4,
                ArmorClass = 9
            };

            var monster3 = new Monster
            {
                Id = 3,
                Name = "Cow",
                HitPoints = 15,
                AttackModifier = 4,
                AttackPerRound = 1,
                Damage = "2d10",
                DamageModifier = 4,
                ArmorClass = 10
            };

            modelBuilder.Entity<Monster>().HasData(monster1, monster2, monster3);
            base.OnModelCreating(modelBuilder);
        }
    }
}