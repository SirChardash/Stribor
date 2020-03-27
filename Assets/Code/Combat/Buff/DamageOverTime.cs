using Code.Common;

namespace Code.Combat.Buff
{
    public class DamageOverTime : IBuff
    {
        public string Name { get; }
        private readonly float _period;
        private readonly float _duration;
        private readonly int _damagePerTick;

        public DamageOverTime(string name, float period, float duration, int damagePerTick)
        {
            Name = name;
            _period = period;
            _duration = duration;
            _damagePerTick = damagePerTick;
        }

        private float _elapsed;
        private int _timesHappened;

        public void Update(float timeIncrement, Character target)
        {
            _elapsed += timeIncrement;

            if (_elapsed >= (_timesHappened + 1) * _period)
            {
                target.Health -= _damagePerTick;
                _timesHappened++;
            }

            if (_elapsed > _duration) target.Buffs.Remove(this);
        }
    }
}