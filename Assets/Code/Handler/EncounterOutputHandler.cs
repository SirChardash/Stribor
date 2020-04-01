using Code.Combat;
using Code.Combat.Behavior;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Handler
{
  public class EncounterOutputHandler : MonoBehaviour
  {
    public Text text;
    private Encounter _encounter;

    void Start()
    {
      _encounter = EncounterHolder.CurrentEncounter;
    }

    void Update()
    {
      var output = "";
      output += "Enemies:\n";
      _encounter.LeftTeam.ForEach(character => output += character.DebugString() + "\n");
      output += "Friendlies:\n";
      _encounter.RightTeam.ForEach(character => output += character.DebugString() + "\n");
      output += "Prepared actions:\n";
      _encounter.PreparedActions.ForEach(action =>
        output += $"{action.Self.Name}->{action.Target.Name} [{action.Elapsed}/{action.Action.CastTime}]\n");
      output += "Current state: " + InputState.Current + "\n";
      foreach (var character in _encounter.RightTeam)
      {
        output += $"Order for {character.Name}: {((ControlledBehavior) character.Behavior).Order?.Action?.Name} " +
                  $"{((ControlledBehavior) character.Behavior).Order?.Target?.Name}\n";
      }
      text.text = output;
    }
  }
}