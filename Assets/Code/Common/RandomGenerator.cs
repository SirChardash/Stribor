using System;

namespace Code.Common
{
  public static class RandomGenerator
  {
    private static readonly Random Random = new Random(new DateTime().Millisecond);

    public static int RandomInt(int bound)
    {
      return Random.Next(bound);
    }
  }
}