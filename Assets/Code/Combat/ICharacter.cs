namespace Code.Combat
{
    public interface ICharacter
    {
        string Name { get; }
        int Health { get; }
        int Damage { get; }
        int Speed { get; }
    }
}