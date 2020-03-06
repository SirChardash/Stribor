using System;
using Code.Combat;
using Code.Combat.Behavior;
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
    public Slider actionFill;
    public Slider castFill;
    public Selectable characterBar;

    /// <summary>
    /// This flag is used to update ActiveCharacter.Changed only first time unit is registered dead.
    /// </summary>
    private bool _confirmedDead;

    private void Update()
    {
      if (_confirmedDead) return;

      characterName.text = character.Name;
      health.text = character.Health.ToString();
      actionFill.value = character.TurnProgress;
      castFill.gameObject.SetActive(character.IsCasting());
      if (character.IsCasting()) castFill.value = character.ActiveAction.Progress;

      var characterSelectable = character.Health > 0
                                && character.IsReady()
                                && !character.Equals(ActiveCharacter.Character)
                                && !((ControlledBehavior) character.Behavior).Order.IsReady()
                                || InputState.Current == InputState.State.ChooseTarget;

      characterBar.interactable = characterSelectable;

      if (!character.IsReady()) ((ControlledBehavior) character.Behavior).Order.Clear();

      if (character.Health > 0) return;
      _confirmedDead = true;
      if (!character.Equals(ActiveCharacter.Character)) return;
      ActiveCharacter.Character = null;
      ActiveCharacter.Changed = true;
    }

    public void OnSelect(BaseEventData eventData)
    {
      ActiveCharacter.Changed = true;
      ActiveCharacter.Character = character;
      if (InputState.Current == InputState.State.ChooseTarget) ActiveCharacter.Order.Target = character;
    }
  }
}