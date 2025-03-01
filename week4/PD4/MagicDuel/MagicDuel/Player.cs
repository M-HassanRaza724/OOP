namespace MagicDuel
{
    public class Player
    {
        public string Name;
        public float Hp;
        public float MaxHp;
        public float Energy;
        public float MaxEnergy;
        public float Armor;
        public Stats SkillStatistics;

        public Player(string name, float health, float energy, float armor)
        {
            Name = name;
            MaxHp = health;
            Hp = health;
            MaxEnergy = energy;
            Energy = energy;
            Armor = armor;
        }

        public void UpdateHealth(float amount)
        {
            Hp += amount;
            if (Hp < 0) Hp = 0;
            if (Hp > MaxHp) Hp = MaxHp;
        }

        public void UpdateEnergy(float amount)
        {
            Energy += amount;
            if (Energy < 0) Energy = 0;
            if (Energy > MaxEnergy) Energy = MaxEnergy;
        }

        public void UpdateArmor(float amount)
        {
            Armor += amount;
            if (Armor < 0) Armor = 0;
            if (Armor > 100) Armor = 100;
        }

        public void LearnSkill(Stats skillStats)
        {
            SkillStatistics = skillStats;
        }

        public string Attack(Player target)
        {
            if (Energy < SkillStatistics.Cost)
            {
                return $"{Name} attempted to use {SkillStatistics.Name}, but didn't have enough energy!";
            }

            UpdateEnergy(-SkillStatistics.Cost);

            float effectiveArmor = target.Armor - SkillStatistics.Penetration;
            if (effectiveArmor < 0) 
               effectiveArmor = 0;
            if (effectiveArmor > 100) 
               effectiveArmor = 100;

            float damage = SkillStatistics.Damage * ((100 - effectiveArmor) / 100);

            target.UpdateHealth(-damage);

            if (SkillStatistics.Heal > 0)
            {
                UpdateHealth(SkillStatistics.Heal);
            }

            string attackString = $"{Name} used {SkillStatistics.Name}, {SkillStatistics.Description}, against {target.Name}, doing {damage } damage!";

            if (SkillStatistics.Heal > 0)
            {
                attackString += $" {Name} healed for {SkillStatistics.Heal} health!";
            }

            if (target.Hp <= 0)
            {
                attackString += $" {target.Name} died.";
            }
            else
            {
                float targetHpPerc = (target.Hp / target.MaxHp) * 100;
                attackString += $" {target.Name} is at {targetHpPerc}% health.";
            }

            return attackString;
        }
    }
}
