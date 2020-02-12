using Code.Combat.Action;

namespace Code.Combat
{
  public static class InputState
  {

    public static State Current = State.ChooseAction;
    public static IAction SelectedAction;
    public static Character Target;
    public static Character Source;

    public static void Clear()
    {
      Current = State.ChooseAction;
      SelectedAction = null;
      Target = null;
      Source = null;
    }
    public enum State
    {
      ChooseAction,
      ChooseTarget
    }
  }
}