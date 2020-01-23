using System;
using Code.Combat.Behavior;

namespace Code.Combat
{
  public class Character
  {
    private const int TurnDuration = 100;
    public ICharacterBehavior Behavior;
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Speed { get; set; }
    public string Name { get; set; }
    private int _turnProgress;

    public bool Update()
    {
      _turnProgress = Math.Min(_turnProgress + Speed, TurnDuration);
      return IsReady();
    }

    public bool IsReady()
    {
      return _turnProgress == TurnDuration;
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