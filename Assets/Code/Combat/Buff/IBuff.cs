namespace Code.Combat.Buff
{
    public interface IBuff
    {
        string Name { get; }
        /// <summary>
        /// Updates buff. Should not be called after Update returns true.
        /// </summary>
        /// <param name="timeIncrement">time passed since last call</param>
        /// <param name="target">affected character</param>
        /// <returns>true when buff expires</returns>
        bool Update(float timeIncrement, Character target);
    }
}