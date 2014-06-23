using UnityEngine;
using System.Collections;

[System.Serializable]
public class BonusDamage {
	public int numDice;
	public int diceType;
	public DamageTypes damageType;

	public BonusDamage(){
		numDice = 0;
		diceType = 0;
		damageType = DamageTypes.none;
	}
}
