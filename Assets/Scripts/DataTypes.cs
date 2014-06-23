using UnityEngine;
using System.Collections;

public enum CharacterAttributes{
	Undefined    = 0,
	Strength     = 1,
	Dexterity    = 2,
	Constitution = 3,
	Intelligence = 4,
	Wisdom       = 5,
	Charisma     = 6
};
public enum CharacterAlignment{
	LG = 0,
	NG = 1,
	CG = 2,
	LN = 3,
	TN = 4,
	CN = 5,
	LE = 6,
	NE = 7,
	CE = 8
};

public enum CharacterClass{
	Barbarian = 0,
	Bard      = 1,
	Cleric    = 2,
	Druid     = 3,
	Fighter   = 4,
	Monk      = 5,
	Paladin   = 6,
	Ranger    = 7,
	Rogue     = 8,
	Sorcerer  = 9,
	Wizard    = 10
};

public enum CharacterRace{
	Human    = 0,
	Dwarf    = 1,
	Elf      = 2,
	Gnome    = 3,
	Half_Elf = 4,
	Half_Orc = 5,
	Halfling = 6
};

public enum Size{
	Tiny       = 0,
	Small      = 1,
	Medium     = 2,
	Large      = 3,
	Huge       = 4,
	Gargantuan = 5,
	Colossal   = 6
};

public enum Gender{
	Male   = 0,
	Female = 1
};

public enum DamageTypes{
	none,
	Slashing,
	Piercing,
	Bludgeoning,
	Slashing_Bludgeoning,
	Slashing_Piercing,
	Bludgeoning_Piercing,
	Fire,
	Electricity,
	Cold,
	Holy,
	UnHoly,
	Lawful,
	Chaotic,
	Brilliant_Energy,
	Bane_Aberrations,
	Bane_Animals,
	Bane_Beasts,
	Bane_Constructs,
	Bane_Dragons,
	Bane_Elementals,
	Bane_Fey,
	Bane_Giants,
	Bane_Magical_Beasts,
	Bane_Monsterous_Humanoids,
	Bane_Oozes,
	Bane_Outsiders_Chaotic,
	Bane_Outsiders_Evil,
	Bane_Outsiders_Good,
	Bane_Outsiders_Lawful,
	Bane_Plants,
	Bane_Shapechangers,
	Bane_Undead,
	Bane_Vermin,
	Bane_Humanoid_Aquatic,
	Bane_Humanoid_Duergar,
	Bane_Humanoid_Drow,
	Bane_Humanoid_Dwarf,
	Bane_Humanoid_Gnome,
	Bane_Humanoid_Gnoll,
	Bane_Humanoid_Goblinoid,
	Bane_Humanoid_Elf,
	Bane_Humanoid_Halfling,
	Bane_Humanoid_Human,
	Bane_Humanoid_Orc,
	Bane_Humanoid_Rakshasa,
	Bane_Humanoid_Reptilian
};

public enum WeaponCategory{
	Simple  = 1,
	Martial = 2,
	Exotic  = 3
};

public enum WeaponRangeType{
	Melee =  0,
	Ranged = 1
};

public enum WeaponSize{
	Tiny   = 0,
	Small  = 1,
	medium = 2, 
	Large  = 3
};

public enum MagicBonusType{
	none          =  0,
	Armor         =  1,
	Circumstance  =  2,
	Competence    =  3,
	Deflection    =  4,
	Dodge         =  5,
	Enhancement   =  6,
	Enlargement   =  7,
	Haste         =  8,
	Inherent      =  9,
	Insight       = 10,
	Luck          = 11,
	Morale        = 12,
	Natural_Armor = 13,
	Profane       = 14,
	Resistance    = 15,
	Sacred        = 16,
	Synergy       = 17
};

public enum SkillList{
	Undefined          =  0,
	Alchemy            =  1,
	Animal_Empathy     =  2,
	Appraise           =  3,
	Balance            =  4,
	Bluff              =  5,
	Climb              =  6,
	Concentrate        =  7,
	Craft              =  8,
	Decipher_Script    =  9,
	Diplomacy          = 10,
	Disable_Device     = 11,
	Disquise           = 12,
	Escape_Artist      = 13,
	Forgery            = 14,
	Gather_Information = 15,
	Handle_Animal      = 16,
	Heal               = 17,
	Hide               = 18,
	Innuendo           = 19,
	Intimidate         = 20,
	Intuit_Direction   = 21,
	Jump               = 22,
	Knowledge          = 23,
	Listen             = 24,
	Move_Silently      = 25,
	Open_Lock          = 26,
	Perform            = 27,
	Pick_Pocket        = 28,
	Profession         = 29,
	Read_Lips          = 30,
	Ride               = 31,
	Scry               = 32,
	Search             = 33,
	Sense_Motive       = 34,
	Spellcraft         = 35,
	Spot               = 36,
	Swim               = 37,
	Tumble             = 38,
	Use_Magic_Device   = 39,
	Use_Rope           = 40,
	Wilderness_Lore    = 41
}




public class DataTypes{
	
}
