using Code.Combat;

namespace Code
{
    public class CharacterSnapshot : ICharacter
    {
        public string Name { get; }
        public int Health { get; }
        public int Damage { get; }
        public int Speed { get; }

        public CharacterSnapshot(string name, int health, int damage, int speed)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Speed = speed;
        }
    }
}