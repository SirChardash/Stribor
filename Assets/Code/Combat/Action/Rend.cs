using Code.Combat.Buff;
using Code.Common;

namespace Code.Combat.Action
{
    public class Rend : IAction
    {
        public Rend()
        {
            Name = "Rend";
            CastTime = TimeConst.Seconds(1);
        }

        public void Execute(Character self, Character target)
        {
            target.Buffs.Add(Buffs.Bleeding(self.Snapshot(), TimeConst.Seconds(1), TimeConst.Seconds(5), 1));
        }

        public string Name { get; }
        public float CastTime { get; }
    }
}