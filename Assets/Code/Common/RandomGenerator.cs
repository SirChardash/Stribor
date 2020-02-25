using System;
using UnityEngine;
using Random = System.Random;

namespace Code.Common
{
  public static class RandomGenerator
  {
    private static readonly Random Random = new Random(DateTime.Now.Millisecond);

    public static int RandomInt(int bound)
    {
      return Random.Next(bound);
    }
  }
}