using System;
using Code.Combat;
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
        output += action.Self.Name + "->" + action.Target.Name + " [" + action.GetElapsed() + "/" +
                  action.Action.Duration + "]\n");
      output += "Current state: " + InputState.Current + "\n";
      output += "Source: " + InputState.Source + "\n";
      output += "Target: " + InputState.Target + "\n";
      output += "Action: " + InputState.SelectedAction + "\n";
      text.text = output;
    }
  }
}