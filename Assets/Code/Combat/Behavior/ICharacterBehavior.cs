using System.Collections.Generic;
using Code.Combat.Action;

namespace Code.Combat.Behavior
{
  public interface ICharacterBehavior
  {
    IAction ChooseAction(Character self, Character target);

    Character ChooseTarget(List<Character> friendlies, List<Character> enemies);
    
  }
}