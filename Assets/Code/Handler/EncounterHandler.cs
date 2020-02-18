using System.Collections.Generic;
using Code.Combat;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Handler
{
  public class EncounterHandler : MonoBehaviour
  {
    public GameObject parent;
    public Text currentActionText;
    private Encounter _encounter;
    private const int Speed = 10;
    private int _step = 0;
    private int _renderStep = 0;
    private readonly int _renderLength = 100;
    private List<PreparedAction> _readyActions = new List<PreparedAction>();

    private void Start()
    {
      _encounter = EncounterHolder.CurrentEncounter;
      Debug.Log("created encounter " + (_encounter != null));
    }

    private void Update()
    {
      try
      {
        if (_readyActions.Count == 0) HandleEncounterUpdate();
        else HandleRendering();
      }
      catch (EncounterEndException e)
      {
        HandleEncounterEnd(e);
      }
    }

    private void HandleRendering()
    {
      var preparedAction = _readyActions[0];
      currentActionText.text = preparedAction.Self.Name
                               + " uses " + preparedAction.Action.Name
                               + " on " + preparedAction.Target.Name
                               + " [" + _renderStep + "/" + _renderLength + "]";

      if (++_renderStep % _renderLength != 0) return;
      _renderStep = 0;
      currentActionText.text = "";
      preparedAction.Action.Execute(preparedAction.Self, preparedAction.Target);
      _readyActions.RemoveAt(0);
    }

    private void HandleEncounterUpdate()
    {
      if (++_step % Speed != 0) return;
      _step = 0;
      _readyActions = _encounter.Update();
    }

    private void HandleEncounterEnd(EncounterEndException e)
    {
      Debug.Log("encounter finished: " +
                "friendlies [" + e.RightSideCount + "], " +
                "enemies [" + e.LeftSideCount + "]");
      parent.SetActive(false);
    }
  }
}