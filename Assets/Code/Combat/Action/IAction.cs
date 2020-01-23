namespace Code.Combat.Action
{
  public interface IAction
  {
    void Execute(Character self, Character target);

    int Duration { get; }
  }
}