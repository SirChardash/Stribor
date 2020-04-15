using System;
using System.Collections.Generic;
using Code.Combat;
using UnityEngine;

namespace Code.Handler
{
  public class CharacterModelHandler : MonoBehaviour
  {
    public SpriteRenderer characterSprite;
    public GameObject floatingNumberTextPrefab;
    public Character character;
    public Vector3 textOffset;
    private List<Sprite> _sprites;
    private const int SpriteDuration = 25;
    private int _step;
    private int _currentSprite;
    private float _previousHealth;
    private Camera _camera;

    private void Start()
    {
      _camera = Camera.main;
      Debug.Log("instantiated character sprite");
      _sprites = SpriteRepo.GetSprite("eh");
      _previousHealth = character.Health;
    }

    private void OnGUI()
    {
      characterSprite.sprite = _sprites[_currentSprite];

      if (++_step != SpriteDuration) return;
      _step = 0;
      _currentSprite = (_currentSprite + 1) % _sprites.Count;
    }

    private void Update()
    {
      if (Math.Abs(_previousHealth - character.Health) > 1)
      {
        var floatingNumberText = Instantiate(floatingNumberTextPrefab, transform, false);
        floatingNumberText.transform.position = _camera.ScreenToWorldPoint(
          _camera.WorldToScreenPoint(transform.position) + textOffset);
        floatingNumberText.GetComponent<FloatingNumberHandler>().numberChange = (int) (character.Health - _previousHealth);

        if (character.Health <= 0) Destroy(gameObject);
      }

      _previousHealth = character.Health;
    }
  }
}