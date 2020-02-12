using System;
using Code.Combat;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Code.Handler
{
  public class EnemyInfoHandler : MonoBehaviour, ISelectHandler
  {
    public Character character;
    public Text characterName;
    public Selectable characterInfo;

    private void Start()
    {
      Debug.Log("called start in EnemyInfoHandler");
      characterName.text = character.Name;
    }

    private void Update()
    {
      characterInfo.interactable = InputState.Current == InputState.State.ChooseTarget;

      if (character.Health > 0) return;
      Destroy(gameObject);
    }

    public void OnSelect(BaseEventData eventData)
    {
      InputState.Target = character;
    }
  }
}