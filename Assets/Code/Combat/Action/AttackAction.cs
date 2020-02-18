using UnityEngine;

namespace Code.Combat.Action
{
  public class AttackAction : IAction
  {
    public AttackAction()
    {
      Duration = 10;
      Name = "Attack";
    }

    public void Execute(Character self, Character target)
    {
      target.Health -= self.Damage;
      Debug.Log(self.Name + " attacks " + target.Name);
    }

    public string Name { get; }
    public int Duration { get; }
  }
}