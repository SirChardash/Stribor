using System;
using Code.Combat;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

namespace Code.Handler
{
  public class FriendlyCharacterInfoHandler : MonoBehaviour, ISelectHandler
  {
    public Text characterName;
    public Text health;
    public Character character;
    public Slider slider;
    public Selectable characterBar;

    private void Update()
    {
      characterName.text = character.Name;
      health.text = character.Health.ToString();
      slider.value = character.TurnProgress;

      var characterSelectable = (character.Health > 0
                                 && character.IsReady()
                                 && !character.Equals(ActiveCharacter.Character))
                                || InputState.Current == InputState.State.ChooseTarget;

      characterBar.interactable = characterSelectable;

      if (character.Health > 0) return;
      ActiveCharacter.Character = null;
      ActiveCharacter.Changed = true;
    }

    public void OnSelect(BaseEventData eventData)
    {
      ActiveCharacter.Changed = true;
      ActiveCharacter.Character = character;

      if (InputState.Current == InputState.State.ChooseAction) InputState.Source = character;
      if (InputState.Current == InputState.State.ChooseTarget) InputState.Target = character;
    }
  }
}