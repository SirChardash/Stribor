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
        new Character {PhysicalDamage = 4, Health = 30, Speed = 15, Name = "mob11", Behavior = new ControlledBehavior(new List<IAction> {new Rend()})},
        new Character {PhysicalDamage = 6, Health = 15, Speed = 15, Name = "mob12", Behavior = new ControlledBehavior(new List<IAction> {new Attack(), new Attack()})},
        new Character {PhysicalDamage = 4, Health = 25, Speed = 21, Name = "mob13", Behavior = new ControlledBehavior(new List<IAction> {new Attack(), new Attack(), new Attack()})}
      };
      var side2 = new List<Character>
      {
        new Character {PhysicalDamage = 4, Health = 30, Speed = 15, Name = "mob21", Behavior = new ConstantAttack()},
        new Character {PhysicalDamage = 6, Health = 15, Speed = 15, Name = "mob22", Behavior = new ConstantAttack()},
        new Character {PhysicalDamage = 4, Health = 25, Speed = 21, Name = "mob23", Behavior = new ConstantAttack()}
      };

      Debug.Log($"creating encounter with friendlies {side1.Count} enemies {side2.Count}");
      return new Encounter {RightTeam = side1, LeftTeam = side2};
    }
  }
}