using System.Collections.Generic;
using System.Linq;
using Code.Combat.Action;
using Code.Combat.Behavior;

namespace Code.Combat
{
  public class Blueprint
  {
    private readonly string _name;
    private readonly float _maxHealth;
    private readonly float _speed;
    private readonly float _physicalDamage;
    private readonly float _magicalDamage;
    private readonly float _physicalArmor;
    private readonly float _magicalArmor;
    private readonly ICharacterBehavior _behavior;

    private readonly float _maxHealthGrowth;
    private readonly float _speedGrowth;
    private readonly float _physicalDamageGrowth;
    private readonly float _magicalDamageGrowth;
    private readonly float _physicalArmorGrowth;
    private readonly float _magicalArmorGrowth;

    private Blueprint(string name, float maxHealth, float speed, float physicalDamage, float magicalDamage,
      float physicalArmor, float magicalArmor, ICharacterBehavior behavior, float maxHealthGrowth, float speedGrowth,
      float physicalDamageGrowth, float magicalDamageGrowth, float physicalArmorGrowth, float magicalArmorGrowth)
    {
      _name = name;
      _maxHealth = maxHealth;
      _speed = speed;
      _physicalDamage = physicalDamage;
      _magicalDamage = magicalDamage;
      _physicalArmor = physicalArmor;
      _magicalArmor = magicalArmor;
      _behavior = behavior;
      _maxHealthGrowth = maxHealthGrowth;
      _speedGrowth = speedGrowth;
      _physicalDamageGrowth = physicalDamageGrowth;
      _magicalDamageGrowth = magicalDamageGrowth;
      _physicalArmorGrowth = physicalArmorGrowth;
      _magicalArmorGrowth = magicalArmorGrowth;
    }

    public Character ToCharacter(int level = 1, List<Modifier> modifiers = null, List<IAction> playerActions = null)
    {
      level--;
      var character = new Character(
        playerActions != null ? new ControlledBehavior(playerActions) : _behavior,
        _name,
        _maxHealth + level * _maxHealthGrowth,
        _maxHealth + level * _maxHealthGrowth,
        _speed + level * _speedGrowth,
        _physicalDamage + level * _physicalDamageGrowth,
        _magicalDamage + level * _magicalDamageGrowth,
        _physicalArmor + level * _physicalArmorGrowth,
        _magicalArmor + level * _magicalArmorGrowth
      );
      modifiers?.ForEach(modifier => modifier.Apply(character));
      return character;
    }

    // blueprint list
    
    public static readonly Blueprint LabSample1 = new Blueprint(
      "Lab sample #1",
      30,
      15,
      4,
      5,
      2,
      1,
      new ConstantAttack(), 
      0,
      0,
      0,
      0,
      0,
      0
    );

    public static readonly Blueprint LabSample2 = new Blueprint(
      "Lab sample #2",
      15,
      15,
      6,
      2,
      2,
      5,
      new ConstantAttack(),
      0,
      0,
      0,
      0,
      0,
      0
    );

    public static readonly Blueprint LabSample3 = new Blueprint(
      "Lab sample #3",
      25,
      21,
      4,
      5,
      5,
      6,
      new ConstantAttack(),
      0,
      0,
      0,
      0,
      0,
      0
    );
  }
}