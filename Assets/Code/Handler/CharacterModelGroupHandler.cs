using System;
using Code.Combat;
using UnityEngine;

namespace Code.Handler
{
  public class CharacterModelGroupHandler : MonoBehaviour
  {
    public RectTransform renderingLocation;
    public Side side;
    public GameObject characterModelPrefab;
    public new Camera camera;

    private void Start()
    {
      var encounter = EncounterHolder.CurrentEncounter;
      var characters = side == Side.Friendlies ? encounter.RightTeam : encounter.LeftTeam;
      var xOffset = side == Side.Enemies ? -20 : 20;
      var flipX = side == Side.Enemies;

      for (var i = 0; i < characters.Count; i++)
      {
        var characterModel = Instantiate(characterModelPrefab, renderingLocation.transform, false);
        characterModel.GetComponent<CharacterModelHandler>().character = characters[i];
        var position = camera.ScreenToWorldPoint(
          camera.WorldToScreenPoint(renderingLocation.transform.position) + new Vector3(xOffset * i, -65 * i));
        characterModel.transform.position = position;
        characterModel.GetComponent<CharacterModelHandler>().textOffset =
          new Vector3(side == Side.Enemies ? 30 : -30, 0);
        characterModel.GetComponentInChildren<SpriteRenderer>().flipX = flipX;
      }
    }
  }


  public enum Side
  {
    Friendlies,
    Enemies
  }
}