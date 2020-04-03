using Code.Combat.Calculations;
using Code.Common;

namespace Code.Combat.Buff
{
    public class DamageOverTime : IBuff
    {
        public string Name { get; }
        private readonly ICharacter _source;
        private readonly float _period;
        private readonly float _duration;
        private readonly int _damagePerTick;
        private readonly DamageType _damageType;

        private float _elapsed;
        private int _timesHappened;
        
        public DamageOverTime(string name, ICharacter source, float period, float duration, int damagePerTick, DamageType damageType)
        {
            Name = name;
            _source = source;
            _period = period;
            _duration = duration;
            _damagePerTick = damagePerTick;
            _damageType = damageType;
        }

        public bool Update(float timeIncrement, Character target)
        {
            _elapsed += timeIncrement;

            if (_elapsed >= (_timesHappened + 1) * _period)
            {
                target.Health -= DamageCalculator.Damage(_source, target, _damagePerTick, _damageType);
                _timesHappened++;
            }

            return _elapsed > _duration;
        }
    }
}