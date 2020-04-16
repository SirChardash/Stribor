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
        Blueprint.ControlledSample1.ToCharacter(),
        Blueprint.ControlledSample2.ToCharacter(),
        Blueprint.ControlledSample3.ToCharacter()
      };
      var side2 = new List<Character>
      {
        Blueprint.AutonomousSample1.ToCharacter(),
        Blueprint.AutonomousSample2.ToCharacter(),
        Blueprint.AutonomousSample3.ToCharacter()
      };

      Debug.Log($"creating encounter with friendlies {side1.Count} enemies {side2.Count}");
      return new Encounter {RightTeam = side1, LeftTeam = side2};
    }
  }
}