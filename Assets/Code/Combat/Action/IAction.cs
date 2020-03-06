namespace Code.Combat.Action
{
  public interface IAction
  {
    void Execute(Character self, Character target);

    string Name { get; }
    float CastTime { get; }
  }
}