using Code.Combat.Action;

namespace Code.Combat.Behavior
{
  public class Order
  {
    public IAction Action;
    public Character Target;

    public void Clear()
    {
      Action = null;
      Target = null;
    }

    public bool IsReady()
    {
      return Action != null && Target != null;
    }
  }
}