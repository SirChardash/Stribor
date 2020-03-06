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
    private float _elapsed;
    [Obsolete] public float Elapsed => _elapsed;
    public float Progress => _elapsed / Action.CastTime;

    public PreparedAction(Character self, Character target, IAction action)
    {
      Self = self;
      Target = target;
      Action = action;
    }

    public IAction Update(float timeIncrement)
    {
      _elapsed += timeIncrement;
      return _elapsed >= Action.CastTime ? Action : null;
    }
  }
}