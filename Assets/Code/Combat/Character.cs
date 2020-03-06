using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Code.Combat.Action;
using Code.Combat.Behavior;

namespace Code.Combat
{
  public class Character
  {
    private const int TurnDuration = 100;
    public ICharacterBehavior Behavior;
    public int Health;
    public int Damage;
    public int Speed;
    public string Name;
    public List<IAction> AvailableActions = new List<IAction>();
    private int _turnProgress;
    public PreparedAction ActiveAction;

    public bool Update()
    {
      _turnProgress = Math.Min(_turnProgress + Speed, TurnDuration);
      return IsReady();
    }

    public bool IsReady()
    {
      return _turnProgress == TurnDuration;
    }

    public bool IsCasting()
    {
      return ActiveAction != null;
    }

    public void ResetTurnProgress()
    {
      _turnProgress = 0;
    }

    public string DebugString()
    {
      return "[" + Name + "] HP: " + Health + ", DMG: " + Damage + ", SPD: " + Speed + "(" + _turnProgress + "/" +
             TurnDuration + ")";
    }

    public float TurnProgress => _turnProgress / (float) TurnDuration;
  }
}