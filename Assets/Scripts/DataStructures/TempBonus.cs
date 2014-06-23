using UnityEngine;
using System.Collections;

[System.Serializable]
public class TempBonus{

	public int bonus;
	public MagicBonusType bonusType;
	public string description;

	public TempBonus(){
		bonus = 0;
		bonusType = MagicBonusType.none;
		description = "";
	}
}
