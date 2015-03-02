using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
	public int maxHealth = 60;
	public int currentHealth = 60;
	public int maxEnergy = 40; 
	public int currentEnergy = 40; 
	
	float counter; 
	float energyRegen = 2; 
	
	float energyBarLength;
	float healthBarLength;
	
	
	void Start () 
	{
		healthBarLength = Screen.width / 2; 
		energyBarLength = Screen.width / 3;
	}
	
	void FixedUpdate() {
	
	//AddjustCurrentEnergy(1);
	}
	 
	void Update () 
	{
		AddjustCurrentHealth(0);
		AddjustCurrentEnergy(0);
		energyRegen -= Time.deltaTime;
		if (energyRegen <= 0) {
			AddjustCurrentEnergy(1);
			energyRegen = 2;
		}
	}
	void OnGUI() 
	{
		GUI.Box(new Rect(10, 10, healthBarLength, 20), currentHealth + "/" + maxHealth);
		GUI.Box(new Rect(10, 40, energyBarLength, 20), currentEnergy + "/" + maxEnergy);
	}
	public void AddjustCurrentHealth(int adj) 
	{
		currentHealth += adj;
		
		if(currentHealth <= 0) 
		{
			currentHealth = 0;
			//killed();
		}
		if(currentHealth > maxHealth) 
		{
		 currentHealth = maxHealth;
		}
		healthBarLength = ((Screen.width / 2) * (currentHealth / (float)maxHealth))-100;
	// Update is called once per frame
	}
	
	public void AddjustCurrentEnergy(int adj) 
	{
		currentEnergy += adj;
		if (currentEnergy < 0)
			currentEnergy = 0;
		if (currentEnergy > maxEnergy)
			currentEnergy = maxEnergy;
		energyBarLength = ((Screen.width / 3) * (currentEnergy / (float)maxEnergy))-80;
	}
	
}
