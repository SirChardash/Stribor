using System;
using System.Collections.Generic;
using Code.Combat.Action;
using Code.Common;
using UnityEngine;
using Random = System.Random;

namespace Code.Combat.Behavior
{
  public class ConstantAttack : ICharacterBehavior
  {
    public ConstantAttack()
    {
      AvailableActions = new List<IAction> {new Attack()};
    }

    public IAction ChooseAction(Character self, Character target)
    {
      return new Attack();
    }

    public Character ChooseTarget(List<Character> friendlies, List<Character> enemies)
    {
      if (enemies.Count == 0)
      {
        return null;
      }

      var target = enemies[RandomGenerator.RandomInt(enemies.Count)];
      Debug.Log($"{target.Name} is targeted");
      return target;
    }

    public IList<IAction> AvailableActions { get; }
  }
}