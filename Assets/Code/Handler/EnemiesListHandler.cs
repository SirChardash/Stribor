using System;
using Code.Combat;
using UnityEngine;

namespace Code.Handler
{
  public class EnemiesListHandler : MonoBehaviour
  {
    public RectTransform frame;
    public GameObject characterNamePrefab;

    private void Start()
    {
      var encounter = EncounterHolder.CurrentEncounter;
      Debug.Log("creating " + encounter.LeftTeam.Count + " enemy infos");
      for (var i = 0; i < encounter.LeftTeam.Count; i++)
      {
        Debug.Log("creating enemy info " + i);
        var characterBar = Instantiate(characterNamePrefab, frame.transform, false);
        characterBar.transform.position = frame.transform.position + new Vector3(0, -20 * i);
        characterBar.GetComponent<EnemyInfoHandler>().character = encounter.LeftTeam[i];
      }
    }
  }
}