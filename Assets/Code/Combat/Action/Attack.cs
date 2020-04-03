using Code.Combat.Calculations;
using Code.Common;
using UnityEngine;

namespace Code.Combat.Action
{
  public class Attack : IAction
  {
    public Attack()
    {
      CastTime = TimeConst.Seconds(3);
      Name = "Attack";
    }

    public void Execute(Character self, Character target)
    {
      target.Health -= DamageCalculator.Damage(self, target, self.Damage, DamageType.Physical);
      Debug.Log($"{self.Name} attacks {target.Name}");
    }

    public string Name { get; }
    public float CastTime { get; }
  }
}