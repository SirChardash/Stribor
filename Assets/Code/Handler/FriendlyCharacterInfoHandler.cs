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

    private void Update()
    {
      characterName.text = character.Name;
      health.text = character.Health.ToString();
      slider.value = character.TurnProgress;

      if (character.Health > 0) return;
      ActiveCharacter.Character = null;
      ActiveCharacter.Changed = true;
    }

    public void OnSelect(BaseEventData eventData)
    {
      if (character.Health <= 0) return;
      if (character.Equals(ActiveCharacter.Character)) return;
      ActiveCharacter.Changed = true;
      ActiveCharacter.Character = character;
    }
  }
}