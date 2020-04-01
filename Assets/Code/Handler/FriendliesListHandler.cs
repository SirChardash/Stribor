using System;
using System.Collections.Generic;
using System.Linq;
using Code.Combat;
using UnityEngine;

namespace Code.Handler
{
  public class FriendliesListHandler : MonoBehaviour
  {
    public GameObject characterBarPrefab;
    public RectTransform frame;
    public List<GameObject> characterInfo;
    public new Camera camera;

    private void OnGUI()
    {
    }

    private void Start()
    {
      characterInfo = new List<GameObject>();
      var encounter = EncounterHolder.CurrentEncounter;
      for (var i = 0; i < encounter.RightTeam.Count; i++)
      {
        var characterBar = Instantiate(characterBarPrefab, frame.transform, false);
        characterBar.transform.position = camera.ScreenToWorldPoint(camera.WorldToScreenPoint(frame.transform.position) + new Vector3(0, -20 * i));
        characterBar.GetComponent<FriendlyCharacterInfoHandler>().character = encounter.RightTeam[i];
        characterInfo.Add(characterBar);
        Debug.Log($"creating friendlies character info {i}");
      }
    }
  }
}