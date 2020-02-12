using System;
using System.Collections;
using System.Collections.Generic;
using Code.Combat;
using Code.Combat.Action;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace Code.Handler
{
  public class CharacterPanelHandler : MonoBehaviour
  {
    public RectTransform frame;
    public GameObject buttonPrefab;
    private List<GameObject> _buttons;

    private void Start()
    {
      _buttons = new List<GameObject>();
    }

    private void Update()
    {
      if (!ActiveCharacter.Changed) return;
      GenerateButtons(ActiveCharacter.Character);
      ActiveCharacter.Changed = false;
    }

    private void GenerateButtons(Character character)
    {
      _buttons.ForEach(button => button.SetActive(false));
      _buttons.Clear();

      if (character == null) return;

      for (var i = 0; i < character.AvailableActions.Count; i++)
      {
        var button = Instantiate(buttonPrefab, frame.transform, false);
        button.transform.position = frame.transform.position + new Vector3(0, -25 * i);
        var i1 = i;
        button.GetComponent<Button>().onClick.AddListener(() =>
        {
          InputState.SelectedAction = character.AvailableActions[i1];
          InputState.Current = InputState.State.ChooseTarget;
        });
        button.GetComponentInChildren<Text>().text = character.AvailableActions[i].GetType().Name;
        _buttons.Add(button);
      }
    }
  }
}