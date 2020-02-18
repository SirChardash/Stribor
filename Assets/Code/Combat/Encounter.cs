using System;
using System.Collections.Generic;
using Code.Combat.Action;
using Code.Combat.Behavior;
using UnityEngine;

namespace Code.Combat
{
  public class Encounter
  {
    public List<Character> LeftTeam;
    public List<Character> RightTeam;
    public readonly List<PreparedAction> PreparedActions = new List<PreparedAction>(10);
    private readonly List<Character> _preparedCharacters = new List<Character>(10);
    private int _actionCycle;

    public List<PreparedAction> Update()
    {
      // stop if someone won
      if (LeftTeam.Count == 0 || RightTeam.Count == 0)
      {
        throw new EncounterEndException {LeftSideCount = LeftTeam.Count, RightSideCount = RightTeam.Count};
      }

      // progress prepared actions and execute them when ready
      var readyActions = new List<PreparedAction>();
      PreparedActions.RemoveAll(preparedAction =>
      {
        var action = preparedAction.Update();
        if (action == null) return false;
        readyActions.Add(preparedAction);
        _preparedCharacters.Remove(preparedAction.Self);
        preparedAction.Self.ResetTurnProgress();
        return true;
      });

      // progress all characters and queue their actions when they're ready
      UpdateCharacterSide(LeftTeam, RightTeam);
      UpdateCharacterSide(RightTeam, LeftTeam);

      // remove corpses
      RemoveCorpses(LeftTeam);
      RemoveCorpses(RightTeam);

      return readyActions;
    }

    private void UpdateCharacterSide(List<Character> friendlies, List<Character> enemies)
    {
      friendlies.ForEach(character =>
      {
        var ready = character.Update();
        if (!ready) return;
        // means they're preparing an action already
        if (_preparedCharacters.Contains(character)) return;
        var target = character.Behavior.ChooseTarget(friendlies, enemies);
        var action = character.Behavior.ChooseAction(character, target);
        // means character is not ready to act
        if (target == null || action == null) return;
        PreparedActions.Add(new PreparedAction(
          character,
          target,
          action
        ));

        // clean input state if enlisted action was chosen by user
        if (character.Behavior is ControlledBehavior) InputState.Clear();
        _preparedCharacters.Add(character);
      });
    }

    private void RemoveCorpses(List<Character> characters)
    {
      characters.RemoveAll(character =>
      {
        if (character.Health > 0) return false;
        PreparedActions.RemoveAll(action => action.Self.Equals(character));
        _preparedCharacters.Remove(character);

        Debug.Log(character.Name + " died");

        return true;
      });
    }
  }
}