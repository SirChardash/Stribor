using System;
using System.Collections.Generic;
using Code.Combat.Action;
using Code.Combat.Behavior;

namespace Code.Combat
{
  public class PreparedAction
  {
    public Character Self;
    public Character Target;
    public IAction Action;
    private int _elapsed;

    public float Progress => (float) _elapsed / Action.Duration;

    public PreparedAction(Character self, Character target, IAction action)
    {
      Self = self;
      Target = target;
      Action = action;
    }

    public IAction Update()
    {
      return ++_elapsed == Action.Duration ? Action : null;
    }

    public int GetElapsed()
    {
      return _elapsed;
    }
  }
}