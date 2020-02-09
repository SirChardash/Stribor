using System.Collections.Generic;
using Code.Combat.Action;
using Code.Combat.Behavior;
using UnityEngine;

namespace Code.Combat
{
  public class EncounterFactory
  {
    public Encounter CreateSample()
    {
      var side1 = new List<Character>
      {
        new Character {Damage = 4, Health = 30, Speed = 5, Name = "mob11", Behavior = new ConstantAttack(), AvailableActions = {new AttackAction()}},
        new Character {Damage = 6, Health = 15, Speed = 5, Name = "mob12", Behavior = new ConstantAttack(), AvailableActions = {new AttackAction(), new AttackAction()}},
        new Character {Damage = 4, Health = 25, Speed = 7, Name = "mob13", Behavior = new ConstantAttack(), AvailableActions = {new AttackAction(), new AttackAction(), new AttackAction()}}
      };
      var side2 = new List<Character>
      {
        new Character {Damage = 4, Health = 30, Speed = 5, Name = "mob21", Behavior = new ConstantAttack()},
        new Character {Damage = 6, Health = 15, Speed = 5, Name = "mob22", Behavior = new ConstantAttack()},
        new Character {Damage = 4, Health = 25, Speed = 7, Name = "mob23", Behavior = new ConstantAttack()}
      };

      Debug.Log("creating encounter with friendlies " + side1.Count + " enemies " + side2.Count);
      return new Encounter() {RightTeam = side1, LeftTeam = side2};
    }
  }
}