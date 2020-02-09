using Code.Combat.Action;
using JetBrains.Annotations;

namespace Code.Combat.Behavior
{
  public class Order
  {
    public readonly IAction Action;
    public readonly Character Target;
  }
}