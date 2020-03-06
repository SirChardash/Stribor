using Code.Common;
using UnityEngine;

namespace Code.Combat.Action
{
  public class AttackAction : IAction
  {
    public AttackAction()
    {
      CastTime = TimeConst.Seconds(3);
      Name = "Attack";
    }

    public void Execute(Character self, Character target)
    {
      target.Health -= self.Damage;
      Debug.Log(self.Name + " attacks " + target.Name);
    }

    public string Name { get; }
    public float CastTime { get; }
  }
}