namespace Code.Combat
{
  public interface ICharacter
  {
    string Name { get; set; }
    float MaxHealth { get; set; }
    float Health { get; set; }
    float Speed { get; set; }
    float PhysicalDamage { get; set; }
    float MagicalDamage { get; set; }
    float PhysicalArmor { get; set; }
    float MagicalArmor { get; set; }
  }
}