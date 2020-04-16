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
      var friendlies = new List<Character>
      {
        Blueprint.LabSample1.ToCharacter(1, null, new List<IAction> {new Rend()}),
        Blueprint.LabSample2.ToCharacter(1, null, new List<IAction> {new Attack(), new Attack()}),
        Blueprint.LabSample3.ToCharacter(1, null, new List<IAction> {new Attack(), new Attack(), new Attack()})
      };
      var enemies = new List<Character>
      {
        Blueprint.LabSample1.ToCharacter(),
        Blueprint.LabSample2.ToCharacter(),
        Blueprint.LabSample3.ToCharacter()
      };

      Debug.Log($"creating encounter with friendlies {friendlies.Count} enemies {enemies.Count}");
      return new Encounter {RightTeam = friendlies, LeftTeam = enemies};
    }
  }
}