namespace Code.Combat
{
  public class InputState
  {

    public State Current = State.ChooseAction;
    public enum State
    {
      ChooseAction,
      ChooseTarget
    }
  }
}