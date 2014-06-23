using System.Collections;
using System.Collections.Generic;

public  interface Weapon {
	WeaponRangeType isRanged();
	string GetName();
	int GetBaseDamage();
	int GetDamageMod();
	int GetRange();
	int GetWeight();
	DamageType GetBaseDamageType();
	WeaponSize GetSize();
	List<Enchantment> GetEnchantment();
	List<BonusDamage> GetBonusDamage();
	int GetCriticalMin();
	int GetCriticalMax();
	string GetDescription();
	int GetRangeIncrement();

	
	void SetName(string name);
	void SetBaseDamage(int damage);
	void SetDamageMod(int damageMod);
	void SetRange(int range);
	void SetWeight(int weight);
	void SetBaseDamageType(DamageType type);
	void SetSize(WeaponSize size);
	void AddEnchantment(Enchantment Enchantment);
	void SetCriticalMin(int critMin);
	void SetCriticalMax(int critMax);
	void SetCritRange(int min, int max);   
	void SetDescription(string description);
	void SetRangeIncrement(int rangeIncrement);
	
}
