using System;

namespace Code.Combat
{
  public class EncounterEndException : SystemException
  {
    public int LeftSideCount;
    public int RightSideCount;
  }
}