using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Code.Combat.Action;
using Code.Combat.Behavior;
using Code.Combat.Buff;

namespace Code.Combat
{
  public class Character : ICharacter
  {
    private const float TurnDuration = 100f;

    public ICharacterBehavior Behavior;
    public string Name { get; set; }
    public float MaxHealth { get; set; }
    public float Health { get; set; }
    public float Speed { get; set; }
    public float PhysicalDamage { get; set; }
    public float MagicalDamage { get; set; }
    public float PhysicalArmor { get; set; }
    public float MagicalArmor { get; set; }

    private float _turnProgress;
    public float TurnProgress => _turnProgress / TurnDuration;
    public PreparedAction ActiveAction;
    public readonly List<IBuff> Buffs = new List<IBuff>();

    public Character(ICharacterBehavior behavior, string name, float maxHealth, float health, float speed,
      float physicalDamage, float magicalDamage, float physicalArmor, float magicalArmor)
    {
      Behavior = behavior;
      Name = name;
      MaxHealth = maxHealth;
      Health = health;
      Speed = speed;
      PhysicalDamage = physicalDamage;
      MagicalDamage = magicalDamage;
      PhysicalArmor = physicalArmor;
      MagicalArmor = magicalArmor;
    }

    public bool Update(float timeIncrement)
    {
      _turnProgress = Math.Min(_turnProgress + timeIncrement * Speed, TurnDuration);
      Buffs.RemoveAll(buff => buff.Update(timeIncrement, this));
      return IsReady();
    }

    public bool IsReady()
    {
      return _turnProgress >= TurnDuration;
    }

    public bool IsCasting()
    {
      return ActiveAction != null;
    }

    public void ResetTurnProgress()
    {
      _turnProgress = 0;
    }

    public string DebugString()
    {
      return $"[{Name}] HP: {Health}/{MaxHealth}, SPD: {Speed}, DMG: P{PhysicalDamage}/M{MagicalDamage}, " +
             $"DEF: P{PhysicalArmor}/M{MagicalArmor} ({(int) _turnProgress}/{TurnDuration})";
    }

    /// <summary>
    /// Creates a snapshot of character. Keeps track of what the stats were for a character in given time, and will not
    /// change when actual character changes.
    /// </summary>
    /// <returns>partial snapshot of character</returns>
    public CharacterSnapshot Snapshot()
    {
      return new CharacterSnapshot(Name, MaxHealth, Health, Speed, PhysicalDamage, MagicalDamage, PhysicalArmor,
        MagicalArmor);
    }
  }
}