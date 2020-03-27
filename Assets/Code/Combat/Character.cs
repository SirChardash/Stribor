using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Code.Combat.Action;
using Code.Combat.Behavior;
using Code.Combat.Buff;

namespace Code.Combat
{
  public class Character
  {
    private const float TurnDuration = 100f;
    public ICharacterBehavior Behavior;
    public int Health;
    public int Damage;
    public int Speed;
    public string Name;
    public IList<IAction> AvailableActions = new List<IAction>();
    private float _turnProgress;
    public float TurnProgress => _turnProgress / TurnDuration;
    public PreparedAction ActiveAction;
    public List<IBuff> Buffs = new List<IBuff>();

    public bool Update(float timeIncrement)
    {
      _turnProgress = Math.Min(_turnProgress + timeIncrement * Speed, TurnDuration);
      Buffs.ForEach(buff => buff.Update(timeIncrement, this));
      return IsReady();
    }

    public bool IsReady()
    {
      return _turnProgress >= TurnDuration;
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
  }
}