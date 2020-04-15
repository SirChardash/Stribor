namespace Code.Combat
{
  public class CharacterSnapshot : ICharacter
  {
    public string Name { get; set; }
    public float MaxHealth { get; set; }
    public float Health { get; set; }
    public float Speed { get; set; }
    public float PhysicalDamage { get; set; }
    public float MagicalDamage { get; set; }
    public float PhysicalArmor { get; set; }
    public float MagicalArmor { get; set; }

    public CharacterSnapshot(string name, float maxHealth, float health, float speed, float physicalDamage,
      float magicalDamage, float physicalArmor, float magicalArmor)
    {
      Name = name;
      MaxHealth = maxHealth;
      Health = health;
      Speed = speed;
      PhysicalDamage = physicalDamage;
      MagicalDamage = magicalDamage;
      PhysicalArmor = physicalArmor;
      MagicalArmor = magicalArmor;
    }
  }
}