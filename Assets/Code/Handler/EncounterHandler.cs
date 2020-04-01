using System;
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
    private double _renderProgress;
    private const float RenderLength = 1f;
    private const float TimeScale = 1f;
    private List<PreparedAction> _readyActions = new List<PreparedAction>();

    private void Start()
    {
      _encounter = EncounterHolder.CurrentEncounter;
      Debug.Log($"created encounter {_encounter != null}");
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
      currentActionText.text = $"{preparedAction.Self.Name} uses {preparedAction.Action.Name} " +
                               $"on {preparedAction.Target.Name} [{_renderProgress:0.00}/{RenderLength}]";

      _renderProgress += Time.deltaTime * TimeScale;
      if (_renderProgress < RenderLength) return;
      _renderProgress = 0;
      currentActionText.text = "";
      preparedAction.Action.Execute(preparedAction.Self, preparedAction.Target);
      _readyActions.RemoveAt(0);
    }

    private void HandleEncounterUpdate()
    {
      _readyActions = _encounter.Update(Time.deltaTime * TimeScale);
    }

    private void HandleEncounterEnd(EncounterEndException e)
    {
      Debug.Log($"encounter finished: friendlies [{e.RightSideCount}], enemies [{e.LeftSideCount}]");
      parent.SetActive(false);
    }
  }
}