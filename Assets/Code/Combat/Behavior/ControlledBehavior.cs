using System.Collections.Generic;
using Code.Combat.Action;

namespace Code.Combat.Behavior
{
  public class ControlledBehavior : ICharacterBehavior
  {
    public readonly Order Order = new Order();

    public IAction ChooseAction(Character self, Character target)
    {
      return Order.Action;
    }

    public Character ChooseTarget(List<Character> friendlies, List<Character> enemies)
    {
      return Order.Target;
    }
  }
}