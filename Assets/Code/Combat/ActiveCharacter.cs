using Code.Combat.Behavior;

namespace Code.Combat
{
  public static class ActiveCharacter
  {
    public static bool Changed = false;
    public static Character Character;
    public static Order Order => ((ControlledBehavior) Character?.Behavior)?.Order;
  }
}