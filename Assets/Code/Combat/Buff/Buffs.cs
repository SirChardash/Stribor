using Code.Combat.Calculations;

namespace Code.Combat.Buff
{
    public static class Buffs
    {
        public static IBuff Bleeding(CharacterSnapshot source, float period, float duration, int damagePerTick)
        {
            return new DamageOverTime("Bleeding", source, period, duration, damagePerTick, DamageType.Physical);
        }
    }
}