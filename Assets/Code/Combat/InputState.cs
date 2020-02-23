using Code.Combat.Action;

namespace Code.Combat
{
  public static class InputState
  {

    public static State Current = State.ChooseAction;

    public static void Clear()
    {
      Current = State.ChooseAction;
    }

    public enum State
    {
      ChooseAction,
      ChooseTarget
    }
  }
}