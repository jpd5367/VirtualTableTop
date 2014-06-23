using UnityEngine;
using System.Collections;

[System.Serializable]
public class Enchantment {

	public int bonus;
	public DamageTypes damageType;
	public MagicBonusType magicBonusType;
	public Enchantment(){
		bonus = 0;
		damageType = DamageTypes.none;
		magicBonusType = MagicBonusType.none;
	}
}
