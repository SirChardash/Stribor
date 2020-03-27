namespace Code.Combat.Buff
{
    public static class Buffs
    {
        public static IBuff Bleeding(float period, float duration, int damagePerTick)
        {
            return new DamageOverTime("Bleeding", period, duration, damagePerTick);
        }
    }
}