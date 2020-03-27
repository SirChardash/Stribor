namespace Code.Combat.Buff
{
    public interface IBuff
    {
        string Name { get; }
        void Update(float timeIncrement, Character target);
    }
}