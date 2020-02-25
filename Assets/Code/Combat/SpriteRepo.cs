using System.Collections.Generic;
using Code.Common;
using UnityEngine;

namespace Code.Combat
{
  public static class SpriteRepo
  {
    public static List<Sprite> GetSprite(string characterName)
    {
      //todo: actually implement what's promised
      var id = RandomGenerator.RandomInt(102) * 2 + 1;
      Debug.Log("random id is " + id);
      Debug.Log("loading " + "Sprites/Characters/monster_" + id.ToString("00"));
      Debug.Log("loading " + "Sprites/Characters/monster_" + (id + 1).ToString("00"));
      return new List<Sprite>
      {
        Resources.Load<Sprite>("Sprites/Characters/monster_" + id.ToString("00")),
        Resources.Load<Sprite>("Sprites/Characters/monster_" + (id + 1).ToString("00")),
      };
    }
  }
}