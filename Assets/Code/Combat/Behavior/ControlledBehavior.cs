using System.Collections.Generic;
using Code.Combat.Action;

namespace Code.Combat.Behavior
{
  public class ControlledBehavior : ICharacterBehavior
  {

    public IAction ChooseAction(Character self, Character target)
    {
      return self.Equals(InputState.Source) ? InputState.SelectedAction : null;
    }

    public Character ChooseTarget(List<Character> friendlies, List<Character> enemies)
    {
      return InputState.Target;
    }
  }
}