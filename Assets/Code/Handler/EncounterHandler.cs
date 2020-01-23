using Code.Combat;
using UnityEditor;
using UnityEngine;

namespace Code.Handler
{
  public class EncounterHandler : MonoBehaviour
  {
    public GameObject parent;
    private Encounter _encounter;
    private const int Speed = 1;
    private int _step = 0;

    void Start()
    {
      _encounter = EncounterHolder.CurrentEncounter;
      Debug.Log("created encounter");
    }

    void Update()
    {
      if (_step % Speed == 0)
      {
        var result = _encounter.Update();
        if (result != null)
        {
          Debug.Log("encounter finished: friendlies [" + result.RightSideCount + "], enemies [" +
                    result.LeftSideCount + "]");
          parent.SetActive(false);
        }
      }

      _step++;
    }
  }
}