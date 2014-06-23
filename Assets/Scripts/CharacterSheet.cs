using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterSheet : MonoBehaviour {

	public string name;
	public string player;
	public string patronDiety;
	public CharacterAlignment alignment;
	public Dictionary<CharacterClass, int>[] Classes;
	public Dictionary<CharacterClass, int>[] DieTypes;
	public CharacterRace race;
	public int effectiveCharacterLevel;
	public Size size;
	public int age;
	public Gender gender;
	public Height height;
	public int weight;
	public string eyeColor;
	public string hairColor;
	public string skinColor;

	#region Attributes
	public int strength;
	public int dexterity;
	public int constitution;
	public int intelligence;
	public int wisdom;
	public int charisma;
	#endregion

	#region AttributeMods
	public int strengthMod;
	public int dexterityMod;
	public int constitutionMod;
	public int intelligenceMod;
	public int wisdomMod;
	public int charismaMod;
	#endregion

	#region TempAttributes
	public int tempStrength;
	public int tempDexterity;
	public int tempConstitution;
	public int tempIntelligence;
	public int tempWisdom;
	public int tempCharisma;
	#endregion
	
	#region AttributeMods
	public int tempStrengthMod;
	public int tempDexterityMod;
	public int tempConstitutionMod;
	public int tempIntelligenceMod;
	public int tempWisdomMod;
	public int tempCharismaMod;
	#endregion

	#region Health
	public int hitpoints;
	public int wounds;
	public int subdualDamage;
	public int armorClass;
	#endregion

	#region Movement
	public int movement_ground;
	public int movement_fly;
	public int movement_swim;
	#endregion

	#region CombatMods
	public int   initiative;
	public int[] baseAttack;
	public int[] baseMelee;
	public int[] baseRanged;
	#endregion

	#region Saves
	public int fortitude;
	public int reflex;
	public int will;
	#endregion

	#region Equipment
	public Weapon mainWeapon;
	public Weapon offHandWeapon;
	public ArmsWristItem armsWristSlot;
	public BodyItem bodySlot;
	public EyesItem eyesSlot;
	public FeetItem feetSlot;
	public HandsItem handsSlot;
	public HeadItem headSlot;
	public NeckItem neckSlot;
	public Ring ring1Slot;
	public Ring ring2Slot;
	public ShouldersItem shouldersSlot;
	public TorsoItem torsoSlot;
	public WaistItem waistSlot;



	#endregion

	#region FeatsSkills
	public List<Skill> skills;
	#endregion



	// Use this for initialization
	void Start () {
		Skill temp = new Skill();
		temp.name = SkillList.Alchemy;
		temp.ranks = 0;
		temp.untrained = false;
		temp.attribute = CharacterAttributes.Intelligence;
		temp.miscBonuses = new List<TempBonus>();
		temp.miscBonuses.Clear();

		skills.Add(temp);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		for(int i = 0;i < skills.Count; i++){
			GUI.TextArea(new Rect(5f, 50f *i, 100f, 50f), skills[i].name.ToString()+" - "+skills[i].ranks);
		}
	}
}
