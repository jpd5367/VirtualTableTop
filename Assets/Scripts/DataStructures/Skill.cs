using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Skill{

	// Use this for initialization
	public SkillList name;
	public int ranks;
	public CharacterAttributes attribute;
	public List<TempBonus> miscBonuses;
	public bool untrained;

	public Skill(){
		name = SkillList.Undefined;
		ranks = 0;
		attribute = CharacterAttributes.Undefined;
		miscBonuses = new List<TempBonus>();
		untrained = false;
	}
}
