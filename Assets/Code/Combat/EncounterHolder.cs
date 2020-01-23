namespace Code.Combat
{
  public static class EncounterHolder
  {
    public static readonly Encounter CurrentEncounter = new EncounterFactory().CreateSample();
  }
}