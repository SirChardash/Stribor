using System;
using System.Collections.Generic;
using Code.Combat;
using UnityEngine;

namespace Code.Handler
{
  public class CharacterModelHandler : MonoBehaviour
  {
    public SpriteRenderer characterSprite;
    public Character character;
    private List<Sprite> _sprites;
    private const int SpriteDuration = 40;
    private int _step;
    private int _currentSprite;

    private void Start()
    {
      characterSprite.flipX = true;
      Debug.Log("instantiated character sprite");
      _sprites = SpriteRepo.GetSprite("eh");
    }

    private void OnGUI()
    {
      characterSprite.sprite = _sprites[_currentSprite];

      if (++_step != SpriteDuration) return;
      _step = 0;
      _currentSprite = (_currentSprite + 1) % _sprites.Count;
    }
  }
}